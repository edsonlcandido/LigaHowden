using LigaHowden.Data.DomainModels;
using LigaHowden.Extensions;
using LigaHowden.Requests.ApiRequests;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using LigaHowden.Responses.ApiResponses;
using LigaHowden.Responses.DomainResponses;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace LigaHowden.Services
{
    public class LeagueService
    {
        private ProtectedSessionStorage _sessionStorage;
        private HttpClient _httpClient;
        private HttpRequestMessage requestMessage; 
        private string token { get; set; }  = string.Empty;

        public LeagueService(ProtectedSessionStorage sessionStorage,
            IHttpClientFactory httpClientFactory)
        {
            _sessionStorage = sessionStorage;            
            _httpClient = httpClientFactory.CreateClient("LigaHowdenClient");            
        }

        public async Task<List<League>> GetLeaguesList(string apiToken)
        {
            requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Add("Authorization", apiToken);
            requestMessage.Method = HttpMethod.Get;
            requestMessage.RequestUri = new Uri("/api/collections/leagues/records", UriKind.Relative);

            var response = await _httpClient.SendAsync(requestMessage);

            var content = await response.Content.ReadAsStringAsync();
            var leaguesResponse = JsonSerializer.Deserialize<LeaguesListResponse>(content);
            var leagues = leaguesResponse.Items.Select(Item => new League()
            {
                Id = Item.Id,
                Name = Item.Name,
                Slug = Item.Slug
            }).ToList();
            return leagues;
        }

        public async Task<List<League>> GetLeaguesList()
        {
            Console.WriteLine($"GetLeaguesList HttpClient InstanceId: {_httpClient.GetInstanceId()}");
            //_httpClient.DefaultRequestHeaders.Add("Authorization", token.Value);
            //if (_httpClient.DefaultRequestHeaders.Authorization == null)
            //{
            //    var token = await _sessionStorage.GetAsync<string>("apiToken");
            //    var token = await _authService.Token();
            //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            //}
            requestMessage = new HttpRequestMessage();
            if (this.token =="")
            {
                var tokenResult = await _sessionStorage.GetAsync<string>("apiToken");
                this.token = tokenResult.Value;
            }            
            requestMessage.Headers.Add("Authorization", token);
            requestMessage.Method = HttpMethod.Get;
            requestMessage.RequestUri = new Uri("/api/collections/leagues/records", UriKind.Relative);

            var response = await _httpClient.SendAsync(requestMessage);

            var content = await response.Content.ReadAsStringAsync();
            var leaguesResponse = JsonSerializer.Deserialize<LeaguesListResponse>(content);
            var leagues = leaguesResponse.Items.Select(Item => new League()
            {
                Id = Item.Id,
                Name = Item.Name,
                Slug = Item.Slug
            }).ToList();
            return leagues;
        }

        public async Task<League> CreateLeague(LeagueCreateRequest leagueCreateRequest)
        {
            //_httpClient.DefaultRequestHeaders.Add("Authorization", token.Value);
            //if (_httpClient.DefaultRequestHeaders.Authorization == null)
            //{
            //var token = await _sessionStorage.GetAsync<string>("apiToken");
            //var token = await _authService.Token();
            //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            //}
            Console.WriteLine($"CreateLeague HttpClient InstanceId: {_httpClient.GetInstanceId()}");

            requestMessage = new HttpRequestMessage();
            if (this.token == "")
            {
                var tokenResult = await _sessionStorage.GetAsync<string>("apiToken");
                this.token = tokenResult.Value;
            }
            requestMessage.Headers.Add("Authorization", token);
            requestMessage.Method = HttpMethod.Post;
            requestMessage.RequestUri = new Uri("/api/collections/leagues/records", UriKind.Relative);
            requestMessage.Content = JsonContent.Create(leagueCreateRequest);

            var response = await _httpClient.SendAsync(requestMessage);

            var content = await response.Content.ReadAsStringAsync();
            var leagueResponse = JsonSerializer.Deserialize<LeagueCreateResponse>(content);
            return new League()
            {
                Id = leagueResponse.Id,
                Name = leagueResponse.Name,
                Slug = leagueResponse.Slug
            };
        }

        public async Task<League> CreateLeague(LeagueCreateRequest leagueCreateRequest, string apiToken)
        {
            requestMessage = new HttpRequestMessage();

            requestMessage.Headers.Add("Authorization", apiToken);
            requestMessage.Method = HttpMethod.Post;
            requestMessage.RequestUri = new Uri("/api/collections/leagues/records", UriKind.Relative);
            requestMessage.Content = JsonContent.Create(leagueCreateRequest);

            var response = await _httpClient.SendAsync(requestMessage);

            var content = await response.Content.ReadAsStringAsync();
            var leagueResponse = JsonSerializer.Deserialize<LeagueCreateResponse>(content);
            return new League()
            {
                Id = leagueResponse.Id,
                Name = leagueResponse.Name,
                Slug = leagueResponse.Slug
            };
        }

        internal async Task<string> DeleteLeague(string id)
        {
            requestMessage = new HttpRequestMessage();
            if (this.token == "")
            {
                var tokenResult = await _sessionStorage.GetAsync<string>("apiToken");
                this.token = tokenResult.Value;
            }
            requestMessage.Headers.Add("Authorization", token);
            requestMessage.Method = HttpMethod.Delete;
            requestMessage.RequestUri = new Uri($"/api/collections/leagues/records/{id}", UriKind.Relative);

            var response = await _httpClient.SendAsync(requestMessage);
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return "liga deletada";
            }
            return "liga não deletada";

        }
        internal async Task<string> DeleteLeague(string id, string apiToken)
        {
            requestMessage = new HttpRequestMessage();
            requestMessage.Headers.Add("Authorization", apiToken);
            requestMessage.Method = HttpMethod.Delete;
            requestMessage.RequestUri = new Uri($"/api/collections/leagues/records/{id}", UriKind.Relative);

            var response = await _httpClient.SendAsync(requestMessage);
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return "liga deletada";
            }
            return "liga não deletada";

        }
    }
}
