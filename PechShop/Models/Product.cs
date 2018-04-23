using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PechShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DisplayName("Минимальное количество")]
        public int MinimalNumber { get; set; }
        [DisplayName("Ссылка")]
        public string Url { get; set; }
        [DisplayName("Доставка за единицу товара")]
        public decimal TransportatoinCost { get; set; }
        [DisplayName("Доп. информация")]
        public string AdditionalInfo { get; set; }


        public List<Order> Orders { get; set; }
    }
}
