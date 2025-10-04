using System.ComponentModel.DataAnnotations;

namespace LM.Shared.DtoModels;

public sealed class BookDto
{
    public long BookId { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Author { get; set; } = string.Empty;
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Minimum book quantity is required.")]
    public int TotalCopies { get; set; }
}
