using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PPS.Entities
{
    public class Category
    {
        //public Category()
        //{
        //    SubCategories = new List<SubCategoryModel>();
        //}

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Kategori adı alanı zorunludur.")]
        [StringLength(50,ErrorMessage ="Kategori adı 50 karakterden uzun olmamalı")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentCategoryId { get; set; }
        public bool Status { get; set; }
        public virtual List<CategoryDetail> CategoryDetails { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<File> Files { get; set; }

        //public List<SubCategoryModel> SubCategories { get; set; }
        //public partial class SubCategoryModel
        //{
        //    public virtual int SubCaregoryId { get; set; }
        //    public string Name { get; set; }
        //}
    }
}
