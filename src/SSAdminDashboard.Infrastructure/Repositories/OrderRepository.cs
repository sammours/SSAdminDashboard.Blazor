namespace SSAdminDashboard.Infrastructure.Repositories;

using SSAdminDashboard.Domain;
using SSAdminDashboard.Domain.Orders;
using SSAdminDashboard.Domain.Products;

public class OrderRepository(AdDbContext adDbContext) : Repository<Order>(adDbContext), IOrderRepository
{
}
