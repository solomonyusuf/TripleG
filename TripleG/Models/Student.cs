using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripleG.Server.Models
{
    public class Student
    {
        [Key]
        [Required]
        public Guid StudentId { get; set; }
        public string ResultId { get; set; }
        public string ParentId { get; set; }
        [StringLength(3000000)]
        public string ImgPath { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(20)]
        public string MiddleName { get; set; }
        [StringLength(20)]
        public string Class { get; set; }
        [StringLength(10)]
        public string Sex { get; set; }
        [StringLength(20)]
        public string DOB { get; set; }
        [StringLength(10)]
        public string OriginState { get; set; }
        public ICollection<ParentInfo> Parent { get; }
        public int TotalResult { get; }
        public DateTime TimeStamp { get; set; }


        public Student()
        {
            Parent = new Collection<ParentInfo>();

            TimeStamp = DateTime.Now;
        }
    }
}
