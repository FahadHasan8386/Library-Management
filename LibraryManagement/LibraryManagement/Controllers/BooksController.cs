using LibraryManagement.Api.Model;
using LibraryManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public readonly BooksRepository _BooksRepository;

        public BooksController(BooksRepository booksRepository)
        {
            _BooksRepository = booksRepository;
        }

        [HttpGet("GetAllBooks")] 
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var data = await _BooksRepository.GetAllBooksAsync();
            return Ok(data);
        }

        [HttpPost("AddBooks")]
        public async Task<IActionResult> AddBooksAsync([FromBody] Books book)
        {
            var result = await _BooksRepository.AddBookAsync(book);

            if (result >= 0)
            {
                return Ok("Book added successfully");
            }
            else
            {
                return BadRequest("Failed to add the book!");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookAsync(long id, [FromBody] Books book)
        {
            var result = await _BooksRepository.UpdateBookAsync(id, book);
            return result > 0 ? Ok("Book updated successfully.") : NotFound("Book not found.");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsync(long id)
        {
            var result = await _BooksRepository.DeleteBookAsync(id);
            return result > 0 ? Ok("Book deleted successfully.") : NotFound("Book not found.");
        }



    }
}