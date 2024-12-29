using Microsoft.EntityFrameworkCore;

namespace FirstCoreMVCWebApplication.Models.RelationShip.ManyToMany
{
    public class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuring the Connection String
            //  optionsBuilder.UseSqlServer(@"Server=LAPTOP-6P5NK25R\SQLSERVER2022DEV;Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId }); // Composite Key for Join Table
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses) // Navigation Property in Student
                .HasForeignKey(sc => sc.StudentId); //Foreign Key
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses) // Navigation Property in Course
                .HasForeignKey(sc => sc.CourseId); //Foreign Key
            // Explicitly configure the join table name
            modelBuilder.Entity<StudentCourse>().ToTable("StudentCourses");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
