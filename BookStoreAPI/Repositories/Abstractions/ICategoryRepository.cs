using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories.Abstractions
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(Guid id);
        Task<List<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task RemoveAsync(Category category);
        Task SaveChangesAsync();
        Task<Category?> GetCategoryByNameAsync(string name);
    }
}
