using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SALES_TAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SALES_TAX.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SalesTaxController : ControllerBase
    {
        private static readonly Category[] Categories = new Category[]
        {
            new Category{ Id = 1, Name = "Book", SalesTax = false, SalesTaxPercentage = 0, ImportTax = true, ImportTaxPercentage = 5 },
            new Category{ Id = 2, Name = "Medical", SalesTax = false, SalesTaxPercentage = 0, ImportTax = true, ImportTaxPercentage = 5 },
            new Category{ Id = 3, Name = "Food", SalesTax = false, SalesTaxPercentage = 0, ImportTax = true, ImportTaxPercentage = 5 },
            new Category{ Id = 4, Name = "Entertainment", SalesTax = true, SalesTaxPercentage = 10, ImportTax = true, ImportTaxPercentage = 5 },
            new Category{ Id = 5, Name = "Others", SalesTax = true, SalesTaxPercentage = 10, ImportTax = true, ImportTaxPercentage = 5 },
        };

        private static readonly SalesItem[] Products = new SalesItem[]
        {
            new SalesItem{ Id = 1, Name = "Book", SalesTax = 0, Price = 12.49f, ItemCategoryId = 1, Imported = false},
            new SalesItem{ Id = 2, Name = "Music CD", SalesTax = 10, Price = 14.99f, ItemCategoryId = 4, Imported = false},
            new SalesItem{ Id = 3, Name = "Chocolate Bar", SalesTax = 0, Price = 0.85f, ItemCategoryId = 3, Imported = false},
            new SalesItem{ Id = 4, Name = "Box of Chocolates", SalesTax = 0, Price = 10.00f, ItemCategoryId = 3, Imported = true},
            new SalesItem{ Id = 5, Name = "Perfume A", SalesTax = 10, Price = 47.50f, ItemCategoryId = 5, Imported = true},
            new SalesItem{ Id = 6, Name = "Perfume B", SalesTax = 10, Price = 27.99f, ItemCategoryId = 5, Imported = true},
            new SalesItem{ Id = 7, Name = "Perfume C", SalesTax = 10, Price = 18.99f, ItemCategoryId = 5, Imported = false},
            new SalesItem{ Id = 8, Name = "Headache Pills", SalesTax = 0, Price = 9.75f, ItemCategoryId = 2, Imported = false},
            new SalesItem{ Id = 9, Name = "Chocolates", SalesTax = 0, Price = 11.25f, ItemCategoryId = 3, Imported = true},

        };

        private readonly ILogger<SalesTaxController> _logger;

        public SalesTaxController(ILogger<SalesTaxController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return Categories;
        }

        [HttpGet]
        public IEnumerable<SalesItem> GetProducts()
        {
            return Products;
        }

        [HttpPost]
        public IActionResult Calculate([FromBody] List<SalesItem> items)
        {
            SalesReceiptDTO obj = new SalesReceiptDTO();
            foreach (SalesItem item in items)
            {
                Category category = Categories.FirstOrDefault(p => p.Id == item.ItemCategoryId);
                if (category.SalesTax)
                    item.SalesTax = item.Price * category.SalesTaxPercentage / 100;
                if (item.Imported)
                    item.ImportTax = item.Price * category.ImportTaxPercentage / 100;

                item.Total = Math.Round(Convert.ToDecimal((item.Price + item.SalesTax + item.ImportTax) * item.Quantity), 2);

            }

            obj.Item = items;
            obj.Total = items.Sum(p => p.Total);

            return Ok(obj);
            
        }

    }
}
