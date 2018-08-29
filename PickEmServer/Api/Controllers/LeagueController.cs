﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickEmServer.Api.Models;
using PickEmServer.Heart;

namespace PickEmServer.Api.Controllers
{
    [Produces("application/json")]
    public class LeagueController : Controller
    {
        private readonly LeagueService _leagueService;

        public LeagueController(LeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [Authorize]
        [HttpGet]
        [Route("api/{SeasonCode}/{LeagueCode}/scoreboard")]
        public async Task<LeagueScoreboard> GetScoreboard(string SeasonCode, string LeagueCode)
        {
            LeagueScoreboard leagueScoreboard = new LeagueScoreboard();

            leagueScoreboard.League = new League { LeagueCode = LeagueCode, LeagueTitle = "Burlington Mafia" };
            leagueScoreboard.Season = new Season { SeasonCode = SeasonCode, SeasonTitle = "This Season" };

            leagueScoreboard.PlayerScores = new List<PlayerSeasonScore>();

            PlayerSeasonScore playerSeasonScore;

            playerSeasonScore = new PlayerSeasonScore();
            playerSeasonScore.Player = new Player { PlayerTag = "bewwew" };
            playerSeasonScore.WeeklyScores = new List<WeekScore>();
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 1, Points = 5 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 2, Points = 7 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 3, Points = 8 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 4, Points = 14 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 5, Points = 5 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 6, Points = 7 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 7, Points = 7 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 8, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 9, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 10, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 11, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 12, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 13, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 14, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 15, Points = 0 });
            playerSeasonScore.Points = playerSeasonScore.WeeklyScores.Select(ws => ws.Points).Sum();
            leagueScoreboard.PlayerScores.Add(playerSeasonScore);

            playerSeasonScore = new PlayerSeasonScore();
            playerSeasonScore.Player = new Player { PlayerTag = "cush" };
            playerSeasonScore.WeeklyScores = new List<WeekScore>();
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 1, Points = 7 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 2, Points = 12 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 3, Points = 10 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 4, Points = 5 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 5, Points = 4 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 6, Points = 11 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 7, Points = 7 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 8, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 9, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 10, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 11, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 12, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 13, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 14, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 15, Points = 0 });
            playerSeasonScore.Points = playerSeasonScore.WeeklyScores.Select(ws => ws.Points).Sum();
            leagueScoreboard.PlayerScores.Add(playerSeasonScore);

            playerSeasonScore = new PlayerSeasonScore();
            playerSeasonScore.Player = new Player { PlayerTag = "kapieyow" };
            playerSeasonScore.WeeklyScores = new List<WeekScore>();
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 1, Points = 4 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 2, Points = 6 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 3, Points = 4 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 4, Points = 11 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 5, Points = 10 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 6, Points = 6 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 7, Points = 7 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 8, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 9, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 10, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 11, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 12, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 13, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 14, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 15, Points = 0 });
            playerSeasonScore.Points = playerSeasonScore.WeeklyScores.Select(ws => ws.Points).Sum();
            leagueScoreboard.PlayerScores.Add(playerSeasonScore);

            playerSeasonScore = new PlayerSeasonScore();
            playerSeasonScore.Player = new Player { PlayerTag = "kapieyow" };
            playerSeasonScore.WeeklyScores = new List<WeekScore>();
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 1, Points = 4 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 2, Points = 6 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 3, Points = 4 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 4, Points = 11 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 5, Points = 10 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 6, Points = 6 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 7, Points = 7 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 8, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 9, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 10, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 11, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 12, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 13, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 14, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 15, Points = 0 });
            playerSeasonScore.Points = playerSeasonScore.WeeklyScores.Select(ws => ws.Points).Sum();
            leagueScoreboard.PlayerScores.Add(playerSeasonScore);

            playerSeasonScore = new PlayerSeasonScore();
            playerSeasonScore.Player = new Player { PlayerTag = "samSpade" };
            playerSeasonScore.WeeklyScores = new List<WeekScore>();
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 1, Points = 6 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 2, Points = 4 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 3, Points = 8 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 4, Points = 11 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 5, Points = 9 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 6, Points = 4 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 7, Points = 7 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 8, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 9, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 10, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 11, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 12, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 13, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 14, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 15, Points = 0 });
            playerSeasonScore.Points = playerSeasonScore.WeeklyScores.Select(ws => ws.Points).Sum();
            leagueScoreboard.PlayerScores.Add(playerSeasonScore);

            playerSeasonScore = new PlayerSeasonScore();
            playerSeasonScore.Player = new Player { PlayerTag = "sigterm" };
            playerSeasonScore.WeeklyScores = new List<WeekScore>();
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 1, Points = 3 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 2, Points = 4 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 3, Points = 5 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 4, Points = 6 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 5, Points = 7 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 6, Points = 8 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 7, Points = 7 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 8, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 9, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 10, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 11, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 12, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 13, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 14, Points = 0 });
            playerSeasonScore.WeeklyScores.Add(new WeekScore { WeekNumber = 15, Points = 0 });
            playerSeasonScore.Points = playerSeasonScore.WeeklyScores.Select(ws => ws.Points).Sum();
            leagueScoreboard.PlayerScores.Add(playerSeasonScore);

            return leagueScoreboard;
        }

        [Authorize]
        [HttpGet]
        [Route("api/{SeasonCode}/{LeagueCode}/players")]
        public async Task<List<Player>> GetPlayers(string SeasonCode, string LeagueCode)
        {
            return await _leagueService.ReadLeaguePlayers(SeasonCode, LeagueCode);
        }

        [Authorize]
        [HttpPost]
        [Route("api/{SeasonCode}/{LeagueCode}/players")]
        public async Task<League> AddLeaguePlayer(string LeagueCode, [FromBody] LeaguePlayerAdd newLeaguePlayer)
        {
            return await _leagueService.AddLeaguePlayer(LeagueCode, newLeaguePlayer);
        }

        [Authorize]
        [HttpGet]
        [Route("api/{SeasonCode}/{LeagueCode}/weeks")]
        public async Task<List<int>> GetWeekNumbers(string SeasonCode, string LeagueCode)
        {
            return await _leagueService.ReadLeagueWeeks(SeasonCode, LeagueCode);
        }

        [Authorize]
        [HttpPost]
        [Route("api/{SeasonCode}/leagues")]
        public async Task<League> AddLeague(string SeasonCode, [FromBody] LeagueAdd newLeague)
        {
            return await _leagueService.AddLeague(SeasonCode,  newLeague);
        }

        [Authorize]
        [HttpPost]
        [Route("api/{SeasonCode}/{LeagueCode}/{weekNumber}/games")]
        public async Task<League> AddLeagueGame(string SeasonCode, string LeagueCode, int weekNumber, [FromBody] LeagueGameAdd newLeagueGame)
        {
            return await _leagueService.AddLeagueGame(SeasonCode, LeagueCode, weekNumber, newLeagueGame);
        }

       

    }
}