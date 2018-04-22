using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PechShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }
        [DisplayName("Цена")]
        public double Price { get; set; }
        [DisplayName("Минимальное количество")]
        public int MinimalNumber { get; set; }
        [DisplayName("Ссылка")]
        public string Url { get; set; }

        public List<Order> Orders { get; set; }
    }
}
