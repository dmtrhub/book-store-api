using Microsoft.Identity.Client;

namespace BookStoreAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer"; // Admin or Customer(default)
        public string? RefreshToken { get; set; }  
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
