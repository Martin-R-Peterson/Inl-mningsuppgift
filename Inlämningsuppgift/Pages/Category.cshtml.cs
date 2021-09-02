using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämningsuppgift.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inlämningsuppgift.Pages
{
    public class CategoryModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbcontext;



        public CategoryModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbcontext = dbContext;
        }

        public string CategoryName { get; set; }

        public class ProductItem
        {
            public string Namn { get; set; }

            public string Beskrivning { get; set; }

            public double Pris { get; set; }

        }

        public List<ProductItem> ListOfProducts { get; set; }

        public void OnGet(int catId)
        {
            var currentCat =
                _dbcontext.Categories.Include
                    (p => p.Products).First
                    (cat => cat.Id == catId);
            CategoryName = currentCat.Namn;

            //ListOfProducts =
            //ListOfProducts..Select(produ => new ProductItem {Namn = produ.Namn});

            //ListOfProducts = new List<ProductItem>();
            //foreach (var product in _dbcontext.Products)
            //{
            //    product.Namn = 
            //}
            var ProduktCatGraf = _dbcontext.Categories.First(ct => ct.Id == catId);



            ListOfProducts = currentCat.Products.Select(r => new ProductItem
            {
                Namn = r.Namn,
                Beskrivning = r.Beskrivning,
                Pris = r.Pris
            }).ToList();

            //ListOfProducts = currentCat.Products.Select(product => new ProductItem {Namn = product.Namn})
        }
    }
}
