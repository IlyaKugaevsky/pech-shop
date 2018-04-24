using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PechShop.Data;
using PechShop.Models;
using PechShop.ViewModels;

namespace PechShop.Services
{
    public class OrderService
    {
        private readonly PechShopContext _context;

        public OrderService(PechShopContext context)
        {
            _context = context;
        }

        public async Task CreateOrder(int productId, int customerId, int productsNumber)
        {
            var dateTime = DateTime.Now;

            var duplicateOrder = await _context.FindDuplicateOrder(productId, customerId);

            if (duplicateOrder == null)
            {
                var order = new Order()
                {
                    CustomerId = customerId,
                    ProductId = productId,
                    ProductsNumber = productsNumber,
                    Date = dateTime
                };

                _context.Add(order);
                await _context.SaveChangesAsync();
            }
            else
            {
                duplicateOrder.ProductsNumber += productsNumber;
                duplicateOrder.Date = dateTime;
                await _context.SaveChangesAsync();
            }

        }
    }
}
