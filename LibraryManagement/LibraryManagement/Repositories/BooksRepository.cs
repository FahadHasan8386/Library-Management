using System.Data;
using Dapper;
using LM.Api.EntityModels;
using LM.Api.Repositories.Interfaces;

namespace LM.Api.Repositories;

public class BooksRepository : IBooksRepository
{
    private readonly IDbConnection _connection;

    public BooksRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<Books>> ExecuteGetAllBooksAsync()
    {
        var sql = @"SELECT * FROM Books";

        _connection.Open();
        var books = await _connection.QueryAsync<Books>(sql);
        _connection.Close();
        var response = books.ToList();
        return response;
    }

    public async Task<Books?> ExecuteGetBookByIdAsync(long bookId)
    {
        var sql = @"SELECT * FROM Books WHERE BookId = @BookId";

        _connection.Open();
        var books = await _connection.QueryAsync<Books>(sql, new
        {
            @BookId = bookId
        });
        _connection.Close();
        var response = books.FirstOrDefault();
        return response;
    }

    public async Task<long> ExecuteCreateBookAsync(Books book)
    {
        var sql = @"INSERT INTO Books (Title, Author, TotalCopies, AvailableCopies)
                    VALUES (@Title, @Author, @TotalCopies, @TotalCopies)
                    SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";

        _connection.Open();
        var result = await _connection.ExecuteScalarAsync<long>(sql, new
        {
            @Title = book.Title,
            @Author = book.Author,
            @TotalCopies = book.TotalCopies
        });
        _connection.Close();
        return result;
    }

    public async Task<int> ExecuteUpdateBookAsync(Books book)
    {
        var sql = @"UPDATE Books 
                        SET Title = @Title, 
                            Author = @Author
                        WHERE BookId = @BookId";

        _connection.Open();
        var result = await _connection.ExecuteAsync(sql, new
        {
            @BookId = book.BookId,
            @Title = book.Title,
            @Author = book.Author
        });
        _connection.Close();
        return result;
    }

    public async Task<long> ExecuteRentBookAsync(BookRents bookRents)
    {
        var sql = @"INSERT INTO BookRents (BookId, RentFromDate)
                    VALUES (@BookId, @RentFromDate)

                    UPDATE Books
                    SET AvailableCopies = AvailableCopies - 1
                    WHERE BookId = @BookId";

        _connection.Open();
        var result = await _connection.ExecuteScalarAsync<long>(sql, new
        {
            @BookId = bookRents.BookId,
            @RentFromDate = bookRents.RentFromDate
        });
        _connection.Close();
        return result;
    }

    public async Task<int> ExecuteReturnBookAsync(BookRents bookRents)
    {
        var sql = @"UPDATE BookRents
                    SET RentToDate
                    WHERE BookRentId = @BookRentId AND BookId = @BookId

                    UPDATE Books
                    SET AvailableCopies = AvailableCopies + 1
                    WHERE BookId = @BookId";

        _connection.Open();
        var result = await _connection.ExecuteAsync(sql, new
        {
            @BookId = bookRents.BookId,
            @RentFromDate = bookRents.RentFromDate
        });
        _connection.Close();
        return result;
    }

    public async Task<int> ExecuteDeleteBookAsync(long bookId)
    {
        var sql = @"DELETE FROM Books WHERE BookId = @BookId";

        _connection.Open();
        var result = await _connection.ExecuteAsync(sql, new
        {
            @BookId = bookId
        });
        _connection.Close();
        return result;
    }
}
