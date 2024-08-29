namespace SSAdminDashboard.Domain.Products;

using System.ComponentModel.DataAnnotations;

public class Product : IEntity
{
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    [Required]
    public ProductCategories Category { get; set; }
    public int StockQuantity { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
    [Required] 
    public int Rating { get; set; } = 1;
    public DateTime ManufactureDate { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public List<string> Images { get; set; } = new();
    public List<ProductComment> Comments { get; set; } = new();

    public decimal FinalPrice()
        => Math.Round(this.Price - ((this.Price * this.Discount) / 100), 2);
}