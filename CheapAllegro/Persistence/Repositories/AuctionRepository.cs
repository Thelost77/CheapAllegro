using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CheapAllegro.Core.Models.Domains;
using CheapAllegro.Core.Repositories;
using CheapAllegro.Core;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CheapAllegro.Persistence.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private IApplicationDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        public AuctionRepository(IApplicationDbContext context,
                                 IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<Auction> Get(string userId, int categoryId = 0, string title = null)
        {
            var tasks = _context.Auctions
                .Include(x => x.Category)
                .Where(x => x.UserId == userId);

            if (categoryId != 0)
                tasks = tasks.Where(x => x.CategoryId == categoryId);

            if (!string.IsNullOrWhiteSpace(title))
                tasks = tasks.Where(x => x.Title.Contains(title));

            return tasks.OrderBy(x => x.DateOfCreation).ToList();

        }
        public IEnumerable<Auction> GetAllAuctions(int categoryId = 0, string title = null)
        {
            var tasks = _context.Auctions
                .Include(x => x.Category)
                .AsQueryable();

            if (categoryId != 0)
                tasks = tasks.Where(x => x.CategoryId == categoryId);

            if (!string.IsNullOrWhiteSpace(title))
                tasks = tasks.Where(x => x.Title.Contains(title));

            return tasks.OrderBy(x => x.DateOfCreation).ToList();

        }
        public Auction Get(int id, string userId)
        {
            return _context.Auctions.Single(x => x.Id == id && x.UserId == userId);
        }

        public void Add(Auction auction)
        {
            _context.Auctions.Add(auction);
        }

        public void Update(Auction auction)
        {
            var auctionToUpdate = _context.Auctions.Single(x => x.Id == auction.Id);

            auctionToUpdate.CategoryId = auction.CategoryId;
            auctionToUpdate.Prize = auction.Prize;
            auctionToUpdate.AuctionPicture = auction.AuctionPicture;
            auctionToUpdate.Description = auction.Description;
            auctionToUpdate.Title = auction.Title;
        }

        public void Delete(int id, string userId)
        {
            var auctionToDelete = _context.Auctions.Single(x => x.Id == id && x.UserId == userId);

            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            string filePath = Path.Combine(uploadsFolder, auctionToDelete.AuctionPicture);
            File.Delete(filePath);

            _context.Auctions.Remove(auctionToDelete);
        }
    }
}
