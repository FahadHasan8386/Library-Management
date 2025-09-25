using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using LibraryManagement.Api.Model;
using static System.Net.Mime.MediaTypeNames;


namespace LibraryManagement.Repositories
{
    public class BooksRepository
    {
        public readonly IDbConnection _connection;

        public BooksRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Books>> GetAllBooksAsync()
        {
            var sql = @"SELECT * FROM Books";

            //if (_connection.State != ConnectionState.Open)
             _connection.Open();

            var data = await _connection.QueryAsync<Books>(sql);

            _connection.Close();
            return data.ToList();
        }

        public async Task<int> AddBookAsync(Books book)
        {
            var sql = @"INSERT INTO Books (Title, Author, TotalCopies, AvailableCopies)
                VALUES ( @Title, @Author, @TotalCopies, @AvailableCopies)";

            _connection.Open();

            var data = await _connection.ExecuteAsync(sql, new
            {
                @Title = book.Title,
                @Author = book.Author,
                @TotalCopies = book.TotalCopies,
                @AvailableCopies = book.AvailableCopies

            }); 
            _connection.Close();

            return data ;
        }
    }
}
