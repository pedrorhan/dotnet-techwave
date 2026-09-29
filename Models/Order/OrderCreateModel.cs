namespace dotnet_store.Models;

public class OrderCreateModel
{
    public int Id { get; set; }
    public string AdSoyad { get; set; } = null!;
    public string Sehir { get; set; } = null!;
    public string AdresSatiri { get; set; } = null!;
    public string PostaKodu { get; set; } = null!;
    public string Telefon { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? SiparisNotu { get; set; }

    public string CardName { get; set; } = null!;
    public string CardNumber { get; set; } = null!;
    public string CardExpirationYear { get; set; } = null!;
    public string CardExpirationMonth { get; set; } = null!;
    public string CardCVV { get; set; } = null!;
}