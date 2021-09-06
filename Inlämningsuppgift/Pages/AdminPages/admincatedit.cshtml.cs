using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Inlämningsuppgift.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Inlämningsuppgift.Pages.AdminPages
{
    [Authorize(Roles = "Admin, ProductManager")]

    public class admincateditModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        [BindProperty]
        [MaxLength(50)]
        public string CatNamn { get; set; }



        public admincateditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public class ProdItem
        {
            public int ID { get; set; }
            public string Namn { get; set; }


        }

        public int tempID { get; set; }

        public List<ProdItem> ProdName { get; set; }

        public void OnGet(int query)
        {
            var Cat = _context.Categories.First(v => v.Id == query);


            


            var currentCatName =
                _context.Categories.Include
                    (p => p.Products).First
                    (cat => cat.Id == query);
            CatNamn = currentCatName.Namn;

            ProdName = currentCatName.Products.Select(r => new ProdItem
            {
                Namn = r.Namn,
                ID = r.Id
            }).ToList();



            tempID = query;



        }
    }
}
