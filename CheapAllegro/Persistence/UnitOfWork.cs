using CheapAllegro.Core;
using CheapAllegro.Core.Repositories;
using CheapAllegro.Persistence.Repositories;
using Microsoft.AspNetCore.Hosting;

namespace CheapAllegro.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;

        public UnitOfWork(IApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            Auction = new AuctionRepository(context, webHostEnvironment);
            Category = new CategoryRepository(context);
        }

        public IAuctionRepository Auction { get; set; }
        public ICategoryRepository Category { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}
