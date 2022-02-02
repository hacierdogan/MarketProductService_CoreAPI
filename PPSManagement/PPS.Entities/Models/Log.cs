using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPS.Entities
{
    public class Log
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

    }
}
