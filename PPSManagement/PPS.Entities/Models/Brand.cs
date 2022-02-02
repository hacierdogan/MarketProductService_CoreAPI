using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPS.Entities
{
    public class Brand
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Marka adı alanı zorunludur.")]
        [StringLength(50,ErrorMessage ="Marka adı 50 karakteden uzun olmamalı.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public virtual List<File> Files { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
