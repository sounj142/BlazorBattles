﻿namespace BlazorBattles.Server.Entities
{
    public class UserUnit
    {
        public int UserId { get; set; }
        public int UnitId { get; set; }
        public int HitPoints { get; set; }

        public Unit Unit { get; set; }
    }
}
