using BookStoreAPI.Database;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BookStoreAPI.Repositories
{
    public class BookRepository(AppDbContext context) : IBookRepository
    {
        public async Task<Book?> GetByIdAsync(Guid id) =>
            await context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);

        public async Task<List<Book>> GetAllAsync() =>
            await context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();

        public async Task AddAsync(Book book) => await context.Books.AddAsync(book);

        public async Task UpdateAsync(Book book)
        {
            context.Books.Update(book);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Book book)
        {
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }            

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();

        public async Task<List<Book>> SearchBooksByTitleAsync(string title) =>
            await context.Books.Include(b => b.Author)
                               .Include(b => b.Category)
                               .AsSplitQuery()
                               .AsNoTracking()
                               .Where(b => b.Title.Contains(title)).ToListAsync();

        public async Task<List<Book>> SearchBooksByAuthorAsync(string authorName) =>
            await context.Books.Include(b => b.Author)
                               .Include(b => b.Category)
                               .AsSplitQuery()
                               .AsNoTracking()
                               .Where(b => b.Author.Name.Contains(authorName))
                               .ToListAsync();

        public async Task<List<Book>> SearchBooksByCategoryAsync(string categoryName) =>
            await context.Books.Include(b => b.Category)
                               .Include(b => b.Author)
                               .AsSplitQuery()
                               .AsNoTracking()
                               .Where(b => b.Category.Name.Contains(categoryName))
                               .ToListAsync();
    }
}