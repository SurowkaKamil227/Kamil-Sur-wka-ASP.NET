using Microsoft.AspNetCore.Mvc;
using Labolatorium_3_App.Models;
using Microsoft.AspNetCore.Authorization;
//... inne usingi

namespace Labolatorium_3_App.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;
        private readonly IBookService _bookService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        public IActionResult Manage()
        {
            var libraries = _libraryService.GetAllLibraries();
            return View(libraries);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Library library)
        {
            if (ModelState.IsValid)
            {
                _libraryService.AddLibrary(library);
                return RedirectToAction(nameof(Index));
            }
            return View(library);
        }

        public IActionResult Edit(int id)
        {
            var library = _libraryService.GetLibraryById(id);
            if (library == null)
            {
                return NotFound();
            }
            return View(library);
        }

        [HttpPost]
        public IActionResult Edit(Library library)
        {
            if (ModelState.IsValid)
            {
                _libraryService.UpdateLibrary(library);
                return RedirectToAction(nameof(Index));
            }
            return View(library);
        }

        public IActionResult Delete(int id)
        {
            var library = _libraryService.GetLibraryById(id);
            if (library == null)
            {
                return NotFound();
            }
            return View(library);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _libraryService.DeleteLibrary(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
