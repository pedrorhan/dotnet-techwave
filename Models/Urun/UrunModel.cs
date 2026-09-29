using System.ComponentModel.DataAnnotations;
namespace dotnet_store.Models;

public class UrunModel
{
    [Display(Name ="Ürün Adı")]
    [Required(ErrorMessage ="{0} girilmeli.")]
    [StringLength(50, ErrorMessage ="{0} için maksimum {2}-{1} aralığında karakter girilebilir.", MinimumLength = 10)]
    public string UrunAdi { get; set; }=null!;

    [Display(Name ="Ürün Fiyat")]
    [Required(ErrorMessage ="{0} zorunlu.")]
    [Range(0,100000, ErrorMessage ="{0} için {1}-{2} aralığında değer girilebilir.")]
    public double? fiyat { get; set; }

    [Display(Name ="Ürün Resmi")]
    public IFormFile? Resim { get; set; }
    public string? Aciklama { get; set; }
    public bool Aktif { get; set; }
    public bool Anasayfa { get; set; }
    [Display(Name =  "Kategori")]
    [Required(ErrorMessage ="{0} zorunlu")]
    public int? KategoriId { get; set; }
}