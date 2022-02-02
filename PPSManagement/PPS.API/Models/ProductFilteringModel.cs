using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPS.API.Models
{
    public class ProductFilteringModel
    {
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string Sku { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
    }
}
