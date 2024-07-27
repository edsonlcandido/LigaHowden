using LigaHowden.Data;
using LigaHowden.Extensions;
using LigaHowden.Requests;
using LigaHowden.Responses;

namespace LigaHowden.Services
{
    public class LeagueService
    {
        public LeaguesResponse GetLeaguesResponse()
        {
            return new LeaguesResponse();
        }

        public async Task<League> CreateLeague(LeagueCreateRequest leagueCreateRequest)
        {
            await Task.Delay(1000);
            return new League
            {
                Id = "5",
                Name = leagueCreateRequest.Name,
                Slug = leagueCreateRequest.Name.Slugify()
            };
        }
    }
}
