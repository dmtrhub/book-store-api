using BookStoreAPI.Database;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class AuthorRepository(AppDbContext context) : IAuthorRepository
    {
        public async Task AddAsync(Author author) => await context.Authors.AddAsync(author);

        public Task<List<Author>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Author?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();

        public Task UpdateAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public async Task<Author?> GetAuthorByNameAsync(string name) =>
            await context.Authors.FirstOrDefaultAsync(a => a.Name == name);
    }
}
