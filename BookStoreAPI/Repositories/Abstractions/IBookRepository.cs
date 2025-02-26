using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories.Abstractions
{
    public interface IBookRepository 
    {
        Task<Book?> GetByIdAsync(Guid id);
        Task<List<Book>> GetAllAsync();
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task RemoveAsync(Book book);
        Task SaveChangesAsync();
        Task<List<Book>> SearchBooksByTitleAsync(string title);
        Task<List<Book>> SearchBooksByAuthorAsync(string authorName);
        Task<List<Book>> SearchBooksByCategoryAsync(string categoryName);
    }
}
