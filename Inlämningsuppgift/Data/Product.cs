using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämningsuppgift.Data
{
    public class Product
    {
        //(id, namn, beskrivning, pris, category_id

            public int Id { get; set; }

        public string Namn { get; set; }

        public string Beskrivning { get; set; }

        public double Pris { get; set; }

        public ProductCategory category_Id { get; set; }
    }
}
