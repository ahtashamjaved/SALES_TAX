using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SALES_TAX.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool SalesTax { get; set; }
        public float SalesTaxPercentage { get; set; }
        public bool ImportTax { get; set; }
        public float ImportTaxPercentage { get; set; }

    }
}
