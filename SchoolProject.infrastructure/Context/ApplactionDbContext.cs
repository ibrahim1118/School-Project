using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Data.IdentityEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infrastructure.Data
{
    public class ApplactionDbContext : IdentityDbContext<AppUser>
    {
        public ApplactionDbContext()
        {
            

        }
        public ApplactionDbContext(DbContextOptions<ApplactionDbContext> options)  :base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmetSubject>().HasKey(x => new { x.SubID, x.DID }); 
            modelBuilder.Entity<Ins_Subject>().HasKey(x => new { x.InsID, x.SubId }); 
            modelBuilder.Entity<StudentSubject>().HasKey(x => new { x.StudID, x.SubID }); 
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> students { get; set; }


        public DbSet<Department> departments { get; set; }

        public DbSet<Subjects> subjects { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }

        public DbSet<DepartmetSubject> departmetSubjects { get; set;}
        public DbSet<Instructor> instructors { get; set; }   
        public DbSet<Ins_Subject> insSubjects { get; set; } 
    }
}
