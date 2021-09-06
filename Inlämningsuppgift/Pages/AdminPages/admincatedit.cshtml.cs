using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämningsuppgift.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Inlämningsuppgift.Pages.AdminPages
{
    public class admincateditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public string Namn { get; set; }

        public admincateditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int Id)
        {
            var Cat = _context.Categories.First(v => v.Id == Id);



            Namn = Cat.Namn;
            
        }
    }
}
