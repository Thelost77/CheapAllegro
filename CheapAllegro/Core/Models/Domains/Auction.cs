using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAllegro.Core.Models.Domains
{
    public class Auction
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole tytuł jest wymagane")]
        [Display(Name = "Tytuł")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Display(Name = "Cena")]
        public decimal Prize { get; set; }
        public DateTime? DateOfCreation { get; set; }
        [Required(ErrorMessage = "Pole opis jest wymagane")]
        [Display(Name = "Opis")]
        [MaxLength(250)]
        public string Description { get; set; }
        [Display(Name = "Dodaj zdjęcie")]
        public string AuctionPicture { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = "Pole kategoria jest wymagane")]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ApplicationUser User { get; set; }


    }
}
