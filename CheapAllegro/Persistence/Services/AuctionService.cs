using CheapAllegro.Core;
using CheapAllegro.Core.Models.Domains;
using CheapAllegro.Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAllegro.Persistence.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuctionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Auction> Get(string userId, int categoryId = 0, string title = null)
        {
            return _unitOfWork.Auction.Get(userId, categoryId, title);
        }
        public IEnumerable<Auction> GetAllAuctions(int categoryId = 0, string title = null)
        {
            return _unitOfWork.Auction.GetAllAuctions(categoryId, title);
        }

        public Auction Get(int id, string userId)
{
            return _unitOfWork.Auction.Get(id, userId);
        }
        public void Add(Auction auction)
        {
            _unitOfWork.Auction.Add(auction);
            _unitOfWork.Complete();
        }
        public void Update(Auction auction)
        {
            _unitOfWork.Auction.Update(auction);
            _unitOfWork.Complete();
        }
        public void Delete(int id, string userId)
        {
            _unitOfWork.Auction.Delete(id, userId);
            _unitOfWork.Complete();
        }
        public IEnumerable<Category> GetCategories()
        {
            return _unitOfWork.Category.GetCategories();
        }
        public Category GetCategory(int id)
        {
            return _unitOfWork.Category.GetCategory(id);
        }
        public bool AnyCategories()
        {
            return _unitOfWork.Category.AnyCategories();
        }
        public void DefaultCategories()
        {
            _unitOfWork.Category.DefaultCategories();
            _unitOfWork.Complete();
        }
    }
}
