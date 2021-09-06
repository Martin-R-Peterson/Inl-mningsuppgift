using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Inlämningsuppgift.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Inlämningsuppgift.Pages.AdminPages
{
    public class admincatnewModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public admincatnewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        [MaxLength(50)]
        public string Namn { get; set; }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var cat = new ProductCategory();
                cat.Namn = Namn;
                _context.Add(cat);
                _context.SaveChanges();
                return RedirectToPage("/AdminPages/adminmain");
            }
            return RedirectToPage("/AdminPages/Index");

        }
        public void OnGet()
        {
        }
    }
}
