using LibraryManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

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
            var data = await _BooksRepository.GetAllTestsAsync();
            return Ok(data);
        }

    }
}
