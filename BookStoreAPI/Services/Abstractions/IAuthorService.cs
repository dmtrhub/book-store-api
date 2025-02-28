using BookStoreAPI.DTOs.Authors;

namespace BookStoreAPI.Services.Abstractions
{
    public interface IAuthorService
    {
        Task<AuthorResponse> CreateAsync(AuthorRequest request);
        Task<List<AuthorResponse>> GetAllAsync();
        Task<AuthorResponse?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, AuthorRequest request);
        Task<bool> RemoveAsync(Guid id);
        Task<List<AuthorResponse>> SearchAuthorsByNameAsync(string name);
        Task<List<AuthorResponse>> GetAuthorsByBookAsync(string title);
        Task<List<AuthorResponse>> GetAuthorsByCategoryAsync(string name);
    }
}
