using Data.Entities;
using Data;

namespace Labolatorium_3_App.Models
{
    public class EFBorrowService : IBorrowService
    {
        private readonly AppDbContext _context;

        public EFBorrowService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BorrowEntity> BorrowBookAsync(int bookId, string userId)
        {
            var borrow = new BorrowEntity
            {
                BookId = bookId,
                UserId = userId,
                BorrowDate = DateTime.Now
            };

            _context.Borrows.Add(borrow);
            await _context.SaveChangesAsync();
            return borrow;
        }

        public async Task ReturnBookAsync(int borrowId)
        {
            var borrow = await _context.Borrows.FindAsync(borrowId);
            if (borrow != null)
            {
                borrow.ReturnDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
    }
}
