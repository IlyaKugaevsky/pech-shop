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
                    return;
                }

                context.Products.AddRange(
                    new Product()
                    {
                        Name = "Хлеб",
                        MinimalNumber = 50,
                        Price = 10000,
                        Url = "https://sports.ru"
                    },

                    new Product()
                    {
                        Name = "Водка",
                        MinimalNumber = 2,
                        Price = 1,
                        Url = "https://yandex.ru"
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

                context.Orders.AddRange(
                    new Order()
                    {
                        CustomerId = 1,
                        ProductId = 1,
                        ProductsNumber = 3
                    },
                    new Order()
                    {
                        CustomerId = 1,
                        ProductId = 1,
                        ProductsNumber = 3
                    },
                    new Order()
                    {
                        CustomerId = 1,
                        ProductId = 1,
                        ProductsNumber = 3
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
