using Ecommerce.Data.Enums;
using Ecommerce.Models;

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
    }
}
