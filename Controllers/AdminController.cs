using dotnet_store.Models;
using dotnet_store.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace dotnet_store.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly DataContext _context;
    private readonly UserManager<AppUser> _userManager;

    public AdminController(DataContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<ActionResult> Index()
    {
        var model = new DashboardViewModel
        {
            TotalSales = await _context.Orders.SumAsync(o => o.ToplamFiyat),
            TotalOrders = await _context.Orders.CountAsync(),
            TotalProducts = await _context.Urunler.CountAsync(),
            TotalUsers = await _userManager.Users.CountAsync(),
            RecentOrders = await _context.Orders
                .OrderByDescending(o => o.SiparisTarihi)
                .Take(5)
                .ToListAsync()
        };

        return View(model);
    }
}
