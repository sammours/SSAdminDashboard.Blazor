namespace SSAdminDashboard.Infrastructure.Repositories;

using SSAdminDashboard.Domain;
using SSAdminDashboard.Domain.Products;

public class ProductRepository(AdDbContext adDbContext) : Repository<Product>(adDbContext), IProductRepository
{
}
