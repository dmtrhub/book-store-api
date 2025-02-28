using BookStoreAPI.DTOs.Books;

namespace BookStoreAPI.DTOs.Authors
{
    public record AuthorResponse(Guid Id)
    {
        public string Name { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;

        public List<BookResponse> Books { get; set; } = [];
    }
}
