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
        [BindProperty]


        public List<Product> ProduktLista { get; set; }

        
        
        public void OnGet(string query)
        {
            SearchWord = query;
            //sök produkter.
            var res = from r in _dbcontext.Products
                select r;


            if (!string.IsNullOrEmpty(SearchWord))
            {
                res = res.Where(s => s.Namn.Contains(SearchWord));
            }

            ProduktLista =  res.ToList();
        }



    }
    
}
