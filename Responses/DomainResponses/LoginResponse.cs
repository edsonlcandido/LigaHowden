﻿using LigaHowden.Data.DomainModels;

namespace LigaHowden.Responses.DomainResponses
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public User User { get; set; } = new User();
    }
}