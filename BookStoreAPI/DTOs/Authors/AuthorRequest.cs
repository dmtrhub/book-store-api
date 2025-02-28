namespace BookStoreAPI.DTOs.Authors
{
    public record AuthorRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
    }
}
