namespace SSAdminDashboard.Infrastructure.Faker;

public static class MockSeeds
{
    public static void Seeds(AdDbContext dbContext)
    {
        dbContext.Products.AddRange(ProductFaker.Create(100));
        dbContext.SaveChanges();
    }
}
