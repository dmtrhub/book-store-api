using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories.Abstractions
{
    public interface IAuthorRepository
    {
        Task<Author?> GetByIdAsync(Guid id);
        Task<List<Author>> GetAllAsync();
        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task RemoveAsync(Author author);
        Task SaveChangesAsync();
        Task<Author?> GetAuthorByNameAsync(string name);
    }
}
