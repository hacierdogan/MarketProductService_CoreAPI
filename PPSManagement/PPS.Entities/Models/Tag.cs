using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPS.Entities
{
    public class Tag
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
        [StringLength(50, ErrorMessage = "Etiket 50 karakteden uzun olmamalı.")]
        public string Title { get; set; }
        public virtual List<ProductTagMapping> ProductTagMappings { get; set; }
    }
}
