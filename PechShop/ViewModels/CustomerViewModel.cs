using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using PechShop.Models;

namespace PechShop.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel(Customer customer)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            PhoneNumber = customer.PhoneNumber;
            AdditionalInfo = customer.AdditionalInfo;
            TotalMoney = customer.GetTotalMoney();
        }


        public int Id { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Телефон")]
        public string PhoneNumber { get; set; }
        [DisplayName("Доп. информация")]
        public string AdditionalInfo { get; set; }
        [DisplayName("Заказано на сумму")]
        public decimal TotalMoney { get; set; }

        public List<Order> Orders;

        public string GetFullName() => string.Join(' ', FirstName, LastName);

    }
}
