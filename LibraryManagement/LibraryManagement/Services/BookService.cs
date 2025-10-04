using LM.Api.EntityModels;
using LM.Api.Repositories.Interfaces;
using LM.Api.Services.Interfaces;
using LM.Shared;
using LM.Shared.DtoModels;

namespace LM.Api.Services;

public class BookService : IBookService
{
    private readonly IBooksRepository _BookRepository;
    public BookService(IBooksRepository booksRepository)
    {
        _BookRepository = booksRepository;
    }

    public async Task<List<Books>> GetAllBooksAsync()
    {
        var request = await _BookRepository.ExecuteGetAllBooksAsync();
        return request;
    }

    public async Task<Books?> GetBookByIdAsync(long bookId)
    {
        var request = await _BookRepository.ExecuteGetBookByIdAsync(bookId);
        return request;
    }

    public async Task<ResponseViewModel> CreateBookAsync(BookDto bookDto)
    {
        try
        {
            if (bookDto is not null)
            {
                Books book = new Books
                {
                    Title = bookDto.Title,
                    Author = bookDto.Author,
                    TotalCopies = bookDto.TotalCopies
                };
                var request = await _BookRepository.ExecuteCreateBookAsync(book);
                if (request > 0)
                {
                    return new ResponseViewModel
                    {
                        ResponseCode = 200,
                        ResponseMessage = "New book is created successfully."
                    };
                }
                else
                {
                    return new ResponseViewModel
                    {
                        ResponseCode = 500,
                        ResponseMessage = "Internal server error, Try again."
                    };
                }
            }
            else
            {
                return new ResponseViewModel
                {
                    ResponseCode = 400,
                    ResponseMessage = $"Bad request."
                };
            }
        }
        catch (Exception ex)
        {
            return new ResponseViewModel
            {
                ResponseCode = 500,
                ResponseMessage = ex.Message.ToString()
            };
        }
    }

    public async Task<ResponseViewModel> UpdateBookAsync(BookDto bookDto)
    {
        try
        {
            if (bookDto is not null && bookDto.BookId > 0)
            {
                var book = await _BookRepository.ExecuteGetBookByIdAsync(bookDto.BookId);
                if (book is null)
                {
                    return new ResponseViewModel
                    {
                        ResponseCode = 404,
                        ResponseMessage = $"Book is not found. Book ID: {bookDto.BookId}"
                    };
                }
                Books books = new Books
                {
                    BookId = bookDto.BookId,
                    Title = bookDto.Title,
                    Author = bookDto.Author
                };
                var request = await _BookRepository.ExecuteUpdateBookAsync(books);
                if (request > 0)
                {
                    return new ResponseViewModel
                    {
                        ResponseCode = 200,
                        ResponseMessage = "The book rent request is successfull."
                    };
                }
                else
                {
                    return new ResponseViewModel
                    {
                        ResponseCode = 500,
                        ResponseMessage = "Internal server error, Try again."
                    };
                }
            }
            else
            {
                return new ResponseViewModel
                {
                    ResponseCode = 400,
                    ResponseMessage = $"Bad request."
                };
            }
        }
        catch (Exception ex)
        {
            return new ResponseViewModel
            {
                ResponseCode = 500,
                ResponseMessage = ex.Message.ToString()
            };
        }
    }

    public async Task<ResponseViewModel> RentBookAsync(BookRentDto bookRentDto)
    {
        try
        {
            if (bookRentDto is not null && bookRentDto.BookId > 0)
            {
                var book = await _BookRepository.ExecuteGetBookByIdAsync(bookRentDto.BookId);
                if (book is null)
                {
                    return new ResponseViewModel
                    {
                        ResponseCode = 404,
                        ResponseMessage = $"Book is not found. Book ID: {bookRentDto.BookId}"
                    };
                }

                BookRents bookRent = new BookRents
                {
                    BookId = bookRentDto.BookId,
                    RentFromDate = bookRentDto.RentFromDate
                };
                var request = await _BookRepository.ExecuteRentBookAsync(bookRent);
                if (request > 0)
                {
                    return new ResponseViewModel
                    {
                        ResponseCode = 200,
                        ResponseMessage = "The book rent request is successfull."
                    };
                }
                else
                {
                    return new ResponseViewModel
                    {
                        ResponseCode = 500,
                        ResponseMessage = "Internal server error, Try again."
                    };
                }
            }
            else
            {
                return new ResponseViewModel
                {
                    ResponseCode = 400,
                    ResponseMessage = $"Bad request."
                };
            }
        }
        catch (Exception ex)
        {
            return new ResponseViewModel
            {
                ResponseCode = 500,
                ResponseMessage = ex.Message.ToString()
            };
        }
    }

    public async Task<ResponseViewModel> ReturnBookAsync(BookRentDto bookRentDto)
    {
        try
        {
            if (bookRentDto is not null && bookRentDto.BookRentId > 0 && bookRentDto.BookId > 0)
            {
                var book = await _BookRepository.ExecuteGetBookByIdAsync(bookRentDto.BookId);
                if (book is null)
                {
                    return new ResponseViewModel
                    {
                        ResponseCode = 404,
                        ResponseMessage = $"Book is not found. Book ID: {bookRentDto.BookId}"
                    };
                }

                BookRents bookRent = new BookRents
                {
                    BookRentId = bookRentDto.BookRentId,
                    BookId = bookRentDto.BookId,
                    RentToDate = bookRentDto.RentToDate is not null ? Convert.ToDateTime(bookRentDto.RentToDate) : DateTime.Now
                };
                var request = await _BookRepository.ExecuteReturnBookAsync(bookRent);
                if (request > 0)
                {
                    return new ResponseViewModel
                    {
                        ResponseCode = 200,
                        ResponseMessage = "The book has been returned."
                    };
                }
                else
                {
                    return new ResponseViewModel
                    {
                        ResponseCode = 500,
                        ResponseMessage = "Internal server error, Try again."
                    };
                }
            }
            else
            {
                return new ResponseViewModel
                {
                    ResponseCode = 400,
                    ResponseMessage = $"Bad request."
                };
            }
        }
        catch (Exception ex)
        {
            return new ResponseViewModel
            {
                ResponseCode = 500,
                ResponseMessage = ex.Message.ToString()
            };
        }
    }

    public async Task<ResponseViewModel> DeleteBookAsync(long bookId)
    {
        try
        {
            var book = await _BookRepository.ExecuteGetBookByIdAsync(bookId);
            if (book is not null)
            {
                var request = await _BookRepository.ExecuteDeleteBookAsync(bookId);
                if (request > 0)
                {
                    return new ResponseViewModel
                    {
                        ResponseCode = 200,
                        ResponseMessage = "Record has been deleted."
                    };
                }
                else
                {
                    return new ResponseViewModel
                    {
                        ResponseCode = 500,
                        ResponseMessage = "Internal server error, Try again."
                    };
                }
            }
            else
            {
                return new ResponseViewModel
                {
                    ResponseCode = 204,
                    ResponseMessage = $"No record found. Book ID: {bookId}"
                };
            }
        }
        catch (Exception ex)
        {
            return new ResponseViewModel
            {
                ResponseCode = 500,
                ResponseMessage = ex.Message.ToString()
            };
        }
    }
}
