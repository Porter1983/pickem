﻿using Marten;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PickEmServer.Api.Models;
using PickEmServer.App;
using PickEmServer.App.Models;
using PickEmServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickEmServer.Heart
{
   
    public class LeagueService
    {
        private readonly IDocumentStore _documentStore;
        private readonly ILogger<LeagueService> _logger;
        private readonly GameService _gameSevice;
        private readonly ReferenceService _referenceSevice;
        private readonly UserManager<PickEmUser> _userManager;

        private class LeagueGameComparer : IEqualityComparer<LeagueGameData>
        {
            public bool Equals(LeagueGameData x, LeagueGameData y)
            {
                return x.GameIdRef == y.GameIdRef;
            }

            public int GetHashCode(LeagueGameData obj)
            {
                return obj.GetHashCode();
            }
        }

        public LeagueService(IDocumentStore documentStore, ILogger<LeagueService> logger, ReferenceService referenceService, GameService gameSevice, UserManager<PickEmUser> userManager)
        {
            _documentStore = documentStore;
            _gameSevice = gameSevice;
            _logger = logger;
            _referenceSevice = referenceService;
            _userManager = userManager;
        }

        public async Task<League> AddLeague(string seasonCode, LeagueAdd newLeague)
        {
            if (newLeague == null)
            {
                throw new ArgumentException("No newLeague parameter input for AddLeague (is null)");
            }

            using (var dbSession = _documentStore.LightweightSession())
            {
                // verify season exists
                _referenceSevice.ThrowIfNonexistantSeason(seasonCode);

                // verify league does not already exist 
                var game = await dbSession
                   .Query<LeagueData>()
                   .Where(l => l.LeagueCode == newLeague.LeagueCode)
                   .SingleOrDefaultAsync()
                   .ConfigureAwait(false);

                if (game != null)
                {
                    throw new ArgumentException($"Matching league already exists with league code: {newLeague.LeagueCode}");
                }

                LeagueData newLeagueData = new LeagueData
                {
                    LeagueCode = newLeague.LeagueCode,
                    LeagueTitle = newLeague.LeagueTitle,
                    PlayerSeasonScores = new List<PlayerScoreSubtotalData>(),
                    Players = new List<LeaguePlayerData>(),
                    SeasonCodeRef = seasonCode,
                    Weeks = new List<LeagueWeekData>()
                };

                foreach (var weekNumberRef in newLeague.WeekNumbers)
                {
                    newLeagueData.Weeks.Add(new LeagueWeekData
                    {
                        Games = new List<LeagueGameData>(),
                        PlayerWeekScores = new List<PlayerScoreSubtotalData>(),
                        WeekNumberRef = weekNumberRef
                    });
                }

                dbSession.Store(newLeagueData);
                dbSession.SaveChanges();
            }

            // read back out to return
            return await this.ReadLeague(newLeague.LeagueCode);

        }

        internal async Task<League> AddLeagueGame(string seasonCode, string leagueCode, int weekNumber, LeagueGameAdd newLeagueGame)
        {
            if (newLeagueGame == null)
            {
                throw new ArgumentException("No newLeagueGame parameter input for AddLeagueGame (is null)");
            }

            using (var dbSession = _documentStore.LightweightSession())
            {
                var leagueData = dbSession
                    .Query<LeagueData>()
                    .Where(l => l.LeagueCode == leagueCode)
                    .SingleOrDefault();

                if (leagueData == null)
                {
                    throw new ArgumentException($"No league exists with league code: {leagueCode}");
                }

                if (leagueData.SeasonCodeRef != seasonCode)
                {
                    throw new ArgumentException($"No league exists with league code: {leagueCode} for season: {seasonCode}");
                }

                var leagueWeek = leagueData.Weeks.SingleOrDefault(w => w.WeekNumberRef == weekNumber);
                if (leagueWeek == null)
                {
                    throw new ArgumentException($"League with league code: {leagueCode} does not contain week: {weekNumber}");
                }

                if (leagueWeek.Games.Exists(g => g.GameIdRef == newLeagueGame.GameId))
                {
                    throw new ArgumentException($"League with league code: {leagueCode} already has game with gameid: {newLeagueGame.GameId} for week: {weekNumber}");
                }

                var game = dbSession
                    .Query<GameData>()
                    .Where(g => g.GameId == newLeagueGame.GameId)
                    .SingleOrDefault();

                if (game == null)
                {
                    throw new ArgumentException($"Game with gameid: {newLeagueGame.GameId} does not exist");
                }

                if (game.WeekNumberRef != weekNumber)
                {
                    throw new ArgumentException($"Game week must match League week and they do not. League with league code: {leagueCode} has week: {weekNumber}. Game with game id: {newLeagueGame.GameId} has week {game.WeekNumberRef}");
                }

                // whew we can add this now.
                leagueWeek.Games.Add(new LeagueGameData { GameIdRef = newLeagueGame.GameId, PlayerPicks = new List<PlayerPickData>() });

                SynchGamesAndPlayers(leagueData);

                dbSession.Store(leagueData);
                dbSession.SaveChanges();
            }

            // read back out to return
            return await this.ReadLeague(leagueCode);
        }

        internal async Task<League> AddLeaguePlayer(string leagueCode, LeaguePlayerAdd newLeaguePlayer)
        {
            if (newLeaguePlayer == null)
            {
                throw new ArgumentException("No newLeagueGame parameter input for AddLeaguePlayer (is null)");
            }

            if ( await _userManager.FindByNameAsync(newLeaguePlayer.UserName) == null )
            {
                throw new ArgumentException($"No user with username (id) : {newLeaguePlayer.UserName}. Cannot add league player"); 
            }

            using (var dbSession = _documentStore.LightweightSession())
            {
                var leagueData = dbSession
                    .Query<LeagueData>()
                    .Where(l => l.LeagueCode == leagueCode)
                    .SingleOrDefault();

                if (leagueData == null)
                {
                    throw new ArgumentException($"No league exists with league code: {leagueCode}");
                }

                
                if (leagueData.Players.Exists(p => p.PlayerTag == newLeaguePlayer.PlayerTag))
                {
                    throw new ArgumentException($"League with league code: {leagueCode} already has player with player tag: {newLeaguePlayer.PlayerTag}");
                }
                
                // whew we can add this now.
                leagueData.Players.Add(new LeaguePlayerData { PlayerTag = newLeaguePlayer.PlayerTag, UserNameRef = newLeaguePlayer.UserName });

                SynchGamesAndPlayers(leagueData);

                dbSession.Store(leagueData);
                dbSession.SaveChanges();
            }

            // read back out to return
            return await this.ReadLeague(leagueCode);
        }

        internal async Task<List<LeagueData>> ApplyGameChanges(GameData updatedGame, GameChanges gameChanges, IDocumentSession runningDbSession)
        {
            var leagueGameToMatch = new LeagueGameData { GameIdRef = updatedGame.GameId };

            // TODO: is there a better way to do this, native to Marten? Failed with the following
            //      .Where(l => l.Weeks.Any(w => w.Games.Any(g => g.GameIdRef == updatedGame.GameId)))
            //  .Where(l => l.Weeks.Any(w => w.Games.Contains(leagueGameToMatch, new LeagueGameComparer())))
            var directSql = 
                $@"SELECT 
                    jsonb_pretty(l.data)
                FROM
                    public.mt_doc_leaguedata l,
                    jsonb_array_elements(data->'Weeks') weeks,
	                jsonb_array_elements(weeks->'Games') games
                WHERE
                    games->>'GameIdRef' = '{updatedGame.GameId}'"
                ;

            var associatedLeagues = runningDbSession.Query<LeagueData>(directSql).ToList();

            foreach ( var leagueData in associatedLeagues )
            {
                // Checking both change flags and updating player picks. 
                if ( gameChanges.ScoreChanged || gameChanges.GameStateChanged )
                {
                    // game score changed : update pick status(es) for related games
                    // TODO: ToArray is dumb. There will only be one. How to in Linq?
                    var assocatedLeagueGameData = leagueData.Weeks.SelectMany(w => w.Games.Where(g => g.GameIdRef == updatedGame.GameId)).ToArray();

                    foreach (var playerPickData in assocatedLeagueGameData[0].PlayerPicks)
                    {
                        switch (updatedGame.GameState)
                        {
                            case GameStates.Cancelled:
                                playerPickData.PickStatus = PickStatuses.None;
                                break;

                            case GameStates.Final:
                                if (updatedGame.AwayTeam.ScoreAfterSpread < updatedGame.HomeTeam.ScoreAfterSpread)
                                {
                                    // home team winning (on spread)
                                    switch (playerPickData.Pick)
                                    {
                                        case PickTypes.None:
                                            playerPickData.PickStatus = PickStatuses.None;
                                            break;

                                        case PickTypes.Away:
                                            playerPickData.PickStatus = PickStatuses.Lost;
                                            break;

                                        case PickTypes.Home:
                                            playerPickData.PickStatus = PickStatuses.Won;
                                            break;

                                        default:
                                            throw new ArgumentException($"Unknown PickTypes: {playerPickData.Pick}");
                                    }
                                }
                                else if (updatedGame.AwayTeam.ScoreAfterSpread > updatedGame.HomeTeam.ScoreAfterSpread)
                                {
                                    // away team winning (on spread)
                                    switch (playerPickData.Pick)
                                    {
                                        case PickTypes.None:
                                            playerPickData.PickStatus = PickStatuses.None;
                                            break;

                                        case PickTypes.Away:
                                            playerPickData.PickStatus = PickStatuses.Won;
                                            break;

                                        case PickTypes.Home:
                                            playerPickData.PickStatus = PickStatuses.Lost;
                                            break;

                                        default:
                                            throw new ArgumentException($"Unknown PickTypes: {playerPickData.Pick}");
                                    }
                                }
                                else
                                {
                                    // tied (on spread)
                                    if (playerPickData.Pick == PickTypes.None)
                                    {
                                        playerPickData.PickStatus = PickStatuses.None;
                                    }
                                    else
                                    {
                                        playerPickData.PickStatus = PickStatuses.Pushed;
                                    }
                                }
                                break;

                            case GameStates.InGame:
                                if (updatedGame.AwayTeam.ScoreAfterSpread < updatedGame.HomeTeam.ScoreAfterSpread)
                                {
                                    // home team winning (on spread)
                                    switch (playerPickData.Pick)
                                    {
                                        case PickTypes.None:
                                            playerPickData.PickStatus = PickStatuses.None;
                                            break;

                                        case PickTypes.Away:
                                            playerPickData.PickStatus = PickStatuses.Losing;
                                            break;

                                        case PickTypes.Home:
                                            playerPickData.PickStatus = PickStatuses.Winning;
                                            break;

                                        default:
                                            throw new ArgumentException($"Unknown PickTypes: {playerPickData.Pick}");
                                    }
                                }
                                else if (updatedGame.AwayTeam.ScoreAfterSpread > updatedGame.HomeTeam.ScoreAfterSpread)
                                {
                                    // away team winning (on spread)
                                    switch (playerPickData.Pick)
                                    {
                                        case PickTypes.None:
                                            playerPickData.PickStatus = PickStatuses.None;
                                            break;

                                        case PickTypes.Away:
                                            playerPickData.PickStatus = PickStatuses.Winning;
                                            break;

                                        case PickTypes.Home:
                                            playerPickData.PickStatus = PickStatuses.Losing;
                                            break;

                                        default:
                                            throw new ArgumentException($"Unknown PickTypes: {playerPickData.Pick}");
                                    }
                                }
                                else
                                {
                                    // tied (on spread)
                                    if (playerPickData.Pick == PickTypes.None)
                                    {
                                        playerPickData.PickStatus = PickStatuses.None;
                                    }
                                    else
                                    {
                                        playerPickData.PickStatus = PickStatuses.Pushing;
                                    }
                                }
                                break;

                            default:
                                throw new Exception($"Invalid game state to change score {updatedGame.GameState}");
                        }
                        break;

                    }
                }

                if ( gameChanges.GameStateChanged )
                {
                    if ( updatedGame.GameState == GameStates.Final || updatedGame.GameState == GameStates.Cancelled )
                    {
                        this.SynchScoreboards(leagueData);
                    }
                }
            }

            return associatedLeagues.ToList();
        }


        public async Task<List<Player>> ReadLeaguePlayers(string seasonCode, string leagueCode)
        {
            var leagueData = await this.GetLeagueData(seasonCode, leagueCode);

            var resultPlayers = new List<Player>();

            foreach ( var playerData in leagueData.Players )
            {
                resultPlayers.Add(new Player
                {
                    PlayerTag = playerData.PlayerTag
                });
            }

            return resultPlayers;
        }

        public async Task<List<int>> ReadLeagueWeeks(string seasonCode, string leagueCode)
        {
            var leagueData = await this.GetLeagueData(seasonCode, leagueCode);

            var resultWeeks = new List<int>();

            foreach (var weekData in leagueData.Weeks)
            {
                resultWeeks.Add(weekData.WeekNumberRef);
            }

            return resultWeeks;
        }

        internal async Task<PlayerPick> SetPlayerPick(string seasonCode, string leagueCode, int weekNumber, string playerTag, int gameId, PlayerPickUpdate newPlayerPick)
        {
            if (newPlayerPick == null)
            {
                throw new ArgumentException("No newPlayerPick parameter input for SetPlayerPick (is null)");
            }

            using (var dbSession = _documentStore.LightweightSession())
            {
                var leagueData = await this.GetLeagueData(dbSession, seasonCode, leagueCode);

                var weekData = leagueData.Weeks.SingleOrDefault(w => w.WeekNumberRef == weekNumber);
                if (weekData == null)
                {
                    throw new ArgumentException($"League: {leagueCode} for season: {seasonCode} does not contain a week: {weekNumber}");
                }

                var pickemGameData = weekData.Games.SingleOrDefault(g => g.GameIdRef == gameId);
                if (pickemGameData == null)
                {
                    throw new ArgumentException($"League: {leagueCode} for season: {seasonCode}, week: {weekNumber} does not have a game with gameid: {gameId}");
                }

                var playerPickData = pickemGameData.PlayerPicks.SingleOrDefault(pp => pp.PlayerTagRef == playerTag);
                if (playerPickData == null)
                {
                    throw new ArgumentException($"League: {leagueCode} for season: {seasonCode}, week: {weekNumber}, game {gameId}, has no player pick for {playerTag}. Is {playerTag} in this league?");
                }

                // get associated game to make sure the player can update the pick
                var gameData = await _gameSevice.ReadGame(gameId);

                switch ( gameData.GameState )
                {
                    case GameStates.Cancelled:
                    case GameStates.Final:
                    case GameStates.InGame:
                        throw new Exception($"Player: {playerTag} in league: {leagueCode} cannot make a pick for game: {gameId} because the game is in the following game state: {gameData.GameState}");
                }

                playerPickData.Pick = newPlayerPick.Pick;

                dbSession.Store(leagueData);
                dbSession.SaveChanges();

                return new PlayerPick { Pick = playerPickData.Pick };
            }
        }

        private async Task<LeagueData> GetLeagueData(string seasonCode, string leagueCode)
        {
            using (var dbSession = _documentStore.QuerySession())
            {
                return await GetLeagueData(dbSession, seasonCode, leagueCode);
            }
        }

        private async Task<LeagueData> GetLeagueData(IQuerySession runningDocumentSession, string seasonCode, string leagueCode)
        {
            var leagueData = await runningDocumentSession
                .Query<LeagueData>()
                .Where(l => l.LeagueCode == leagueCode && l.SeasonCodeRef == seasonCode)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (leagueData == null)
            {
                throw new ArgumentException($"No league exists with league code: {leagueCode} for season: {seasonCode}");
            }

            return leagueData;
        }

        private async Task<League> ReadLeague(string leagueCode)
        {
            using (var dbSession = _documentStore.QuerySession())
            {
                var leagueData = await dbSession
                    .Query<LeagueData>()
                    .Where(l => l.LeagueCode == leagueCode)
                    .SingleAsync()
                    .ConfigureAwait(false);

                // TODO: fill in other league data to API
                League apiLeague = new League
                {
                    LeagueCode = leagueData.LeagueCode,
                    LeagueTitle = leagueData.LeagueTitle
                };

                return apiLeague;
            }
        }

        private void SynchGamesAndPlayers(LeagueData leagueData)
        {
            // TODO: is this a pig with cartisian-o-rama?

            foreach ( var playerData in leagueData.Players )
            {
                if ( !leagueData.PlayerSeasonScores.Any(pss => pss.PlayerTagRef == playerData.PlayerTag) )
                {
                    leagueData.PlayerSeasonScores.Add(new PlayerScoreSubtotalData
                    {
                        PlayerTagRef = playerData.PlayerTag,
                        Points = 0
                    });
                }

                foreach ( var weekData in leagueData.Weeks )
                {
                    if (!weekData.PlayerWeekScores.Any(pws => pws.PlayerTagRef == playerData.PlayerTag))
                    {
                        weekData.PlayerWeekScores.Add(new PlayerScoreSubtotalData
                        {
                            PlayerTagRef = playerData.PlayerTag,
                            Points = 0
                        });
                    }

                    foreach (var gameData in weekData.Games)
                    {
                        if (!gameData.PlayerPicks.Any(pp => pp.PlayerTagRef == playerData.PlayerTag))
                        {
                            gameData.PlayerPicks.Add(new PlayerPickData
                            {
                                Pick = App.PickTypes.None,
                                PickStatus = App.PickStatuses.None,
                                PlayerTagRef = playerData.PlayerTag
                            });
                        }
                    }
                }
            }
        }

        private void SynchScoreboards(LeagueData leagueData)
        {
            var playerTags = leagueData.Players.Select(p => p.PlayerTag);

            // by week
            foreach ( var weekData in leagueData.Weeks )
            {
                foreach ( var playerTag in playerTags )
                {
                    var playerWeekScoreData = weekData.PlayerWeekScores.Single(pws => pws.PlayerTagRef == playerTag);
                    playerWeekScoreData.Points = weekData.Games.SelectMany(g => g.PlayerPicks.Where(pp => pp.PlayerTagRef == playerTag && pp.PickStatus == PickStatuses.Won)).Count();
                }
            }

            // whole season
            foreach (var playerTag in playerTags)
            {
                var playerSeasonScoreData = leagueData.PlayerSeasonScores.Single(pss => pss.PlayerTagRef == playerTag);
                playerSeasonScoreData.Points = leagueData.Weeks.SelectMany(w => w.Games.SelectMany(g => g.PlayerPicks.Where(pp => pp.PlayerTagRef == playerTag && pp.PickStatus == PickStatuses.Won))).Count();
            }
        }
    }
}
