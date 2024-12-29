using Microsoft.EntityFrameworkCore;

namespace FirstCoreMVCWebApplication.Models.RelationShip.OneToOne.Using_FluentApi
{
    public class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuring the Connection String
            // optionsBuilder.UseSqlServer(@"Server=LAPTOP-6P5NK25R\SQLSERVER2022DEV;Database=PassportDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Using Fluent API to define entity relationships within the OnModelCreating method.
            // Start configuring the User entity
            modelBuilder.Entity<User>() //Refers to the User entity
                                        // Specifies that the User entity has a one-to-one relationship with a Passport entity, meaning each User has one Passport.
                .HasOne(u => u.Passport)
                // Specifies that the Passport entity is also related to exactly one User entity, making the relationship bidirectional.
                .WithOne(p => p.User)
                // Sets the UserId property in the Passport entity as the foreign key that references the User entity's primary key.
                .HasForeignKey<Passport>(p => p.UserId);
        }
        // Defining a DbSet for Users, representing the Users table in the database
        public DbSet<User> Users { get; set; }
        // Defining a DbSet for Passports, representing the Passports table in the database
        public DbSet<Passport> Passports { get; set; }
    }
}
