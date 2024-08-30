namespace SSAdminDashboard.Infrastructure;

using Microsoft.EntityFrameworkCore;
using SSAdminDashboard.Domain.Mails;
using SSAdminDashboard.Domain.Orders;
using SSAdminDashboard.Domain.Products;
using SSAdminDashboard.Domain.Profiles;

public class AdDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductComment> ProductComments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Mail> Mails { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Profile> Profiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "AdminDashboard");
    }
}
