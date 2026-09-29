using System.Threading.Tasks;
using dotnet_store.Models;
using dotnet_store.Services;
using Iyzipay;
using Iyzipay.Request;
using Iyzipay.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

[Authorize]
public class OrderController : Controller
{
    private ICartService _cartService;
    private readonly IConfiguration _configuration;
    private readonly DataContext _context;

    public OrderController(ICartService cartService, DataContext context, IConfiguration configuration)
    {
        _cartService = cartService;
        _context = context;
        _configuration = configuration;
    }
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Index()
    {

        return View(await _context.Orders.ToListAsync());
    }
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Details(int id)
    {
        var order = await _context.Orders.Include(i => i.OrderItems).ThenInclude(i => i.Urun).FirstOrDefaultAsync(i => i.Id == id);
        return View(order);
    }
    public async Task<ActionResult> Checkout()
    {
        ViewBag.Cart = await _cartService.GetCart(User.Identity?.Name!);
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Checkout(OrderCreateModel model)
    {
        var username = User.Identity?.Name!;
        var cart = await _cartService.GetCart(username);

        if (cart.CartItems.Count == 0)
        {
            ModelState.AddModelError("", "Sepetinizde ürün yok");
        }

        if (ModelState.IsValid)
        {
            var order = new Order
            {
                AdSoyad = model.AdSoyad,
                Email = model.Email,
                Telefon = model.Telefon,
                AdresSatiri = model.AdresSatiri,
                PostaKodu = model.PostaKodu,
                Sehir = model.Sehir,
                SiparisNotu = model.SiparisNotu!,
                SiparisTarihi = DateTime.Now,
                ToplamFiyat = cart.Toplam(),
                Username = username,
                OrderItems = cart.CartItems.Select(ci => new Models.OrderItem
                {
                    UrunId = ci.UrunId,
                    Fiyat = ci.Urun.fiyat,
                    Miktar = ci.Miktar
                }).ToList()
            };

            var payment = await ProccesPayment(model, cart);
            if (payment.Status == "success")
            {
                _context.Orders.Add(order);
                _context.Carts.Remove(cart);

                await _context.SaveChangesAsync();

                return RedirectToAction("Completed", new { orderId = order.Id });
            }
            else
            {
                ModelState.AddModelError("", payment.ErrorMessage);
            }

        }

        ViewBag.Cart = cart;
        return View(model);
    }

    public ActionResult Completed(string orderId)
    {
        return View("Completed", orderId);
    }

    public async Task<ActionResult> OrderList()
    {
        var username = User.Identity?.Name;
        var orders = await _context.Orders
        .Include(o => o.OrderItems)
        .ThenInclude(i => i.Urun)
        .Where(o => o.Username == username)
        .ToListAsync();
        return View(orders);
    }

    private async Task<Payment> ProccesPayment(OrderCreateModel model, Cart cart)
    {
        Options options = new Options();
        options.ApiKey = _configuration["PaymentAPI:ApiKey"];
        options.SecretKey = _configuration["PaymentAPI:SecretKey"];
        options.BaseUrl = "https://sandbox-api.iyzipay.com";

        CreatePaymentRequest request = new CreatePaymentRequest();
        request.Locale = Locale.TR.ToString();
        request.ConversationId = Guid.NewGuid().ToString();
        request.Price = cart.AraToplam().ToString();
        request.PaidPrice = cart.Toplam().ToString();
        request.Currency = Currency.TRY.ToString();
        request.Installment = 1;
        request.BasketId = "B67832";
        request.PaymentChannel = PaymentChannel.WEB.ToString();
        request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

        PaymentCard paymentCard = new PaymentCard();
        paymentCard.CardHolderName = @model.CardName;
        paymentCard.CardNumber = @model.CardNumber;
        paymentCard.ExpireMonth = @model.CardExpirationMonth;
        paymentCard.ExpireYear = @model.CardExpirationYear;
        paymentCard.Cvc = @model.CardCVV;
        paymentCard.RegisterCard = 0;
        request.PaymentCard = paymentCard;

        var nameParts = model.AdSoyad.Trim().Split(' ');
        var firstName = nameParts.Length > 1 ? string.Join(" ", nameParts.Take(nameParts.Length - 1)) : model.AdSoyad;
        var lastName = nameParts.Length > 1 ? nameParts.Last() : "Bilinmiyor";

        Buyer buyer = new Buyer();
        buyer.Id = User.Identity?.Name ?? "BY789";
        buyer.Name = firstName;
        buyer.Surname = lastName;
        buyer.GsmNumber = model.Telefon;
        buyer.Email = model.Email;
        buyer.IdentityNumber = "74300864791";
        buyer.LastLoginDate = "2015-10-05 12:43:35";
        buyer.RegistrationDate = "2013-04-21 15:12:09";
        buyer.RegistrationAddress = model.AdresSatiri;
        buyer.Ip = "85.34.78.112";
        buyer.City = model.Sehir;
        buyer.Country = "Turkey";
        buyer.ZipCode = model.PostaKodu;
        request.Buyer = buyer;

        Address address = new Address();
        address.ContactName = model.AdSoyad;
        address.City = model.Sehir;
        address.Country = "Turkey";
        address.Description = model.AdresSatiri;
        address.ZipCode = model.PostaKodu;
        request.ShippingAddress = address;
        request.BillingAddress = address;


        List<BasketItem> basketItems = new List<BasketItem>();
        foreach (var item in cart.CartItems)
        {

            BasketItem basketItem = new BasketItem();
            basketItem.Id = item.CartItemId.ToString();
            basketItem.Name = item.Urun.UrunAdi;
            basketItem.Category1 = "Telefon";
            basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            basketItem.Price = item.Urun.fiyat.ToString();
            basketItems.Add(basketItem);
        }

        request.BasketItems = basketItems;

        return await Payment.Create(request, options);
    }
}