using Microsoft.EntityFrameworkCore;
using CheapAllegro.Core.Models.Domains;

namespace CheapAllegro.Core
{
    public interface IApplicationDbContext
    {
        DbSet<Auction> Auctions { get; set; }
        DbSet<Category> Categories { get; set; }

        int SaveChanges();
    }
}
