using BookStoreAPI.Database;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        public async Task AddAsync(Category category) => await context.Categories.AddAsync(category);

        public Task<List<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();

        public Task UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category?> GetCategoryByNameAsync(string name) =>
            await context.Categories.FirstOrDefaultAsync(c => c.Name == name);
    }
}
