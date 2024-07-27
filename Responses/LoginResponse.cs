﻿using LigaHowden.Data;

namespace LigaHowden.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public User User { get; set; } = new User();
    }
}