using System.Collections.Generic;
using Labolatorium_3_App.Models;

namespace Labolatorium_3_App.Models
{
    public class UserBorrowsViewModel
    {
        public List<UserBorrow> Borrows { get; set; }
    }

    public class UserBorrow
    {
        public Book Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Library Library { get; set; }
    }
}