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
            Orders = orders.Select(o => new DetailedOrderByCustomerViewModel(o)).ToList();

            TotalOrderedSum = Orders.Select(o => o.TotalOrderedSum).Sum();
        }

        public string FullName { get; set; }
        public decimal TotalOrderedSum { get; set; }

        public List<DetailedOrderByCustomerViewModel> Orders { get; set; }
    }
}
