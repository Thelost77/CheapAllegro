using Microsoft.EntityFrameworkCore;
using CheapAllegro.Core;
using CheapAllegro.Core.Models.Domains;
using CheapAllegro.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAllegro.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private IApplicationDbContext _context;
        public CategoryRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.OrderBy(x => x.Name).ToList();
        }
        public Category GetCategory(int id)
        {
            return _context.Categories.Single(x => x.Id == id);
        }
        public bool AnyCategories()
        {
            return _context.Categories.Any();           
        }
        public void DefaultCategories()
        {
            var categories = new List<Category> 
            { 
                new Category { Name = "Wszystko" },
                new Category { Name = "Elektronika" },
                new Category { Name = "Sport" },
                new Category { Name = "Kultura" },
                new Category { Name = "Rozrywka" },
                new Category { Name = "Literatura" },
                new Category { Name = "Artykuły przemysłowe" },
                new Category { Name = "Motoryzacja" }
            };

            foreach (var category in categories)
            {
                _context.Categories.Add(category);
            }
        }

    }
}
