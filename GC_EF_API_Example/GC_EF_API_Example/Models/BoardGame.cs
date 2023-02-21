﻿namespace GC_EF_API_Example.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int YearPublished { get; set; }
        public int RecommendedPlayerCount { get; set; }
    }
}
