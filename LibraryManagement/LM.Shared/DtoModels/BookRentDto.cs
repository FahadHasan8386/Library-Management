using System.ComponentModel.DataAnnotations;

namespace LM.Shared.DtoModels;

public sealed class BookRentDto
{

    public long BookRentId { get; set; }
    [Required]
    [Range(1, long.MaxValue, ErrorMessage = "Book is requried field.")]
    public long BookId { get; set; }
    [Required]
    public DateTime RentFromDate { get; set; } = DateTime.Now;
    public DateTime? RentToDate { get; set; } = null;
}
