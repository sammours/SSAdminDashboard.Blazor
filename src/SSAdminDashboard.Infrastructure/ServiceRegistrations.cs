namespace SSAdminDashboard.Infrastructure;

using Microsoft.Extensions.DependencyInjection;
using SSAdminDashboard.Domain.Mails;
using SSAdminDashboard.Domain.Orders;
using SSAdminDashboard.Domain.Products;
using SSAdminDashboard.Domain.Users;
using SSAdminDashboard.Infrastructure.Faker;
using SSAdminDashboard.Infrastructure.Repositories;
using SSAdminDashboard.Infrastructure.UserManagements;

public static class ServiceRegistrations
{
    public static IServiceCollection RegisterDatabase(this IServiceCollection services)
    {
        services.AddDbContext<AdDbContext>();

        var dbContext = services.BuildServiceProvider().GetRequiredService<AdDbContext>();
        MockSeeds.Seeds(dbContext);

        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserProvider, UserProvider>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IMailRepository, MailRepository>();
        return services;
    }
}
