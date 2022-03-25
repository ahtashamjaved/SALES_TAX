using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SALES_TAX.Models
{
    public class SalesReceiptDTO
    {
        public int Id { get; set; }
        public List<SalesItem> Item { get; set; }
        public decimal Total { get; set; }

        public SalesReceiptDTO()
        {
            Item = new List<SalesItem>();
            Total = 0;
        }
    }
}
