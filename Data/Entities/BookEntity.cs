using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("books")]
    public class BookEntity
    {
        public DateTime Created { get; set; }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MaxLength(50)]
        [Required]
        public string Page_No { get; set; }
        public string ISBN { get; set; }
        public string? Author { get; set; }

        [Column("publication_date")]
        public DateTime? PublicationDate { get; set; }

        public string PublishingHouse { get; set; }

        public int Priority { get; set; }

        public LibraryEntity Library { get; set; }

        public int LibraryId { get; set; }
    }
}
