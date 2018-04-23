using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PechShop.Models;

namespace PechShop.Data
{
    public static class ContextExtensions
    {
        public static Task<Order> FindDuplicateOrder(this PechShopContext context, int productId, int customerId)
        {
            return context.Orders.SingleOrDefaultAsync(o => (o.CustomerId == customerId) && (o.ProductId == productId));
        }
    }
}
