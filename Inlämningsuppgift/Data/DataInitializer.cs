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
           SeedUsers(userManager);

        }
        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("stefan.holmberg@systementor.se").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "stefan.holmberg@systementor.se";
                user.Email = "stefan.holmberg@systementor.se";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "#Password123").Result;
                userManager.AddToRoleAsync(user, "Admin").Wait();

            }
            if (userManager.FindByEmailAsync("johan.garpenlov@trekronor.se").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "martin@butiken.se";
                user.Email = "martin@butiken.se";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "#Hej123").Result;
                userManager.AddToRoleAsync(user, "Admin").Wait();

            }
            

        }

        private static void SeedRoles(ApplicationDbContext dbContext)
        {
            if(!dbContext.Roles.Any(r => r.Name == "Admin"))
            {
                dbContext.Roles.Add(new IdentityRole {
                        NormalizedName = "Admin",
                        Name = "Admin"

                }
                       );
            }
            if (!dbContext.Roles.Any(r => r.Name == "ProductManager"))
            {
                dbContext.Roles.Add(new IdentityRole
                {
                    NormalizedName = "ProductManager",
                    Name = "ProductManager"
                });
            }

            dbContext.SaveChanges();
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
                
            }
            if (!dbContext.Products.Any(r => r.Namn == "Nvidia RTX 3070"))
            {
                var ProduktCatGraf = dbContext.Categories.First(cat => cat.Namn == "Grafikkort");
                dbContext.Products.Add(new Product
                {
                    Namn = "Nvidia RTX 3070",
                    Beskrivning = "Grymt grafikkort för gaming",
                    Pris = 7000,
                    category_Id = ProduktCatGraf

                }); ;

            }
            if (!dbContext.Products.Any(r => r.Namn == "Nvidia RTX 2060"))
            {
                var ProduktCatGraf = dbContext.Categories.First(cat => cat.Namn == "Grafikkort");
                dbContext.Products.Add(new Product
                {
                    Namn = "Nvidia RTX 2060",
                    Beskrivning = "Bra prestanda för pengarna",
                    Pris = 4000,
                    category_Id = ProduktCatGraf

                }); ;

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

            if (!dbContext.Products.Any(r => r.Namn == "Asus 32"))
            {
                dbContext.Products.Add(new Product
                {
                    Namn = "Asus 32",
                    Beskrivning = "Stor skärm för stora spel",
                    Pris = 6000,
                    category_Id = ProduktCatSkarm
                });
            }

            if (!dbContext.Products.Any(r => r.Namn == "Acer 24"))
            {
                dbContext.Products.Add(new Product
                {
                    Namn = "Acer 24",
                    Beskrivning = "Bra budgetskärm",
                    Pris = 1500,
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

            if (!dbContext.Products.Any(r => r.Namn == "Corsair RM550"))
            {
                dbContext.Products.Add(new Product
                {
                    Namn = "Corsair RM550",
                    Beskrivning = "Bra för pengarna",
                    Pris = 700,
                    category_Id = ProduktCatNatagg

                });
            }

            if (!dbContext.Products.Any(r => r.Namn == "Corsair RM1200"))
            {
                dbContext.Products.Add(new Product
                {
                    Namn = "Corsair RM1200",
                    Beskrivning = "För extrem överclockaren",
                    Pris = 2000,
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
