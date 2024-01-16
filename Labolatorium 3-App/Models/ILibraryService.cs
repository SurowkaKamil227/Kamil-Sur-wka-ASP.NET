using Labolatorium_3_App.Models;
using System.Collections.Generic;

namespace Labolatorium_3_App.Models
{
    public interface ILibraryService
    {
        List<Library> GetAllLibraries();
        Library GetLibraryById(int id);
        void AddLibrary(Library library);
        void UpdateLibrary(Library library);
        void DeleteLibrary(int id);
    }
}
