using BookStoreAPI.DTOs.Authors;
using BookStoreAPI.Mappings;
using BookStoreAPI.Repositories.Abstractions;
using BookStoreAPI.Services.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookStoreAPI.Services
{
    public class AuthorService(IAuthorRepository authorRepository) : IAuthorService
    {
        public async Task<AuthorResponse> CreateAsync(AuthorRequest request)
        {
            var author = request.ToDomain();

            await authorRepository.AddAsync(author);
            await authorRepository.SaveChangesAsync();

            return author.ToDto();
        }

        public async Task<List<AuthorResponse>> GetAllAsync()
        {
            var authors = await authorRepository.GetAllAsync();
            return authors.Select(a => a.ToDto()).ToList();
        }

        public async Task<AuthorResponse?> GetByIdAsync(Guid id)
        {
            var author = await authorRepository.GetByIdAsync(id);
            return author?.ToDto();
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var author = await authorRepository.GetByIdAsync(id);
            if (author is null)
                return false;

            await authorRepository.RemoveAsync(author);
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, AuthorRequest request)
        {
            var author = await authorRepository.GetByIdAsync(id);
            if (author is null)
                return false;

            author.Name = request.Name;
            author.Biography = request.Biography;

            await authorRepository.UpdateAsync(author);
            return true;
        }

        public async Task<List<AuthorResponse>> SearchAuthorsByNameAsync(string name)
        {
            var authors = await authorRepository.SearchAuthorsByNameAsync(name);
            return authors.Select(a => a.ToDto()).ToList();
        }

        public async Task<List<AuthorResponse>> GetAuthorByBookAsync(string title)
        {
            var authors = await authorRepository.GetAuthorsByBookAsync(title);
            return authors.Select(a => a.ToDto()).ToList();
        }

        public async Task<List<AuthorResponse>> GetAuthorsByCategoryAsync(string name)
        {
            var authors = await authorRepository.GetAuthorsByCategoryAsync(name);
            return authors.Select(a => a.ToDto()).ToList();
        }
    }
}
