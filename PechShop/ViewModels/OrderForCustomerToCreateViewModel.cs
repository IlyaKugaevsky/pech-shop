using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PechShop.Models;

namespace PechShop.ViewModels
{
    public class OrderForCustomerToCreateViewModel
    {
        public OrderForCustomerToCreateViewModel()
        {

        }

        public OrderForCustomerToCreateViewModel(Customer customer, IEnumerable<Product> products)
        {
            CustomerName = customer.GetFullName();
            CustomerId = customer.Id;
            var productList = new List<SelectListItem>();

            ProductList = products.Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToList();
        }

        public int CustomerId { get; set; }
        [DisplayName("Покупатель")] public string CustomerName { get; set; }

        [DisplayName("Номер заказа")] public int OrderId { get; set; }

        public IReadOnlyList<SelectListItem> ProductList { get; set; }
        [DisplayName("Товар")] public string ProductName { get; set; }
        [DisplayName("Количество товаров")] public int ProductsNumber { get; set; }
        [DisplayName("Товар")] public int SelectedProductId { get; set; }
    }
}


