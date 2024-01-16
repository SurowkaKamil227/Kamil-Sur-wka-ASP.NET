using Microsoft.AspNetCore.Mvc;
using Labolatorium_3_App.Models;
using Microsoft.AspNetCore.Authorization;
using static System.Reflection.Metadata.BlobBuilder;
using System.Security.Claims;

namespace Labolatorium_3_App.Models
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        //static readonly Dictionary<int, Contact> _contacts = new Dictionary<int, Contact> ();
        [AllowAnonymous]
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            int totalBooks = _bookService.CountBooks(); // uzyskaj całkowitą liczbę książek
            List<Book> books = _bookService.FindAll(page, pageSize);

            var viewModel = new BookListViewModel
            {
                Books = books,
                PageInfo = new PageInfo { CurrentPage = page, TotalItems = totalBooks, ItemsPerPage = pageSize }
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Book model = new Book();
            model.Libraries = _bookService.FindAllOrganizations().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(model);
                //dodanie modelu do aplikacji (zapamiętać dane)
                return RedirectToAction("Index");

            }
            return View(); // ponowne wyświetlenie formualrza po dodaniu jeśli są błędy
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Book book = _bookService.FindById(id);

            if (book == null)
            {
                return NotFound();
            }

            book.Libraries = _bookService.FindAllOrganizations().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();

            return View(book);
        }


        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.Libraries = _bookService.FindAllOrganizations().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();
            if (ModelState.IsValid)

            {
                _bookService.Update(model); // przypisanie nowych danych
                return RedirectToAction("Index");
            }



            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Book book = _bookService.FindById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book model)
        {
            _bookService.Delete(model.id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Book book = _bookService.FindById(id);

            if (book == null)
            {
                return NotFound();
            }

            var library = _bookService.FindAllOrganizations()
                .FirstOrDefault(eo => eo.Id == book.LibraryId);

            book.LibraryName = library?.Name; // Ustaw nazwę organizacji





            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateApi(Book b)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(b);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}