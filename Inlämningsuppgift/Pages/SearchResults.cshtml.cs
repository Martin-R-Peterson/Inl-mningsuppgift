using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Inlämningsuppgift.Pages
{
    public class SearchResultsModel : PageModel
    {

        public string SearchWord { get; set; }
        public void OnGet(string query)
        {
            SearchWord = query;
            //sök produkter.
        }
    }
}
