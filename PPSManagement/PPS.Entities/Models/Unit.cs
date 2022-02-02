using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPS.Entities
{
    public class Unit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnitId { get; set; }


        [Required(ErrorMessage = "Birim adı alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Birim adı 50 karakteden uzun olmamalı.")]
        public string Name { get; set; }


        public string Description { get; set; }


        [Required(ErrorMessage = "Birim kodu alanı zorunludur.")]
        [StringLength(10, ErrorMessage = "Ürün adı 10 karakteden uzun olmamalı.")]
        public string ShortCode { get; set; }


        public bool Status { get; set; }

        public virtual List<UnitDetail> UnitDetails { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
