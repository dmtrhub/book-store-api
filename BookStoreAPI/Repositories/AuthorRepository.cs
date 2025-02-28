using BookStoreAPI.Database;
using BookStoreAPI.DTOs.Authors;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class AuthorRepository(AppDbContext context) : IAuthorRepository
    {
        public async Task AddAsync(Author author) => await context.Authors.AddAsync(author);

        public async Task<List<Author>> GetAllAsync() =>
            await context.Authors
                     .Include(a => a.Books)
                     .ThenInclude(b => b.Category) 
                     .AsSplitQuery()
                     .ToListAsync();

        public async Task<Author?> GetByIdAsync(Guid id) =>
            await context.Authors
                     .Include(a => a.Books)
                     .ThenInclude(b => b.Category)
                     .AsSplitQuery()
                     .FirstOrDefaultAsync(a => a.Id ==id);

        public async Task RemoveAsync(Author author)
        {
            context.Remove(author);
            await context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();

        public async Task UpdateAsync(Author author)
        {
            context.Authors.Attach(author);
            context.Entry(author).Property(a => a.Name).IsModified = true;
            context.Entry(author).Property(a => a.Biography).IsModified = true;

            await context.SaveChangesAsync();
        }

        public async Task<Author?> GetAuthorByNameAsync(string name) =>
            await context.Authors
                     .Include(a => a.Books)
                     .ThenInclude(b => b.Category)
                     .AsSplitQuery()
                     .FirstOrDefaultAsync(a => a.Name == name);

        public async Task<List<Author>> SearchAuthorsByNameAsync(string name) =>
            await context.Authors
                     .Include(a => a.Books)
                     .ThenInclude(b => b.Category)
                     .AsSplitQuery()
                     .Where(a => a.Name.Contains(name)).ToListAsync();

        public async Task<List<Author>> GetAuthorsByBookAsync(string title) =>
            await context.Authors
                    .Include(a => a.Books)
                    .ThenInclude(b => b.Category)
                    .AsSplitQuery()
                    .Where(a => a.Books.Any(b => b.Title.Contains(title)))
                    .ToListAsync();

        public async Task<List<Author>> GetAuthorsByCategoryAsync(string name) =>
            await context.Authors
                    .Include(a => a.Books)
                    .ThenInclude(b => b.Category)
                    .AsSplitQuery()
                    .Where(a => a.Books.Any(b => b.Category.Name.Contains(name)))
                    .ToListAsync();
    }
}
