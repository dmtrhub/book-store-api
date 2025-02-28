using BookStoreAPI.DTOs.Authors;
using BookStoreAPI.DTOs.Books;
using BookStoreAPI.Models;

namespace BookStoreAPI.Mappings
{
    public static class AuthorMapping
    {
        public static Author ToDomain(this AuthorRequest dto)
        {
            return new Author
            {
                Name = dto.Name,
                Biography = dto.Biography,
                Books = []
            };
        }

        public static AuthorResponse ToDto(this Author author)
        {
            return new AuthorResponse(author.Id)
            {
                Name = author.Name,
                Biography = author.Biography,
                Books = author.Books?.Select(b => b.ToDto()).ToList() ?? []
            };
        }
    }
}
