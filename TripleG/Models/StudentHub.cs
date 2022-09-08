using System;
using System.ComponentModel.DataAnnotations;

namespace TripleG.Server.Models
{
    public class StudentHub
    {
        [Key]
        public Guid SubjectId { get; set; }
        public Guid StudentId { get; set; }
        public Guid ResultId { get; set; }
        public string Name { get; set; }
        public string FirstTest { get; set; }
        public string SecondTest { get; set; }
        public string ExamScore { get; set; }
        public string Total { get; set; }
        public string Grade { get; set; }
    }
}
