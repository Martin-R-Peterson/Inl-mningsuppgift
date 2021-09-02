using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämningsuppgift.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inlämningsuppgift.Pages
{
    public class TeamModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbcontext;



        public TeamModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbcontext = dbContext;
        }

        public string Teamname { get; set; }

        public class PlayerItem
        {
            public string Name { get; set; }

            public string Position { get; set; }
        }
        public List<SelectListItem> blabla { get; set; }
        public List<PlayerItem> ListofPlayers { get; set; }
        public void OnGet(int catID)
        {
            var currentCat = _dbcontext.Categories.Include(p => p.Products).First(cat => cat.Id == catID);
            Teamname = currentCat.Namn;

            //ListofPlayers = currentCat.Products.Select(produ => new PlayerItem
            //{
            //    Name = produ.Namn,

            //});


            //public Selecedit (ApplicationDbContext dbcontext)
            //{
            //    _dbcontext = dbcontext;
            //    blabla = new List<SelectListItem>();
            //    blabla.Add(new SelectListItem("Försvarare", "Försvarare"));

            //}
        }
    }
}
