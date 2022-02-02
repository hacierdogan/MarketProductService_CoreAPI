using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPS.Entities
{
    public class ProductDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductDetailId { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }

        [Required(ErrorMessage = "Ürün adı alanı zorunludur.")]
        [StringLength(250, ErrorMessage = "Ürün adı 250 karakteden uzun olmamalı.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
