using Data.Entities;
using Labolatorium_3_App.Models;

namespace Labolatorium_3_App.Models;

public interface IBookService
{
    int Add(Book book);
    void Delete(int id);
    void Update(Book book);
    List<Book> FindAll(int page, int pageSize);
    Book? FindById(int id);
    List<LibraryEntity> FindAllOrganizations();
    int CountBooks();
    List<Book> GetBooksByLibraryId(int libraryId);
    IEnumerable<Book> GetBooks(); // Dodaj tę metodę
}