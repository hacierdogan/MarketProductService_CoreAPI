using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPS.API.Models
{
    public class BrandModel
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        public int ProductCount { get; set; }
    }
}
