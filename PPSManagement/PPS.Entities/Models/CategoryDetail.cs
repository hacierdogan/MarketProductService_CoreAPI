using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPS.Entities
{
    public class CategoryDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryDetailId { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }

        [Required(ErrorMessage = "Kategori adı alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Kategori adı 50 karakteden uzun olmamalı.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
