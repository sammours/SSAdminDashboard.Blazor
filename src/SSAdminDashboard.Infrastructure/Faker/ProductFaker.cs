namespace SSAdminDashboard.Infrastructure.Faker;

using Bogus;
using Bogus.DataSets;
using SSAdminDashboard.Domain.Products;

public static class ProductFaker
{
    public static List<Product> Create(int count = 100)
    {
        var faker = new Faker<Product>()
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()))
            .RuleFor(p => p.Discount, f => f.Random.Number(max: 100))
            .RuleFor(p => p.Category, f => f.Random.Enum<ProductCategories>())
            .RuleFor(p => p.StockQuantity, f => f.Random.Number(max: 200))
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Manufacturer, f => f.Commerce.Department())
            .RuleFor(p => p.Material, f => f.Commerce.ProductMaterial())
            .RuleFor(p => p.Rating, f => f.Random.Number(min: 1, max: 5))
            .RuleFor(p => p.ManufactureDate, f => f.Date.Past())
            .RuleFor(p => p.Images, f => Enumerable.Range(0, 3).Select(x => f.Image.LoremFlickrUrl(keywords: "device")).ToList())
            .RuleFor(p => p.Barcode, f => f.Commerce.Ean13());

        return faker.Generate(count);
    }
}