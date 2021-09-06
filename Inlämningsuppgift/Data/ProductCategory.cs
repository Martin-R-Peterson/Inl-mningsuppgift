using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämningsuppgift.Data
{
    public class ProductCategory
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Namn { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
