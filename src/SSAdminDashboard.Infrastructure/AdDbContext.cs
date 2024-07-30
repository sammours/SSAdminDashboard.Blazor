namespace SSAdminDashboard.Infrastructure;

using Microsoft.EntityFrameworkCore;
using SSAdminDashboard.Domain.Products;
using SSAdminDashboard.Domain.Users;

public class AdDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "AdminDashboard");
    }
}
