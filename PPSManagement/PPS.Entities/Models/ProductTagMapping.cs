using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPS.Entities
{
    public class ProductTagMapping
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MapId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
