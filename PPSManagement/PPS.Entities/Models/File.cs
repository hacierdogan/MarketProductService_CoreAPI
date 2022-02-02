using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPS.Entities
{
    public class File
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }
        public string RelativePath { get; set; }
        public string FileName { get; set; }
        public string DownloadURLPath { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
