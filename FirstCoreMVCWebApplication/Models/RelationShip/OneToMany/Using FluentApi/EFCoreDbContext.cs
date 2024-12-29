using Microsoft.EntityFrameworkCore;

namespace FirstCoreMVCWebApplication.Models.RelationShip.OneToMany.Using_FluentApi
{
    public class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=LAPTOP-6P5NK25R\SQLSERVER2022DEV;Database=OrderDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>() //Refers to the Order entity.
                .HasMany(o => o.OrderItems) // Order has many OrderItems
                .WithOne(oi => oi.Order)    // Each OrderItem has one Order
                .HasForeignKey(oi => oi.OrderId); // OrderId is the FK in OrderItem
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}

