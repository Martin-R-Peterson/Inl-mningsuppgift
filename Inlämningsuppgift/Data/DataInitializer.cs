using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämningsuppgift.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            SeedProductCategory(dbContext);

           // SeedCars(dbContext);
        }

        private static void SeedProductCategory(ApplicationDbContext dbContext)
        {
            if (!dbContext.Categories.Any(r => r.Namn == "Grafikkort"))
            {
                dbContext.Categories.Add(new ProductCategory
                {
                   Namn = "Grafikkort"
                });
            }

            if (!dbContext.Categories.Any(r => r.Namn == "Skärmar"))
            {
                dbContext.Categories.Add(new ProductCategory
                {
                    Namn = "Skärmar"
                });
            }

            if (!dbContext.Categories.Any(r => r.Namn == "Nätagg"))
            {
                dbContext.Categories.Add(new ProductCategory
                {
                    Namn = "Nätagg"
                });
            }
            dbContext.SaveChanges();

        }


        //private static void SeedCars(ApplicationDbContext dbContext)
        //{
        //    //AAA313, BBB111, CCC222
        //    if (!dbContext.Bilar.Any(r => r.RegNo == "AAA313"))
        //    {
        //        dbContext.Bilar.Add(new Bil
        //        {
        //            RegNo = "AAA313",
        //            Manufacturer = "Volvo",
        //            Model = "XC60",
        //            Price = 12000,
        //            Year = 1999
        //        });
        //    }

        //    if (!dbContext.Bilar.Any(r => r.RegNo == "BBB111"))
        //    {
        //        dbContext.Bilar.Add(new Bil
        //        {
        //            RegNo = "BBB111",
        //            Manufacturer = "Saab",
        //            Model = "V4",
        //            Price = 12000,
        //            Year = 1973
        //        });
        //    }


        //    dbContext.SaveChanges();
        //}
    }
}
