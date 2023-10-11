using E_LearningTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningTask.Data
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=.;Database=E-LearningSystem;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeedBackCourse>()
                .HasKey(nameof(Student.StudentId), nameof(Course.CourseId));
            modelBuilder.Entity<StudentCourse>()
                .HasKey(nameof(Student.StudentId), nameof(Course.CourseId));
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<FeedBackCourse> FeedBacks { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set;}
    }
}
