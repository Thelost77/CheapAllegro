using CheapAllegro.Core.Models;
using CheapAllegro.Core.Models.Domains;
using CheapAllegro.Core.Service;
using CheapAllegro.Core.ViewModels;
using CheapAllegro.Persistence.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace CheapAllegro.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        private IAuctionService _auctionService;
        private IWebHostEnvironment _webHostEnvironment;

        public AuctionController(IAuctionService auctionService, IWebHostEnvironment webHostEnvironment)
        {
            _auctionService = auctionService;
            _webHostEnvironment = webHostEnvironment;
        }
        [AllowAnonymous]
        public IActionResult Auctions()
        {
            var vm = new AuctionSideViewModel
            {
                Filter = new FilterAuction(),
                Auctions = _auctionService.GetAllAuctions(),
                Categories = _auctionService.GetCategories()
            };

            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Auctions(AuctionSideViewModel viewModel)
        {
            var userId = User.GetUserId();

            var auctions = _auctionService.Get(
                userId,
                viewModel.Filter.CategoryId,
                viewModel.Filter.Title);

            return PartialView("_AuctionList", auctions);
        }
        public IActionResult Auction(int id = 0)
        {
            var userId = User.GetUserId();

            var Categories = _auctionService.GetCategories().Where(x => x.Name != "Wszystko");

            if (id != 0)
            {
                var auction = _auctionService.Get(id, userId);

                var vm = new AuctionViewModel
                {
                    Categories = Categories,
                    CategoryId = auction.CategoryId,
                    Description = auction.Description,
                    Id = auction.Id,
                    Prize = auction.Prize,
                    Title = auction.Title,
                    UserId = auction.UserId,
                    PicturePath = auction.AuctionPicture,
                    Header = "Edycja Aukcji!"
                    
                    
                };

                return View(vm);
            }
            else
            {
                var vm = new AuctionViewModel { Categories = Categories, Header = "Dodawanie nowej aukcji!" };

                return View(vm);
            }

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Auction(AuctionViewModel model)
        {
            var userId = User.GetUserId();

            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                if (model.Id != 0)
                {
                    var auctionToUpdate = _auctionService.Get(model.Id, userId);

                    auctionToUpdate.CategoryId = model.CategoryId;
                    auctionToUpdate.Title = model.Title;
                    auctionToUpdate.Description = model.Description;
                    auctionToUpdate.Prize = model.Prize;
                    auctionToUpdate.AuctionPicture = uniqueFileName != null ? uniqueFileName : auctionToUpdate.AuctionPicture;

                    _auctionService.Update(auctionToUpdate);
                }
                else
                {
                    Auction auction = new Auction
                    {
                        CategoryId = model.CategoryId,
                        Title = model.Title,
                        Description = model.Description,
                        DateOfCreation = DateTime.Now,
                        Prize = model.Prize,
                        AuctionPicture = uniqueFileName,
                        UserId = userId,
                    };

                    _auctionService.Add(auction);
                }                                 

                return RedirectToAction("Auctions");
            }

            var Categories = _auctionService.GetCategories();

            var vm = new AuctionViewModel { Categories = Categories };

            return View(vm);
        }

        public IActionResult MyAuctions()
        {
            var userId = User.GetUserId();

            var Auctions = _auctionService.Get(userId);

            return View(Auctions);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var userId = User.GetUserId();

            try
            {
                _auctionService.Delete(id, userId);

            }
            catch (Exception e)
            {

                //logowanie do pliku
                return Json(new { success = false, message = e.Message });
            }

            return Json(new { success = true });
        }
        private string UploadedFile(AuctionViewModel model)
        {
            List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
            string uniqueFileName = null;
            if (model.AuctionPicture != null && ImageExtensions.Contains(Path.GetExtension(model.AuctionPicture.FileName).ToUpper()))
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.AuctionPicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.AuctionPicture.CopyTo(fileStream);
                }
            }
            else
            {
                uniqueFileName = "default.jpg";
            }
            return uniqueFileName;
        }

    }
}
