using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TripleG.Server.Models
{
    public class ParentInfo

    {
        [Key]
        [Required]
        public Guid ParentId { get; set; }
        [StringLength(50)]
        public string ParentName { get; set; }
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(15)]
        public string Occupation { get; set; }
        [StringLength(12)]
        public string City { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        public string PhoneNumber_1 { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        public string PhoneNumber_2 { get; set; }
        [StringLength(50)]
        public string Address_1 { get; set; }
        [StringLength(50)]
        public string Address_2 { get; set; }
        public Guid StudentId { get; set; }



    }
}
