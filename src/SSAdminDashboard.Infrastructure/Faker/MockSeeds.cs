namespace SSAdminDashboard.Infrastructure.Faker;

public static class MockSeeds
{
    public static void Seeds(AdDbContext dbContext)
    {
        var products = ProductFaker.Create(100);
        dbContext.Products.AddRange(products);
        dbContext.Orders.AddRange(OrderFaker.Create([..products], 100));
        dbContext.Mails.AddRange(MailFaker.Create(200));
        dbContext.SaveChanges();
    }
}
