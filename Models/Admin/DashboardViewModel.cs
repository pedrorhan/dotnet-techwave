using dotnet_store.Models;
using System.Collections.Generic;

namespace dotnet_store.Models.Admin;

public class DashboardViewModel
{
    public double TotalSales { get; set; }
    public int TotalOrders { get; set; }
    public int TotalProducts { get; set; }
    public int TotalUsers { get; set; }
    public List<Order> RecentOrders { get; set; } = new();
}
