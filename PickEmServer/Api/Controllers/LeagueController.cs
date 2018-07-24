﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickEmServer.Api.Models;

namespace PickEmServer.Api.Controllers
{
    [Produces("application/json")]
    public class LeagueController : Controller
    {
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
    }
}