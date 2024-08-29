namespace SSAdminDashboard.Domain.Orders;

using SSAdminDashboard.Domain.Products;

public class OrderItem : IEntity
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
