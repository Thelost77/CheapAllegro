using CheapAllegro.Core.Models;
using CheapAllegro.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAllegro.Core.ViewModels
{
    public class AuctionSideViewModel
    {
        public IEnumerable<Auction> Auctions { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public FilterAuction Filter { get; set; }
    }
}
