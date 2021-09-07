using Microsoft.EntityFrameworkCore;
using CheapAllegro.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheapAllegro.Core
{
    public interface IApplicationDbContext
    {
        DbSet<Auction> Auctions { get; set; }
        DbSet<Category> Categories { get; set; }

        int SaveChanges();
    }
}
