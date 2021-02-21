using CodeFirst.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Data.Context
{
    public class SchoolContext :DbContext
    {
        public static readonly Grade alfa = new Grade  { GradeId = 1, Name = "A-1" };
        public static readonly Grade alfa2 = new Grade { GradeId = 2, Name = "A-2" };  
        public static readonly Grade beta = new Grade  { GradeId = 3, Name = "B-1" };
        public static readonly Grade beta2 = new Grade { GradeId = 4, Name = "B-2" };
        public SchoolContext(DbContextOptions<SchoolContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("School");

            modelBuilder.Entity<Student>().HasIndex(x => x.StudentId).IsUnique();
            modelBuilder.Entity<StudentCourse>().HasKey(x => new { x.StudentId, x.CourseId });
            #region Relations
            modelBuilder.Entity<Student>()
                .HasOne(x => x.Grade)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.GradeCode);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(x => x.Student)
                .WithMany(x => x.StudentCourses)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(x => x.Course)
                .WithMany(x => x.StudentCourses)
                .HasForeignKey(x => x.CourseId);

            #endregion

            #region Method 
            HasData(modelBuilder);
            #endregion
        }

        protected virtual void HasData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>().HasData(alfa);
            modelBuilder.Entity<Grade>().HasData(alfa2);
            modelBuilder.Entity<Grade>().HasData(beta);
            modelBuilder.Entity<Grade>().HasData(beta2);
        }
    }
}
