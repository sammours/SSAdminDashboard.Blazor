namespace SSAdminDashboard.Infrastructure.Faker;

using SSAdminDashboard.Domain.Profiles;
using Bogus;
public static class MockSeeds
{
    public static void Seeds(AdDbContext dbContext)
    {
        var products = ProductFaker.Create(100);
        dbContext.Products.AddRange(products);
        dbContext.Orders.AddRange(OrderFaker.Create([..products], 100));
        dbContext.Mails.AddRange(MailFaker.Create(200));
        dbContext.Profiles.Add(new Profile
        {
            UserId = "337d3924-761d-4644-b90c-10ef5a5e9107",
            Role = Domain.Users.UserRoles.Admin,
            DateOfBirth = new DateTime(1990, 1, 1),
            IsBlocked = false,
            Id = 1,
            Position = "Developer",
            Avatar = new Faker("en").Person.Avatar
        });
        dbContext.SaveChanges();
    }
}
