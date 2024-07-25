﻿namespace LigaHowden.Data
{
    public class LeaguesResponse
    {
        public LeaguesResponse()
        {
            Leagues = new List<League>();
            Leagues.Add(new League { Id = "1", Name = "Liga MX", Slug = "liga-mx" });
            Leagues.Add(new League { Id = "2", Name = "MLS", Slug = "mls" });
            Leagues.Add(new League { Id = "3", Name = "Premier League", Slug = "premier-league" });
            Leagues.Add(new League { Id = "4", Name = "La Liga", Slug = "la-liga" });

        }
        public List<League> Leagues { get; set; }

    }

    public class LeagueService
    {
        public LeaguesResponse GetLeaguesResponse()
        {
            return new LeaguesResponse();
        }
    }

    public class League
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

    }
}
