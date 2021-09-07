using CheapAllegro.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheapAllegro.Core.Repositories
{
    public interface IAuctionRepository
    {
        IEnumerable<Auction> Get(string userId, int categoryId = 0, string title = null);
        Auction Get(int id, string userId);
        IEnumerable<Auction> GetAllAuctions(int categoryId = 0, string title = null);
        void Add(Auction auction);
        void Update(Auction auction);
        void Delete(int id, string userId);

    }
}
