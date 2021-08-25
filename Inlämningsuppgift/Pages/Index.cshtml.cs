using Inlämningsuppgift.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämningsuppgift.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbcontext;



        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbcontext = dbContext;
        }

        public class CategoryItem
        {
            public string Name { get; set; }
        }

        public List<CategoryItem> Lista { get; set; }

        public void OnGet()
        {
            //var lista = _dbcontext.Categories.ToList();

            Lista = new List<CategoryItem>();
            foreach (var cat in _dbcontext.Categories)
            {
                Lista.Add(new CategoryItem { Name = cat.Namn });
            }
        }
    }
}
