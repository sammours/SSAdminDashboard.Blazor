namespace SSAdminDashboard.Infrastructure.Faker;

using Bogus;
using SSAdminDashboard.Domain.Orders;
using SSAdminDashboard.Domain.Products;

public static class OrderFaker
{
    public static List<Order> Create(Product[] products, int count = 100)
    {
        Random random = new Random();

        var faker = new Faker<Order>()
            .RuleFor(p => p.Date, f => f.Date.Past())
            .RuleFor(p => p.CustomerName, f => f.Person.FullName)
            .RuleFor(p => p.ShippingAddress, f => f.Address.FullAddress())
            .RuleFor(p => p.BillingAddress, f => f.Address.FullAddress())
            .RuleFor(p => p.OrderStatus, f => f.Random.Enum<OrderStatus>());

        var orders = faker.Generate(count);
        var id = 1;
        foreach(var order in orders)
        {
            for (int i = 0; i < random.Next(0, 10); i++)
            {
                var product = products[random.Next(0, products.Length)];
                order.AddItem(new OrderItem
                {
                    Id = id,
                    Price = product.Price,
                    ProductName = product.Name,
                    ProductId = product.Id,
                    Quantity = random.Next(1, 50)
                });
                id++;
            }
        }

        return orders;
    }
}