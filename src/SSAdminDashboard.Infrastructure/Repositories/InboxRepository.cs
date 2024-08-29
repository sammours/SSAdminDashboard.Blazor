namespace SSAdminDashboard.Infrastructure.Repositories;

using SSAdminDashboard.Domain;
using SSAdminDashboard.Domain.Mails;
using SSAdminDashboard.Domain.Orders;
using SSAdminDashboard.Domain.Products;

public class MailRepository(AdDbContext adDbContext) : Repository<Mail>(adDbContext), IMailRepository
{
}
