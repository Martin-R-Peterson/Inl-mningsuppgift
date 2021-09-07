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

    public class EditProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;


        public EditProductModel(ApplicationDbContext context)
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
        [Range(0,100000)]
        public double Pris { get; set; }

        public IActionResult OnPost(int Id)
        {
            if (ModelState.IsValid)
            {
                var ProdEdit = _context.Products.Include(e => e.category_Id).First(r => r.Id == Id);
                ProdEdit.Namn = Namn;
                ProdEdit.Beskrivning = Beskrivning;
                ProdEdit.Pris = Pris;
                _context.SaveChanges();
                return RedirectToPage("/AdminPages/adminmain");
            }

            return RedirectToPage();
        }
        public void OnGet(int Id)
        {
            

            var prod = _context.Products.First(s => s.Id == Id);
            Namn = prod.Namn;
            Beskrivning = prod.Beskrivning;
            Pris = prod.Pris;





        }
    }
}
