namespace dotnet_store.Models;

public class Cart
{
    public int CartId { get; set; }
    public string CustomerId { get; set; } = null!;

    public List<CartItem> CartItems { get; set; } = new List<CartItem>();

    public void AddItem(Urun urun, int miktar)
    {
        var item = CartItems.Where(i => i.UrunId == urun.Id).FirstOrDefault();

        if (item == null)
        {
            CartItems.Add(new CartItem
            {
                Miktar = miktar,
                Urun = urun
            });
        }
        else
        {
            item.Miktar += miktar;
        }
    }

    public void DeleteItem(int urunId, int miktar)
    {
        var item = CartItems.Where(i => i.UrunId == urunId).FirstOrDefault();

        if (item != null)
        {
            item.Miktar -= miktar;
            if (item.Miktar <= 0)
            {
                CartItems.Remove(item);
            }
        }
    }

    
    public void UpdateItem(int urunId, int miktar)
    {
        var item = CartItems.Where(i => i.UrunId == urunId).FirstOrDefault();
        if (item != null)
        {
            item.Miktar = miktar;
            if (item.Miktar <= 0)
            {
                CartItems.Remove(item);
            }
        }
    }
    public double AraToplam()
    {
        return CartItems.Sum(i => i.Urun.fiyat * i.Miktar);
    }
    public double Toplam()
    {
        return CartItems.Sum(i => i.Urun.fiyat * i.Miktar) * 1.2;
    }
}

public class CartItem
{
    public int CartItemId { get; set; }
    public int UrunId { get; set; }
    public Urun Urun { get; set; } = null!;
    public int CartId { get; set; }
    public Cart Cart { get; set; } = null!;
    public int Miktar { get; set; }
}