using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPS.Entities
{
    public class UnitDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnitDetailId { get; set; }
        [Required(ErrorMessage = "Birim adı alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Birim adı 50 karakteden uzun olmamalı.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
