using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium_3_App.Models
{
    public class Book
    {
        [HiddenInput]
        public int id { get; set; }
        [Required(ErrorMessage = "Musisz podać tytuł!")]
        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Musisz podać autora książki!")]
        [Display(Name = "Autor")]
        public string Author { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Proszę wprowadzić liczbę większą lub równą 1.")]
        [Display(Name = "Liczba stron")]
        [Required(ErrorMessage = "Musisz podać liczbę stron!")]
        public string Page_No { get; set; }
        [Required(ErrorMessage = "Musisz podać numer ISBN!")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Musisz podać datę publikacji!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data publikacji")]
        public DateTime PublicationDate { get; set; }


        [Required(ErrorMessage = "Musisz podać nazwę wydawnictwa!")]
        [Display(Name = "Publishing house name")]
        public string? PublishingHouse { get; set; }

        [Display(Name = "Status dostępności")]
        public BookStatus BookStatus { get; set; }
        public int Priority { get; set; }
        public DateTime Created { get; set; }
        public int? LibraryId { get; set; }
        public string? LibraryName { get; set; }

        [ValidateNever]
        public List<SelectListItem> Libraries { get; set; }

    }
}
