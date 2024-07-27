using LigaHowden.Data;
using Microsoft.AspNetCore.Mvc;

namespace LigaHowden.Responses
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
}
