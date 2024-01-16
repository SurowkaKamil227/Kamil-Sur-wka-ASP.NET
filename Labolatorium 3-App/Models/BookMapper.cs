using Data.Entities;
using Labolatorium_3_App.Models;

namespace Labolatorium_3_App.Models;

public class BookMapper
{
    public static BookEntity ToEntity(Book model)
    {
        return new BookEntity()
        {
            Created = model.Created,
            Id = model.id,
            Title = model.Title,
            Page_No = model.Page_No,
            ISBN = model.ISBN,
            Author = model.Author,
            PublicationDate = model.PublicationDate,
            PublishingHouse = model.PublishingHouse,
            Priority = (int)model.Priority,
            LibraryId = (int)model.LibraryId,

        };
    }

    public static Book FromEntity(BookEntity entity)
    {
        return new Book()
        {
            Created = entity.Created,
            id = entity.Id,
            Title = entity.Title,
            Page_No = entity.Page_No,
            ISBN = entity.ISBN,
            Author = entity.Author,
            PublicationDate = (DateTime)entity.PublicationDate,
            PublishingHouse = entity.PublishingHouse,
            Priority = entity.Priority,
            LibraryId = entity.LibraryId,
        };
    }
}