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
            CustomerId = customer.Id;
            FullName = customer.GetFullName();
            Orders = orders.Select(o => new DetailedOrderByCustomerViewModel(o)).ToList();

            TotalOrderedSum = Orders.Select(o => o.TotalOrderedSum).Sum();
        }

        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public decimal TotalOrderedSum { get; set; }

        public List<DetailedOrderByCustomerViewModel> Orders { get; set; }
    }
}
