using Ecommerce.Data.Enums;
using Ecommerce.Data.Static;
using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var applicationservies = builder.ApplicationServices.CreateScope())
            {
                var context = applicationservies.ServiceProvider.GetService<EcommerceDbContext>();
                context.Database.EnsureCreated();
                //Category
                if (!context.Categories.Any())
                {
                    var categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = "C1",
                            Description="C1"
                        },
                          new Category()
                        {
                            Name = "C2",
                            Description="C2"
                        },
                            new Category()
                        {
                            Name = "C3",
                            Description="C3"
                        }
                    };
                    context.Categories.AddRange(categories);
                    context.SaveChanges();
                }
                //Product
                if (!context.Products.Any())
                {
                    var Prodcuts = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "P1",Descriptoin="D1",Price=150,ImageURL="https...",
                            ProductColor = ProductColor.Red,CategoryId=1
                        },
                         new Product()
                        {
                            Name = "P2",Descriptoin="D2",Price=200,ImageURL="https...",
                            ProductColor = ProductColor.Green,CategoryId=2
                        },
                          new Product()
                        {
                            Name = "P3",Descriptoin="D3",Price=300,ImageURL="https...",
                            ProductColor = ProductColor.Yellow,CategoryId=3
                        }
                    };
                    context.Products.AddRange(Prodcuts);
                    context.SaveChanges();
                }

            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder builder)
        {

            using (var applicationservices = builder.ApplicationServices.CreateScope())
            {
                #region Role
                var roleManager = applicationservices.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }
                #endregion

                #region User
                var userManager = applicationservices.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                if (await userManager.FindByEmailAsync("admin@admin.com") == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        Email = "admin@admin.com",
                        EmailConfirmed = true,
                        FullName = "Admin User",
                        UserName = "Admin"
                    };
                    await userManager.CreateAsync(newAdminUser, "@Dmin123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                    if (await userManager.FindByEmailAsync("user@user.com") == null)
                    {
                        var newOridinalUser = new ApplicationUser()
                        {
                            Email = "user@user.com",
                            EmailConfirmed = true,
                            FullName = "Oridinal User",
                            UserName = "User"
                        };
                        await userManager.CreateAsync(newOridinalUser, "@User123");
                        await userManager.AddToRoleAsync(newOridinalUser, UserRoles.User);
                    }

                    #endregion
                }

            }

        }
    }
}
