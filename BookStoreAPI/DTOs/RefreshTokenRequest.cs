﻿namespace BookStoreAPI.DTOs
{
    public class RefreshTokenRequest
    {
        public Guid UserId { get; set; }
        public required string RefreshToken { get; set; }
    }
}
