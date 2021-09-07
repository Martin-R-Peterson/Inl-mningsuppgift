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

        public int Id { get; set; }
        [BindProperty]
        [MaxLength(50)]
        public string Namn { get; set; }
        [BindProperty]
        [MaxLength(100)]
        public string Beskrivning { get; set; }
        [BindProperty]
        [MaxLength(10)]
        public double Pris { get; set; }
        public void OnGet(int query)
        {
            

            var prod = _context.Products.First(s => s.Id == query);
            Namn = prod.Namn;
            Beskrivning = prod.Beskrivning;
            Pris = prod.Pris;


        }
    }
}
