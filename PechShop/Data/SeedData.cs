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
                        MinimalNumber = 3,
                        Price = 10000,
                        Url = "https://sports.ru",
                        TransportationCost = (decimal) 25.4,
                        AdditionalInfo = "Старый, невкусный"
                    },

                    new Product()
                    {
                        Name = "Водка",
                        MinimalNumber = 2,
                        Price = 1,
                        Url = "https://yandex.ru"
                    },
                    new Product()
                    {
                        Name = "Жвачка",
                        MinimalNumber = 20,
                        Price = (decimal) 0.5,
                        TransportationCost = (decimal)1000,
                        Url = "https://google.com"
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
                        CustomerId = 2,
                        ProductId = 2,
                        ProductsNumber = 1000
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
