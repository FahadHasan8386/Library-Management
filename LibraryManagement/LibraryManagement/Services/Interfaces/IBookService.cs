using LM.Api.EntityModels;
using LM.Shared;
using LM.Shared.DtoModels;

namespace LM.Api.Services.Interfaces;

public interface IBookService
{
    Task<List<Books>> GetAllBooksAsync();
    Task<Books?> GetBookByIdAsync(long bookId);
    Task<ResponseViewModel> CreateBookAsync(BookDto bookDto);
    Task<ResponseViewModel> UpdateBookAsync(BookDto bookDto);
    Task<ResponseViewModel> RentBookAsync(BookRentDto bookRentDto);
    Task<ResponseViewModel> ReturnBookAsync(BookRentDto bookRentDto);
    Task<ResponseViewModel> DeleteBookAsync(long bookId);
}
