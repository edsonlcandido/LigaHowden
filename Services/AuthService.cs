using LigaHowden.Data;
using LigaHowden.Data.DomainModels;
using LigaHowden.Requests.ApiRequests;
using LigaHowden.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LigaHowden.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthService([FromServices]HttpClient Http) 
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

                return new LoginResponse
                {
                    Token = authResponse.Token,
                    User = new User
                    {
                        Id = authResponse.Auth.Id,
                        Username = authResponse.Auth.Username,
                        Name = authResponse.Auth.Name,
                        Leagues = authResponse.Auth.Leagues
                    }
                };                
            }
            throw new Exception(response.ReasonPhrase);
        }
    }
}
