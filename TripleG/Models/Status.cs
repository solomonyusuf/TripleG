using System;
using System.ComponentModel.DataAnnotations;

namespace TripleG.Server.Models
{
    public class Status
    {
        [Key]
        [Required]
        public Guid PaymentId { get; set; }
        public Guid StudentId { get; set; }
    }
}
