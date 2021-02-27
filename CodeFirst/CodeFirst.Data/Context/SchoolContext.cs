using CodeFirst.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using CodeFirst.Data.Entities.Canteen;

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
        public DbSet<Section> Sections { get; set; }
        public DbSet<SubSection> SubSections { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

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


            modelBuilder.Entity<Section>()
                .HasMany(x => x.SubSections)
                .WithOne(x => x.Section).HasForeignKey(x => x.SectionCode);

            #region Composite Key

            modelBuilder.Entity<Product>().Property(x => x.Code).ValueGeneratedNever();
            modelBuilder.Entity<Category>().Property(x => x.Code).ValueGeneratedNever();
            modelBuilder.Entity<SubCategory>().Property(x => x.Code).ValueGeneratedNever();

            modelBuilder.Entity<Product>().HasKey(x => x.Code);
            modelBuilder.Entity<Category>().HasKey(x => new { x.Code, x.ProductCode });
            modelBuilder.Entity<SubCategory>().HasKey(x => new { x.Code, x.CategoryCode, x.ProductCode });

            modelBuilder.Entity<Product>().HasMany(x => x.Categories).WithOne();
            modelBuilder.Entity<Category>().HasMany(x => x.SubCategories).WithOne().HasForeignKey(x => new { x.CategoryCode, x.ProductCode });

            #endregion


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

        public static void EnsureCreated(IServiceProvider provider)
        {
            var context = provider.GetService<SchoolContext>();
            context.Database.Migrate();
        }
    }
}
