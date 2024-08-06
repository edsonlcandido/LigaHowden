using System.Text.Json;
using LigaHowden.Data.DomainModels;

namespace LigaHowden.Services
{
    public class TeamService{
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;
        public TeamService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("LigaHowdenClient");
        }
        public async Task<List<Team>> GetTeamsList(string[] teams){
            var teamsList = new List<Team>();
            foreach (var team in teams)
            {
                var teamResponse = await GetTeam(team);
                teamsList.Add(teamResponse);
            }
            return teamsList;
        }

        private async Task<Team> GetTeam(string id)
        {
            var requestMessage = new HttpRequestMessage();
            requestMessage.Method = HttpMethod.Get;
            requestMessage.RequestUri = new Uri($"/api/collections/teams/records/{id}", UriKind.Relative);

            var response = await _httpClient.SendAsync(requestMessage);

            var content = await response.Content.ReadAsStringAsync();
            var teamResponse = JsonSerializer.Deserialize<TeamResponse>(content);
            var team = new Team()
            {
                Id = teamResponse.Id,
                Name = teamResponse.Name,
                Slug = teamResponse.Slug,
                Cartola = teamResponse.Cartola
            };
            return team;            
        }
    }
}