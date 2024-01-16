using Data;
using Labolatorium_3_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace Labolatorium_3_App.Services
{
    public class EFLibraryService : ILibraryService
    {
        private readonly AppDbContext _context;

        public EFLibraryService(AppDbContext context)
        {
            _context = context;
        }

        public List<Library> GetAllLibraries()
        {
            return _context.Libraries.Select(le => LibraryMapper.FromEntity(le)).ToList();
        }

        public Library GetLibraryById(int id)
        {
            var libraryEntity = _context.Libraries.Find(id);
            return libraryEntity != null ? LibraryMapper.FromEntity(libraryEntity) : null;
        }

        public void AddLibrary(Library library)
        {
            var libraryEntity = LibraryMapper.ToEntity(library);
            _context.Libraries.Add(libraryEntity);
            _context.SaveChanges();
        }

        public void UpdateLibrary(Library library)
        {
            var existingLibrary = _context.Libraries.Find(library.Id);
            if (existingLibrary != null)
            {
                var libraryEntity = LibraryMapper.ToEntity(library);
                _context.Entry(existingLibrary).CurrentValues.SetValues(libraryEntity);
                _context.SaveChanges();
            }
        }

        public void DeleteLibrary(int id)
        {
            var library = _context.Libraries.Find(id);
            if (library != null)
            {
                _context.Libraries.Remove(library);
                _context.SaveChanges();
            }
        }
    }
}
