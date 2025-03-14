﻿using BookStoreAPI.DTOs;
using BookStoreAPI.DTOs.Books;
using BookStoreAPI.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IBookService bookService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<BookResponse>>> GetAll()
        {
            var books = await bookService.GetAllAsync();
            return books.Any() ? Ok(books) : NotFound("No books available.");
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookResponse>> GetById(Guid id)
        {
            var book = await bookService.GetByIdAsync(id);
            return book is null ? NotFound($"Book with ID {id} not found.") : Ok(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<BookResponse>> Create(BookRequest dto)
        {
            var createdBook = await bookService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, createdBook);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id ,BookRequest dto) =>
            await bookService.UpdateAsync(id, dto) ? NoContent() : NotFound($"Book with ID {id} not found.");

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id) =>
        await bookService.RemoveAsync(id) ? NoContent() : NotFound();

        [HttpGet("search")]
        public async Task<ActionResult<List<BookResponse>>> SearchBooksByTitle(string title)
        {
            var books = await bookService.SearchBooksByTitleAsync(title);
            return books.Any() ? Ok(books) : NotFound();
        }

        [HttpGet("by-author")]
        public async Task<ActionResult<List<BookResponse>>> SearchBooksByAuthor(string name)
        {
            var books = await bookService.SearchBooksByAuthorAsync(name);
            return books.Any() ? Ok(books) : NotFound();
        }

        [HttpGet("by-category")]
        public async Task<ActionResult<List<BookResponse>>> SearchBooksByCategory(string name)
        {
            var books = await bookService.SearchBooksByCategoryAsync(name);
            return books.Any() ? Ok(books) : NotFound();
        }
    }
}
