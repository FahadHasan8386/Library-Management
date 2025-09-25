namespace LibraryManagement.Api.Model
{
    public class Books
    {
        public long BookId { get; set; }
        public string? Title { get; set; }
        public string? Author {  get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies {  get; set; }

    }
}
