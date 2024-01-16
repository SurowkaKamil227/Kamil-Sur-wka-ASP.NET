using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Data.Entities;
using System;
using System.Threading.Tasks;
using Data;
using Labolatorium_3_App.Models;
using Labolatorium_3_App.Services;

[Authorize]
public class BorrowController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IBookService _bookService; // Dodana zależność
    private readonly ILibraryService _libraryService;

    public BorrowController(AppDbContext context, UserManager<IdentityUser> userManager, IBookService bookService, ILibraryService libraryService)
    {
        _context = context;
        _userManager = userManager;
        _bookService = bookService; // Inicjalizacja serwisu
        _libraryService = libraryService;
    }
    [HttpGet]
    public IActionResult Borrow()
    {
        var viewModel = new BorrowViewModel
        {
            Books = _bookService.GetBooks().ToList(),
            Libraries = _libraryService.GetAllLibraries()
        };

        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> BorrowBook(int bookId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login", "Account"); // Przekieruj do strony logowania
        }

        var book = await _context.Books.FindAsync(bookId);
        if (book == null)
        {
            return NotFound(); // Nie znaleziono książki
        }

        var borrow = new BorrowEntity
        {
            BorrowDate = DateTime.Now,
            UserId = user.Id,
            BookId = bookId
        };

        _context.Borrows.Add(borrow);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Book"); // Przekieruj z powrotem do listy książek
    }
    [HttpPost]
    public async Task<IActionResult> SubmitBorrow(BorrowFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Borrow", model); // Powrót do formularza w przypadku błędu
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login", "Account"); // Przekieruj do logowania, jeśli użytkownik nie jest zalogowany
        }

        var borrow = new BorrowEntity
        {
            BookId = model.BookId,
            LibraryId = model.LibraryId,
            BorrowDate = model.BorrowDate,
            ReturnDate = model.ReturnDate,
            UserId = user.Id
        };

        _context.Borrows.Add(borrow);
        await _context.SaveChangesAsync();

        return RedirectToAction("UserBorrows", "Borrow"); // Przekieruj do listy książek po udanym wypożyczeniu
    }
    public async Task<IActionResult> UserBorrows()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var borrows = _context.Borrows
            .Where(b => b.UserId == user.Id)
            .Select(b => new UserBorrow
            {
                Book = new Book { Title = b.Book.Title }, // Zakładamy, że masz dostęp do odpowiednich właściwości
                BorrowDate = b.BorrowDate,
                ReturnDate = b.ReturnDate,
                Library = new Library { Name = b.Library.Name } // Zakładamy, że masz dostęp do odpowiednich właściwości
            })
            .ToList();

        var viewModel = new UserBorrowsViewModel
        {
            Borrows = borrows
        };

        return View(viewModel);
    }
}
