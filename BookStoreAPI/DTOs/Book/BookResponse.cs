namespace BookStoreAPI.DTOs.Book
{
    public record BookResponse(Guid Id, decimal Price)
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }
}
