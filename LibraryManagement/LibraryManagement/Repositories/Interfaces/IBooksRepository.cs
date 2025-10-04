using LM.Api.EntityModels;

namespace LM.Api.Repositories.Interfaces;

public interface IBooksRepository
{
    Task<List<Books>> ExecuteGetAllBooksAsync();
    Task<Books?> ExecuteGetBookByIdAsync(long bookId);
    Task<long> ExecuteCreateBookAsync(Books book);
    Task<int> ExecuteUpdateBookAsync(Books book);
    Task<long> ExecuteRentBookAsync(BookRents bookRents);
    Task<int> ExecuteReturnBookAsync(BookRents bookRents);
    Task<int> ExecuteDeleteBookAsync(long bookId);
}
