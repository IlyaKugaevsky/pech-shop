using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using PechShop.Models;

namespace PechShop.ViewModels
{
    public class DetailedOrderByCustomerViewModel
    {
        public DetailedOrderByCustomerViewModel()
        {
            
        }

        public DetailedOrderByCustomerViewModel(Order order)
        {
            OrderId = order.Id;
            ProductName = order.Product.Name;
            ProductPrice = order.Product.Price;
            TransportationCost = order.Product.TransportatoinCost;
            TotalOrderedNumber = order.ProductsNumber;
            TotalOrderedSum = (ProductPrice + TransportationCost) * TotalOrderedNumber;
        }

        [DisplayName("Номер заказа")]
        public int OrderId { get; set; }
        [DisplayName("Наименование")]
        public string ProductName { get; set; }
        [DisplayName("Дата добавления")]
        public DateTime Date { get; set; }
        [DisplayName("Цена")]
        public decimal ProductPrice { get; set; }
        [DisplayName("Доставка за единицу товара")]
        public decimal TransportationCost { get; set; }
        [DisplayName("Всего заказано")]
        public int TotalOrderedNumber { get; set; }
        [DisplayName("Заказано на сумму")]
        public decimal TotalOrderedSum { get; set; }
    }
}
