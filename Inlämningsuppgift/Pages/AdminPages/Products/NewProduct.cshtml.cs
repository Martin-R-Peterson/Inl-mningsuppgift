using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Inlämningsuppgift.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Inlämningsuppgift.Pages.AdminPages.Products
{
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

        public string Beskrivning { get; set; }

        public double Pris { get; set; }

        public ProductCategory category_Id { get; set; }


        public IActionResult OnPost(int query)
        {
            if (ModelState.IsValid)
            {
                var prod = new Product();
                prod.Namn = Namn;
                prod.Beskrivning = Beskrivning;
                prod.Pris = Pris;
                prod.category_Id.Id = query;
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
