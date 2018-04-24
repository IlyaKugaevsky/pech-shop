using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PechShop.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Телефон")]
        public string PhoneNumber { get; set; }
        [DisplayName("Доп. информация")]
        public string AdditionalInfo { get; set; }

        public List<Order> Orders { get; set; }

        public string GetFullName() => string.Join(' ', LastName, FirstName);
        public decimal GetTotalMoney() => Orders.Select(o => o.ProductsNumber * (o.Product.Price + o.Product.TransportationCost)).Sum();
    }
}