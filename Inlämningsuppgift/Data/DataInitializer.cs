using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Inlämningsuppgift.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager )
        {
            dbContext.Database.Migrate();
            SeedProductCategory(dbContext);
            SeedProduct(dbContext);
            SeedRoles(dbContext);

           // SeedCars(dbContext);
        }

        private static void SeedRoles(ApplicationDbContext dbContext)
        {
            if(dbContext.Roles.Any(r => r.Name == "Admin"))
            {
                dbContext.Roles.Add(new IdentityRole { 
                
                
                }
                       );
            }
        }

        private static void SeedProduct(ApplicationDbContext dbContext)
        {
            if (!dbContext.Products.Any(r => r.Namn == "Nvidia RTX 3080"))
            {
                var ProduktCatGraf = dbContext.Categories.First(cat => cat.Namn == "Grafikkort");
                dbContext.Products.Add(new Product
                {
                    Namn = "Nvidia RTX 3080",
                    Beskrivning = "Kommer aldrig i lager",
                    Pris = 8500,
                    category_Id = ProduktCatGraf

                }); ;
                //var ProduktCat = dbContext.Categories.First(cat => cat.Namn == "Grafikkort");
                //dbContext.Products.Add(ProduktCat);
                //ProduktCat.Products.Add(ProduktCat.Id);
                //var teams = dbContext.Teams.First(r => r.Namn == "trekronor");
                //teams.Player.Add(player)
            }
            var ProduktCatSkarm = dbContext.Categories.First(catsk => catsk.Namn == "Skärmar");

            if (!dbContext.Products.Any(r => r.Namn == "BenQ 27"))
            {
                dbContext.Products.Add(new Product
                {
                    Namn = "BenQ 27",
                    Beskrivning = "Halvbra skärm",
                    Pris = 3000,
                    category_Id = ProduktCatSkarm
                });
            }
            var ProduktCatNatagg = dbContext.Categories.First(catna => catna.Namn == "Nätagg");

            if (!dbContext.Products.Any(r => r.Namn == "Corsair RM750X"))
            {
                dbContext.Products.Add(new Product
                {
                    Namn = "Corsair RM750X",
                    Beskrivning = "Går aldrig sönder, släktklenod till barnbarnen.",
                    Pris = 1200,
                    category_Id = ProduktCatNatagg

                });
            }
            dbContext.SaveChanges();

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
