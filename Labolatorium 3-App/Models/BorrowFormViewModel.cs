using System;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium_3_App.Models
{
    public class BorrowFormViewModel
    {
        [Required(ErrorMessage = "Please select a book.")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please select a library.")]
        public int LibraryId { get; set; }

        [Required(ErrorMessage = "Please enter a borrow date.")]
        public DateTime BorrowDate { get; set; }

        [Required(ErrorMessage = "Please enter a return date.")]
        public DateTime ReturnDate { get; set; }
    }
}
