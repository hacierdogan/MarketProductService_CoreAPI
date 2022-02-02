using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPS.Entities
{
    public class Source
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SourceId { get; set; }
        [Required(ErrorMessage = "Kaynak adı alanı zorunludur.")]
        [StringLength(250, ErrorMessage = "Kaynak adı 250 karakteden uzun olmamalı.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
