using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämningsuppgift.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inlämningsuppgift.Pages.AdminPages
{
    public class adminmainModel : PageModel
    {
        
        

            private readonly ApplicationDbContext _dbcontext;



            public adminmainModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
            {
                _dbcontext = dbContext;
            }

            public class CatItem
            {
                public int Id { get; set; }
                public string Namn { get; set; }
            }

            public List<CatItem> CatName { get; set; }

            public void OnGet()
            {
                CatName = new List<CatItem>();
                foreach (var cat in _dbcontext.Categories)
                {
                    CatName.Add(new CatItem { Namn= cat.Namn , Id = cat.Id});
                }
            }
        }
    }

