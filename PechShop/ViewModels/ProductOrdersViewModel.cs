using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PechShop.Models;

namespace PechShop.ViewModels
{
    public class ProductOrdersViewModel
    {
        public ProductOrdersViewModel(Product product, IEnumerable<Order> orders)
        {
            ProductName = product.Name;
            Orders = orders.Select(o => new OrderViewModel(o)).ToList();
        }

        public string ProductName { get; set; }

        public List<OrderViewModel> Orders { get; set; }
    }
}
