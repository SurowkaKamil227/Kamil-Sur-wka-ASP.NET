using Labolatorium_3_App.Models;
using Data.Entities;

namespace Labolatorium_3_App.Models
{
    public static class LibraryMapper
    {
        public static LibraryEntity ToEntity(Library model)
        {
            return new LibraryEntity
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                // Dodaj mapowanie dla innych właściwości
            };
        }

        public static Library FromEntity(LibraryEntity entity)
        {
            return new Library
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                // Dodaj mapowanie dla innych właściwości
            };
        }
    }
}
