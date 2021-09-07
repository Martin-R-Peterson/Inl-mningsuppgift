using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Inlämningsuppgift.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Inlämningsuppgift.Pages.AdminPages.Products
{
    [Authorize(Roles = "Admin, ProductManager")]

    public class NewProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public NewProductModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        [MaxLength(50)]
        public string Namn { get; set; }
        [BindProperty]
        [MaxLength(100)]
        public string Beskrivning { get; set; }
        [BindProperty]
        [Range(0, 100000)]

        public double Pris { get; set; }



        public IActionResult OnPost(int query)
        {
            var catID =
                _context.Categories.Include
                    (p => p.Products).First
                    (cat => cat.Id == query);
            if (ModelState.IsValid)
            {

                var prod = new Product();
                prod.Namn = Namn;
                prod.Beskrivning = Beskrivning;
                prod.Pris = Pris;
                prod.category_Id = catID;
                _context.Add(prod);
                _context.SaveChanges();
                return RedirectToPage("/AdminPages/adminmain");
            }
            return RedirectToPage();

        }

        public void OnGet()
        {

        }
    }
}
