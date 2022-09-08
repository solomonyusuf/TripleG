using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripleG.Server.Models
{
    public class Contact
    {
        [Key]
        [Required]
        public Guid id { get; set; }
        [StringLength(20)]
        public string FullName { get; set; }
        [StringLength(20)]
        public string Email { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(200)]
        public string Message { get; set; }
    }
}
