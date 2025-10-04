using LM.Api.Services.Interfaces;
using LM.Shared.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace LM.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    public readonly IBookService _BookService;

    public BooksController(IBookService bookService)
    {
        _BookService = bookService;
    }

    [HttpGet("GetBooks")]
    public async Task<IActionResult> GetAllBooksAsync()
    {
        return Ok(await _BookService.GetAllBooksAsync());
    }

    [HttpGet("GetBookById/{bookId}")]
    public async Task<IActionResult> GetBookByIdAsync([FromRoute] long bookId)
    {
        return Ok(await _BookService.GetBookByIdAsync(bookId));
    }

    [HttpPost("NewBook")]
    public async Task<IActionResult> NewBookAsync([FromBody] BookDto bookDto)
    {
        return Ok(await _BookService.CreateBookAsync(bookDto));
    }

    [HttpPut("UpdateBook")]
    public async Task<IActionResult> UpdateBookAsync([FromBody] BookDto bookDto)
    {
        var result = await _BookService.UpdateBookAsync(bookDto);
        return Ok(result);
    }

    [HttpDelete("DeleteBook/{id}")]
    public async Task<IActionResult> DeleteBookAsync([FromRoute] long id)
    {
        var result = await _BookService.DeleteBookAsync(id);
        return Ok(result);
    }

}