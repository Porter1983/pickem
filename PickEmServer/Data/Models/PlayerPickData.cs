﻿using PickEmServer.App;

namespace PickEmServer.Data.Models
{
    public class PlayerPickData
    {
        public string PlayerTagRef { get; set; }
        public PickTypes Pick { get; set; }
        public PickStatuses PickStatus { get; set; }
    }
}
