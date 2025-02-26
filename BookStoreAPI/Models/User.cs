using Microsoft.Identity.Client;

namespace BookStoreAPI.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public string Role { get; set; } = "Customer"; // Admin or Customer(default)
        public string? RefreshToken { get; set; }  
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public ICollection<Order> Orders { get; set; } = [];
    }
}
