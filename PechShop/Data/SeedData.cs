using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PechShop.Models;

namespace PechShop.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PechShopContext(
                serviceProvider.GetRequiredService<DbContextOptions<PechShopContext>>()))
            {
                if (context.Products.Any() || context.Customers.Any() || context.Orders.Any())
                {
                    return;   // DB has been seeded
                }

                context.Products.AddRange(
                    new Product()
                    {
                        Name = "Хлеб",
                        MinimalNumber = 50,
                        Price = 10000,
                        Url = "sports.ru"
                    },

                    new Product()
                    {
                        Name = "Водка",
                        MinimalNumber = 2,
                        Price = 1,
                        Url = "yandex.ru"
                    }
                );

                context.Customers.AddRange(
                    new Customer()
                    {
                        FirstName = "Автандил",
                        LastName = "Муштантоид-Рыкин",
                        AdditionalInfo = "Играет на скрипке"
                    },

                    new Customer()
                    {
                        FirstName = "Иван",
                        LastName = "Иванов",
                        AdditionalInfo = "Боится трехколесных велосипедов"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
