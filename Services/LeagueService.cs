﻿using LigaHowden.Data.DomainModels;
using LigaHowden.Extensions;
using LigaHowden.Requests.ApiRequests;
using LigaHowden.Responses;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
using System.Text.Json;

namespace LigaHowden.Services
{
    public class LeagueService
    {
        private readonly ProtectedSessionStorage _sessionStorage;

        private readonly HttpClient _httpClient;

        public LeagueService([FromServices]ProtectedSessionStorage sessionStorage,
            [FromServices]HttpClient httpClient)
        {
            _sessionStorage = sessionStorage;
            _httpClient = httpClient;
        }
        public async Task<List<League>> GetLeaguesResponse()
        {
            var token = await _sessionStorage.GetAsync<string>("apiToken");
            _httpClient.DefaultRequestHeaders.Add("Authorization", token.Value);
            var response = await _httpClient.GetAsync("/api/collections/leagues/records");
            var content = await response.Content.ReadAsStringAsync();
            var leaguesResponse = JsonSerializer.Deserialize<LeaguesPocketBaseResponse>(content);
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
