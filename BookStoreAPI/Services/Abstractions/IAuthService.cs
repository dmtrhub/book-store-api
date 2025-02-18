using BookStoreAPI.DTOs;
using BookStoreAPI.Models;

namespace BookStoreAPI.Services.Abstractions
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(RegisterRequest request);
        Task<TokenResponse?> LoginAsync(LoginRequest request);
        Task<bool> AssignAdminRoleAsync(AssignAdminRequest email);
        Task<TokenResponse?> RefreshTokensAsync(RefreshTokenRequest request);
    }
}
