using FirstCoreMVCWebApplication.Models.BrainStationEmployeeModel;
using Microsoft.EntityFrameworkCore;

namespace FirstCoreMVCWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // For ContentType enum
            modelBuilder.Entity<Employee>()
                .Property(c => c.Gender)
                .HasConversion<string>()
                .IsRequired();    // Optional: Specify if the property is required
            // Seeding Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, Name = "IT" },
                new Department { DepartmentId = 2, Name = "HR" },
                new Department { DepartmentId = 3, Name = "Payroll" },
                new Department { DepartmentId = 4, Name = "Admin" }
            );
            // Seeding SkillSets
            modelBuilder.Entity<SkillSet>().HasData(
                new SkillSet { SkillSetId = 1, SkillName = "Dot Net" },
                new SkillSet { SkillSetId = 2, SkillName = "Java" },
                new SkillSet { SkillSetId = 3, SkillName = "Python" },
                new SkillSet { SkillSetId = 4, SkillName = "PHP" },
                new SkillSet { SkillSetId = 5, SkillName = "Database" }
            );
            // Seed JobTitles
            modelBuilder.Entity<JobTitle>().HasData(
                new JobTitle { JobTitleId = 1, TitleName = "Software Engineer" },
                new JobTitle { JobTitleId = 2, TitleName = "Project Manager" },
                new JobTitle { JobTitleId = 3, TitleName = "Quality Assurance Engineer" },
                new JobTitle { JobTitleId = 4, TitleName = "Business Analyst" },
                new JobTitle { JobTitleId = 5, TitleName = "System Administrator" }
                // Add more job titles as needed
            );
        }
        // DbSets for each model
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<SkillSet> SkillSets { get; set; }
        public DbSet<JobDetail> JobDetails { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
    }
}
