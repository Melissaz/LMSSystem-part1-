using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LMSSystem.Model
{
    public class CourseDBContext:DbContext
    {
        public DbSet<CourseDto> Courses { get; set; }
        public DbSet<CourseDetail> CourseDetail { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCheckIn> StudentCheckIns { get; set; }

        public CourseDBContext(DbContextOptions<CourseDBContext> options) : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Course
            modelBuilder.Entity<CourseDto>().Property(a => a.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CourseDto>().HasKey(a => a.Id);
            //Course Detail 1 to 1
            modelBuilder.Entity<CourseDetail>().Property(a => a.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CourseDetail>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<CourseDto>()
                .HasOne(course => course.CourseDetail)
                .WithOne(coursedetail => coursedetail.Course)
                .HasForeignKey<CourseDetail>(coursedetail => coursedetail.CourseId);

            //Student
            modelBuilder.Entity<Student>()
                .Property(a => a.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Student>()
                .HasKey(a => a.Id);

            //StudentInCourse many to many
            modelBuilder.Entity<StudentCheckIn>()
                .HasKey(a => new { a.CourseId, a.StudentId });

            modelBuilder.Entity<StudentCheckIn>()
                .HasOne(a => a.CourseDto)
                .WithMany(b => b.StudentCheckIns)
                .HasForeignKey(bc => bc.CourseId);

            modelBuilder.Entity<StudentCheckIn>()
                .HasOne(bc => bc.Student)
                .WithMany(b => b.StudentCheckIns)
                .HasForeignKey(bc => bc.StudentId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;userid=root;pwd=mypassword;port=3306;database=lmssystem;sslmode=none";
            optionsBuilder.UseMySQL(connectionString);
            base.OnConfiguring(optionsBuilder); 
        }

    }
}
