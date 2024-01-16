using Data.Entities;

namespace Labolatorium_3_App.Models
{
    public interface IBorrowService
    {
        Task<BorrowEntity> BorrowBookAsync(int bookId, string userId);
        Task ReturnBookAsync(int borrowId);
    }

}
