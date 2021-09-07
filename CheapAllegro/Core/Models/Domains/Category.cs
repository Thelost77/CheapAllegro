using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAllegro.Core.Models.Domains
{
    public class Category
    {
        public Category()
        {
            Auctions = new Collection<Auction>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name="Nazwa")]
        public string Name { get; set; }
        public ICollection<Auction> Auctions { get; set; }
    }
}
