using Microsoft.AspNetCore.Authorization;

namespace Labolatorium_3_App.Models
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
