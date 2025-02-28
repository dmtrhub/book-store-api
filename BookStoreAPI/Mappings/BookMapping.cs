using BookStoreAPI.DTOs.Books;
using BookStoreAPI.Models;

namespace BookStoreAPI.Mappings
{
    public static class BookMapping
    {
        public static BookResponse ToDto(this Book book) => new(book.Id, book.Price)
        {
            Title = book.Title,
            Description = book.Description,
            AuthorName = book.Author.Name,
            CategoryName = book.Category.Name
        };

        public static Book ToDomain(this BookRequest dto, Guid authorId, Guid categoryId) => new()
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            AuthorId = authorId,
            CategoryId = categoryId
        };
    }
}
