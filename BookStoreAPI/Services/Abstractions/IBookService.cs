using BookStoreAPI.DTOs;
using BookStoreAPI.DTOs.Books;

namespace BookStoreAPI.Services.Abstractions
{
    public interface IBookService
    {
        Task<BookResponse> CreateAsync(BookRequest request);
        Task<List<BookResponse>> GetAllAsync();
        Task<BookResponse?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, BookRequest request);
        Task<bool> RemoveAsync(Guid id);
        Task<List<BookResponse>> SearchBooksByTitleAsync(string title);
        Task<List<BookResponse>> SearchBooksByAuthorAsync(string authorName);
        Task<List<BookResponse>> SearchBooksByCategoryAsync(string categoryName);
    }
}
