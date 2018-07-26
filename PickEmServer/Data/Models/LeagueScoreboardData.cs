﻿using Marten.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickEmServer.Data.Models
{
    public class LeagueScoreboardData
    {
        [Identity]
        public int WeekScoreboardId { get; internal set; }

        public string SeasonCodeRef { get; internal set; }
        public string LeagueCodeRef { get; internal set; }
        public int WeekNumberRef { get; internal set; }

        public List<PlayerSeasonScoreData> PlayerScores { get; internal set; }
    }
}
