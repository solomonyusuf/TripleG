using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripleG.Server.Models
{
    public class StudentResult
    {
        [Key]
        [Required]
        public Guid ResultId { get; set; }
        public Guid StudentId { get; set; }


    }
}
