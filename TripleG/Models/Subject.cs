

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripleG.Server.Models
{
    public class Subject
    {
        [Key]
        [Required]
        public Guid SubjectId { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        public string FirstTest { get; set; }
        public string SecondTest { get; set; }
        public string Attendance { get; set; }
        public string ExamScore { get; set; }
        public string Total { get; set; }
        public string ClassHighest { get; set; }

        public string ClassLowest { get; set; }

        public string Percentage { get; set; }
        public string Position { get; set; }
        public string Grade { get; set; }



        public DateTime TimeStamp { get; set; }

        public Subject()
        {

            TimeStamp = DateTime.Now;
        }


    }
}
