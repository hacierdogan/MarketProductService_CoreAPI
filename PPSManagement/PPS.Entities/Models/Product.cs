using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPS.Entities
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }


        [Required(ErrorMessage = "Ürün birim alanı zorunludur.")]
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        public string Barcode { get; set; }
        public string Sku { get; set; }
        [Required(ErrorMessage = "Ürün adı alanı zorunludur.")]
        [StringLength(250, ErrorMessage = "Ürün adı 250 karakteden uzun olmamalı.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Ürün fiyat adı alanı zorunludur.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Ürün kategori alanı zorunludur.")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int SourceId { get; set; }
        public virtual Source Source { get; set; }
        public virtual List<ProductDetail> ProductDetails { get; set; }
        public virtual List<ProductTagMapping> ProductTagMappings { get; set; }
        public virtual List<File> Files { get; set; }
    }
}
