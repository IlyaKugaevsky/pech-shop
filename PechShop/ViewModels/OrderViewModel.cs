using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PechShop.Models;

namespace PechShop.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
        }

        public OrderViewModel(Order order)
        {
            ProductsNumber = order.ProductsNumber;
            OrderId = order.Id;
            ProductName = order.Product.Name;
            Date = order.Date;
            CustomerName = order.Customer.GetFullName();
        }

        [DisplayName("Количество товаров")]
        public int ProductsNumber { get; set; }

        [DisplayName("Номер заказа")]
        public int OrderId { get; set; }
        [DisplayName("Дата добавления")]
        public DateTime Date { get; set; }
        [DisplayName("Товар")]
        public string ProductName { get; set; }
        [DisplayName("Покупатель")]
        public string CustomerName { get; set; }

    }
}
