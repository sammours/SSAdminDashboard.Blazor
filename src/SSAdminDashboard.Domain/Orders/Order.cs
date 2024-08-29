namespace SSAdminDashboard.Domain.Orders;

using SSAdminDashboard.Domain.Products;
using System;
using System.Collections.Generic;

public class Order : IEntity
{
    public long Id { get; set; }
    public DateTime Date { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public int ItemCount { get => this.Items.Count; }
    public string ShippingAddress { get; set; } = string.Empty;
    public string BillingAddress { get; set; } = string.Empty;
    public OrderStatus OrderStatus { get; set; }
    public List<OrderItem> Items { get; set; } = new();

    public void AddItem(OrderItem item)
    {
        this.Items.Add(item);
        this.TotalAmount += item.Price * item.Quantity;
    }
}