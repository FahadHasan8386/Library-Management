using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using LibraryManagement.Api.Model;

namespace LibraryManagement.Repositories
{
    public class BooksRepository
    {
        private readonly IDbConnection _connection;

        public BooksRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Books>> GetAllBooksAsync()
        {
            _connection.Open();
            var data = await _connection.QueryAsync<Books>("SELECT * FROM Books");
            _connection.Close();
            return data.ToList();
        }

       
        public async Task<int> AddBookAsync(Books book)
        {
            var sql = @"INSERT INTO Books (Title, Author, TotalCopies, AvailableCopies)
                        VALUES (@Title, @Author, @TotalCopies, @AvailableCopies)";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, book);
            _connection.Close();
            return result;
        }

        
        public async Task<int> DeleteBookAsync(long id)
        {
            var sql = @"DELETE FROM Books WHERE BookId = @Id";
            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new { Id = id });
            _connection.Close();
            return result;
        }

       
        public async Task<int> UpdateBookAsync(long id, Books book)
        {
            var sql = @"UPDATE Books 
                        SET Title = @Title, 
                            Author = @Author, 
                            TotalCopies = @TotalCopies, 
                            AvailableCopies = @AvailableCopies
                        WHERE BookId = @Id";

            _connection.Open();
            var result = await _connection.ExecuteAsync(sql, new
            {
                Id = id,
                book.Title,
                book.Author,
                book.TotalCopies,
                book.AvailableCopies
            });
            _connection.Close();

            return result;
        }

    }
}
