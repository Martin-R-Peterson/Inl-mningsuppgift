using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Inlämningsuppgift.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace Inlämningsuppgift.Pages
{
    public class SearchResultsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbcontext;



        public SearchResultsModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbcontext = dbContext;
        }
        [BindProperty]

        public string SearchWord { get; set; }
       

        public class ProductItem
        {
            public string Namn { get; set; }

            public string Beskrivning { get; set; }
            public double Pris { get; set; }


        }

        public List<ProductItem> ProduktLista { get; set; }

        
        
        public void OnGet(string query)
        {
            SearchWord = query;

            ProduktLista = _dbcontext.Products.Select(s => new ProductItem
            {
                Namn = s.Namn,
                Beskrivning = s.Beskrivning,
                Pris = s.Pris
            }).ToList();






            if (!string.IsNullOrEmpty(SearchWord))
            {

               var res = ProduktLista.Where(s => s.Namn.Contains(SearchWord) || s.Beskrivning.Contains(SearchWord));
                ProduktLista = res.ToList();


            }


           

        }



    }
    
}
