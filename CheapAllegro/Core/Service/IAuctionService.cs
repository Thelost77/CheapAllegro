using CheapAllegro.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Collections.Specialized.BitVector32;

namespace CheapAllegro.Core.Service
{
public interface IAuctionService
{
        IEnumerable<Auction> Get(string userId, int categoryId = 0, string title = null);
        IEnumerable<Category> GetCategories();
        IEnumerable<Auction> GetAllAuctions(int categoryId = 0, string title = null);
        Auction Get(int id, string userId);
        void Update(Auction auction);
        void Add(Auction auction);
        void Delete(int id, string userId);
        Category GetCategory(int id);
        bool AnyCategories();
        void DefaultCategories();
    }
}
