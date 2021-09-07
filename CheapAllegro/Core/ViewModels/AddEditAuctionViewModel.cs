using CheapAllegro.Core.Models;
using CheapAllegro.Core.Models.Domains;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAllegro.Core.ViewModels
{
    public class AddEditAuctionViewModel
    {
        public string Heading { get; set; }
        public Auction Auction { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
