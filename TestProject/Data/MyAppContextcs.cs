using Microsoft.EntityFrameworkCore;
using TestProject.Models;
namespace TestProject.Data
{
    public class MyAppContextcs : DbContext 

    {

        public MyAppContextcs(DbContextOptions<MyAppContextcs> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         
            modelBuilder.Entity<Student_Course>()
       .HasKey(sc => new { sc.StudentId, sc.CourseId }); // Khóa chính kép


        } 


        public DbSet<Item> Items { get; set; }
        public  DbSet  <SerialNumber>    serialNumbers { get; set; }  
        public   DbSet   <Category>    Categories { get; set; }

         public  DbSet<Student> Students { get; set; }
          public  DbSet<Course> Courses { get; set; }
         public DbSet<Student_Course> Student_Courses { get; set; }



        }
}
