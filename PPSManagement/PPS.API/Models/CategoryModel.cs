using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPS.API.Models
{
    public class CategoryModel
    {
        //public CetagoryModel()
        //{
        //    SubCategories = new List<SubCategoryModel>();
        //}
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        public bool Status { get; set; }
        public int SubCategoryCount { get; set; }
        public int ProductCount { get; set; }

        //public List<SubCategoryModel> SubCategories { get; set; }
        //public partial class SubCategoryModel
        //{
        //    public virtual int SubCaregoryId { get; set; }
        //    public string SubCaregoryName { get; set; }
        //}
    }
}
