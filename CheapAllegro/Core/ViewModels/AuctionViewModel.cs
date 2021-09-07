using CheapAllegro.Core.Models.Domains;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CheapAllegro.Core.ViewModels
{
    public class AuctionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole tytuł jest wymagane")]
        [Display(Name = "Tytuł")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Display(Name = "Cena")]
        public decimal Prize { get; set; }
        [Required(ErrorMessage = "Pole opis jest wymagane")]
        [Display(Name = "Opis")]
        [MaxLength(250)]
        public string Description { get; set; }
        //[Required(ErrorMessage = "Proszę wybierz zdjęcie")]
        [Display(Name = "Dodaj zdjęcie")]
        public IFormFile AuctionPicture { get; set; }
        public string PicturePath { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = "Pole kategoria jest wymagane")]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string Header { get; set; }
    }
}
