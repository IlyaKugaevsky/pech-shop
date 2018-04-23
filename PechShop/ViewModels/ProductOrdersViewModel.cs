using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            //Price = product.Price;
            //MinimalNumber = product.MinimalNumber;
        }
        
        [DisplayName("Покупатель")]
        public string ProductName { get; set; }

        //[DisplayName("Цена")]
        //public decimal Price { get; set; }
        //[DisplayName("Минимальное количество")]
        //public int MinimalNumber { get; set; }
        //[DisplayName("Заказанное количество")]
        //public int TotalOrderedNumber { get; set; }
        //[DisplayName("Заказано на сумму")]
        //public int TotalOrderedSum { get; set; }


        public List<OrderViewModel> Orders { get; set; }
    }
}
