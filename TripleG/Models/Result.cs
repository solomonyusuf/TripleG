

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripleG.Server.Models
{
    public class Result
    {
        [Key]
        [Required]
        public Guid ResultId { get; set; }
        [StringLength(10)]
        public string Class { get; set; }
        [StringLength(10)]
        public string Percentage { get; set; }
        [StringLength(10)]
        public string Position { get; set; }
        [StringLength(10)]
        public string Term { get; set; }
        [StringLength(10)]
        public string Session { get; set; }

        public DateTime TimeStamp { get; set; }

        public Result()
        {

            TimeStamp = DateTime.Now;
        }


    }
}
