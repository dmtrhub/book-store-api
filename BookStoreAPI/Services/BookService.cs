using BookStoreAPI.DTOs;
using BookStoreAPI.DTOs.Books;
using BookStoreAPI.Mappings;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories.Abstractions;
using BookStoreAPI.Services.Abstractions;

namespace BookStoreAPI.Services
{
    public class BookService(IBookRepository bookRepository,
                             IAuthorRepository authorRepository,
                             ICategoryRepository categoryRepository) : IBookService
    {
        public async Task<List<BookResponse>> GetAllAsync()
        {
            var books = await bookRepository.GetAllAsync();
            return books.Select(book => book.ToDto()).ToList();
        }

        public async Task<BookResponse?> GetByIdAsync(Guid id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            return book is null ? null : book.ToDto();
        }

        public async Task<BookResponse> CreateAsync(BookRequest request)
        {
            var author = await EnsureAuthorExistsAsync(request.AuthorName);
            var category = await EnsureCategoryExistsAsync(request.CategoryName);

            var book = request.ToDomain(author.Id, category.Id);

            await bookRepository.AddAsync(book);
            await bookRepository.SaveChangesAsync();

            return book.ToDto();
        }
        
        public async Task<bool> UpdateAsync(Guid id, BookRequest request)
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book is null)
                return false;

            var author = await EnsureAuthorExistsAsync(request.AuthorName);
            var category = await EnsureCategoryExistsAsync(request.CategoryName);

            var updatedBook = request.ToDomain(author.Id, category.Id);
            updatedBook.Id = id;

            await bookRepository.UpdateAsync(updatedBook);
            return true;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book is null)
                return false;

            await bookRepository.RemoveAsync(book);
            return true;
        }

        public async Task<List<BookResponse>> SearchBooksByTitleAsync(string title)
        {
            var books = await bookRepository.SearchBooksByTitleAsync(title);
            return books.Select(book => book.ToDto()).ToList();
        }

        public async Task<List<BookResponse>> SearchBooksByAuthorAsync(string authorName)
        {
            var books = await bookRepository.SearchBooksByAuthorAsync(authorName);
            return books.Select(book => book.ToDto()).ToList();
        }

        public async Task<List<BookResponse>> SearchBooksByCategoryAsync(string categoryName)
        {
            var books = await bookRepository.SearchBooksByCategoryAsync(categoryName);
            return books.Select(book => book.ToDto()).ToList();
        }

        private async Task<Category> EnsureCategoryExistsAsync(string name)
        {
            var category = await categoryRepository.GetCategoryByNameAsync(name);
            if (category is null)
            {
                category = new Category { Id = Guid.NewGuid(), Name = name };
                await categoryRepository.AddAsync(category);
                await categoryRepository.SaveChangesAsync();
            }

            return category;
        }

        private async Task<Author> EnsureAuthorExistsAsync(string name)
        {
            var author = await authorRepository.GetAuthorByNameAsync(name);
            if (author is null)
            {
                author = new Author { Id = Guid.NewGuid(), Name = name };
                await authorRepository.AddAsync(author);
                await authorRepository.SaveChangesAsync();
            }

            return author;
        }       
    }
}
