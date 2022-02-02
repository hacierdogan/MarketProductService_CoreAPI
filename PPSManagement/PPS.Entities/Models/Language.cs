using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPS.Entities
{
   public class Language
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageId { get; set; }


        [Required(ErrorMessage = "Dil adı alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Dil adı 50 karakteden uzun olmamalı.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Dil kodu alanı zorunludur.")]
        [StringLength(2,MinimumLength =2, ErrorMessage = "Dil kodu 2 karakterde olmalı.")]
        public string ShortCode { get; set; }
        public virtual List<CategoryDetail> CategoryDetails { get; set; }
        public virtual List<ProductDetail> ProductDetails { get; set; }
        public virtual List<UnitDetail> UnitDetails { get; set; }
    }
}
