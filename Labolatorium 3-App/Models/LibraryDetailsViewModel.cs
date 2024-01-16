namespace Labolatorium_3_App.Models
{
    public class LibraryDetailsViewModel
    {
        public Library Library { get; set; }
        public IEnumerable<Book> Books { get; set; }

        // Możesz dodać tutaj inne właściwości, jeśli będą potrzebne
    }
}
