using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripleG.Server.Models
{
    public class Payment
    {
        [Key]
        [Required]
        public Guid PaymentId { get; set; }
        public string Name { get; set; }
        public string Term { get; set; }
        public string Class { get; set; }
        public ICollection<StudentHub> Students { get; set; }
        public Payment()
        {
            Students = new Collection<StudentHub>();
        }
    }
}
