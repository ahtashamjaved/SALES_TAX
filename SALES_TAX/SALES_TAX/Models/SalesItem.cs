using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SALES_TAX.Models
{
    public class SalesItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float SalesTax { get; set; }
        public float ImportTax { get; set; }
        public decimal Total { get; set; }
        public bool Imported { get; set; }
        public int ItemCategoryId { get; set; }
        public Category ItemCategory { get; set; }

        public SalesItem()
        {
            Price = 0;
            SalesTax = 0;
            ImportTax = 0;
        }
    }
}
