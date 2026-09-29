using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet_store.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;
    public HomeController(DataContext context)
    {
        _context=context;
    }

    public async Task<ActionResult> Index()
    {
        var urunler = await _context.Urunler.Where(urun => urun.Aktif && urun.Anasayfa).ToListAsync();
        ViewData["Kategoriler"] = await _context.Kategoriler.ToListAsync();
        return View(urunler);
    }
}
