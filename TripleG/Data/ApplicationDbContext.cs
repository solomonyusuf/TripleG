using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TripleG.Server.Models;

namespace TripleG.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ApplicationUser> User { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<ParentInfo> ParentInfo { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentHub> StudentHub { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<StudentResult> StudentResult { get; set; }
        public DbSet<TripleG.Server.Models.UserRole> UserRole { get; set; }
        public DbSet<TripleG.Server.Models.Role> Role { get; set; }
    }
}
