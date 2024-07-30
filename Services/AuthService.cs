using LigaHowden.Data;
using LigaHowden.Data.DomainModels;
using LigaHowden.Requests.ApiRequests;
using LigaHowden.Responses.ApiResponses;
using LigaHowden.Responses.DomainResponses;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace LigaHowden.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private User user { get; set; }

        private string token { get; set; }

        public AuthService([FromServices] HttpClient Http)
        {
            _http = Http;
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var response = await _http.PostAsJsonAsync("/api/collections/users/auth-with-password", loginRequest);
            //var authResponse = response;
            if (response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>(new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(authResponse.Token);

                user = new User
                {
                    Id = authResponse.Auth.Id,
                    Username = authResponse.Auth.Username,
                    Name = authResponse.Auth.Name,
                    Leagues = authResponse.Auth.Leagues
                };

                token = authResponse.Token;

                return new LoginResponse
                {
                    Token = authResponse.Token,
                    User = user
                };
            }
            throw new Exception(response.ReasonPhrase);
        }

        public async Task<User> User()
        {
            return user;
        }

        public async Task<string> Token()
        {
            return token;
        }
    }
}
