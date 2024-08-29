namespace SSAdminDashboard.Domain.Products;

using System.ComponentModel.DataAnnotations;

public class ProductComment : IEntity
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int Rating { get; set; } = 0;
}
