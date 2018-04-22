using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PechShop.Models;

namespace PechShop.ViewModels
{
    public class OrderToUpdateViewModel
    {
        public OrderToUpdateViewModel()
        {

        }

        public OrderToUpdateViewModel(IEnumerable<Customer> customers, IEnumerable<Product> products, Order order = null)
        {
            if (order != null) ProductsNumber = order.ProductsNumber;

            var customerList = new List<SelectListItem>();
            var productList = new List<SelectListItem>();

            CustomerList = customers.Select(c => new SelectListItem()
            {
                Text = string.Join(' ',c.FirstName, c.LastName),
                Value = c.Id.ToString()
            }).ToList();

            ProductList = products.Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToList();
        }

        [DisplayName("Товар")]
        public string ProductName { get; set; }
        [DisplayName("Покупатель")]
        public string CustomerName { get; set; }


        [DisplayName("Количество товаров")]
        public int ProductsNumber { get; set; }

        [DisplayName("Номер заказа")]
        public int OrderId { get; set; }

        public IReadOnlyList<SelectListItem> CustomerList { get; set; }
        public IReadOnlyList<SelectListItem> ProductList { get; set; }

        [DisplayName("Покупатель")]
        public int SelectedCustomerId { get; set; }
        [DisplayName("Товар")]
        public int SelectedProductId { get; set; }
    }
}
