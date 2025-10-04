namespace LM.Api.EntityModels;
public class BookRents
{
    public long BookRentId { get; set; }
    public long BookId { get; set; }
    public Books Books { get; set; } = new();
    public DateTime RentFromDate { get; set; }
    public DateTime RentToDate { get; set; }
}