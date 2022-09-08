using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripleG.Server.Models
{
    public class News
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [StringLength(200)]
        public string ImgPath { get; set; }
        [StringLength(20)]
        public string Title { get; set; }
        [StringLength(225)]
        public string Body { get; set; }
        [StringLength(50)]
        [DataType(DataType.DateTime)]
        public DateTime TimeStamp { get; set; }
        public News()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
