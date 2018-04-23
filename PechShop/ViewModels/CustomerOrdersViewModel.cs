using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PechShop.Models;

namespace PechShop.ViewModels
{
    public class CustomerOrdersViewModel
    {
        public CustomerOrdersViewModel(CustomerViewModel customer, IEnumerable<Order> orders)
        {
            FullName = customer.GetFullName();
            Orders = orders.Select(o => new OrderViewModel(o)).ToList();
        }

        public string FullName { get; set; }

        public List<OrderViewModel> Orders { get; set; }
    }
}
