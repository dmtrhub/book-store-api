using BookStoreAPI.DTOs.Authors;
using BookStoreAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController(IAuthorService authorService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<AuthorResponse>>> GetAll()
        {
            var authors = await authorService.GetAllAsync();
            return authors.Any() ? Ok(authors) : NotFound("No authors available.");
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AuthorResponse>> GetById(Guid id)
        {
            var author = await authorService.GetByIdAsync(id);
            return author is not null ? Ok(author) : NotFound($"Author with ID {id} not found.");
        }

        [HttpPost]
        public async Task<ActionResult<AuthorResponse>> Create(AuthorRequest request)
        {
            var author = await authorService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = author.Id}, author);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, AuthorRequest request) =>
            await authorService.UpdateAsync(id, request) ? NoContent() : NotFound($"Author with ID {id} not found.");

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id) =>
            await authorService.RemoveAsync(id) ? NoContent() : NotFound($"Author with ID {id} not found.");

        [HttpGet("search")]
        public async Task<ActionResult<List<AuthorResponse>>> SearchAuthorsByName(string name)
        {
            var authors = await authorService.SearchAuthorsByNameAsync(name);
            return authors.Any() ? Ok(authors) : NotFound($"No authors found with name {name}.");
        }

        [HttpGet("search/by-book")]
        public async Task<ActionResult<List<AuthorResponse>>> GetAuthorsByBook(string title)
        {
            var authors = await authorService.GetAuthorsByBookAsync(title);
            return authors.Any() ? Ok(authors) : NotFound($"No authors found with book title {title}.");
        }

        [HttpGet("search/by-category")]
        public async Task<ActionResult<List<AuthorResponse>>> GetAuthorsByCategory(string name)
        {
            var authors = await authorService.GetAuthorsByCategoryAsync(name);
            return authors.Any() ? Ok(authors) : NotFound($"No authors found with category name {name}.");
        }
    }
}
