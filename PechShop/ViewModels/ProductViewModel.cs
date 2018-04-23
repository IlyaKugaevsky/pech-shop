﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using PechShop.Models;

namespace PechShop.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            
        }
        public ProductViewModel(Product product, int remainNumber)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            MinimalNumber = product.MinimalNumber;
            Url = product.Url;
            TransportatoinCost = product.TransportatoinCost;
            AdditionalInfo = product.AdditionalInfo;
            RemainNumber = remainNumber;

            BootstrapColor = RemainNumber > 0 ? "danger" : "success";
        }

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
        public decimal TransportatoinCost { get; set; } = 0;
        [DisplayName("Доп. информация")]
        public string AdditionalInfo { get; set; }
        [DisplayName("Остаток")]
        public int RemainNumber { get; set; }

        public string BootstrapColor { get; }
    }
}
