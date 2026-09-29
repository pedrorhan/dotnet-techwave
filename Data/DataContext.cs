using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Models;

public class DataContext : IdentityDbContext<AppUser, AppRole, int>
{
    //yapıcı metot(consturctor)
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Kategori> Kategoriler { get; set; }
    public DbSet<Slider> Sliderlar { get; set; }

    public DbSet<Cart> Carts { get; set; }

    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Slider>().HasData(
            new List<Slider>
            {
                new Slider{Id=1,Baslik="Slider 1 başlık",Aciklama="slider 1 açıklama", Resim="slider-1.jpeg",Aktif=true, Index=0},
                new Slider{Id=2,Baslik="Slider 2 başlık",Aciklama="slider 2 açıklama", Resim="slider-2.jpeg",Aktif=true,Index=1},
                new Slider{Id=3,Baslik="Slider 3 başlık",Aciklama="slider 3 açıklama", Resim="slider-3.jpeg",Aktif=true,Index=2},
            }
        );

        modelBuilder.Entity<Kategori>().HasData(
            new List<Kategori>
            {
                new Kategori{Id=1,KategoriAdi="Telefon",Url="telefon"},
                new Kategori{Id=2,KategoriAdi="Elektronik",Url="elektronik"},
                new Kategori{Id=3,KategoriAdi="Beyaz Eşya",Url="beyaz-esya"},
                new Kategori{Id=4,KategoriAdi="Giyim",Url="giyim"},
                new Kategori{Id=5,KategoriAdi="Kozmetik",Url="kozmetik"},
                new Kategori{Id=6,KategoriAdi="Kategori 1",Url="kategori-1"},
                new Kategori{Id=7,KategoriAdi="Kategori 2",Url="kategori-2"},
                new Kategori{Id=8,KategoriAdi="Kategori 3",Url="kategori-3"},
                new Kategori{Id=9,KategoriAdi="Kategori 4",Url="kategori-4"},
                new Kategori{Id=10,KategoriAdi="Kategori 5",Url="kategori-5"},
            }
        );

        modelBuilder.Entity<Urun>().HasData(
            new List<Urun>
            {
                new Urun(){ Id=1,
                UrunAdi="Apple Watch 7", fiyat=10000,
                Aktif=false,
                Resim="1.jpeg",
                Anasayfa=true,Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.",
                KategoriId=1},
                new Urun(){ Id=2, UrunAdi="Apple Watch 8", fiyat=20000, Aktif=true,Resim="2.jpeg", Anasayfa=true,Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.",
                KategoriId=5},
                new Urun(){ Id=3, UrunAdi="Apple Watch 9", fiyat=30000, Aktif=true,Resim="3.jpeg", Anasayfa=true,Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.",
                KategoriId=1},
                new Urun(){ Id=4, UrunAdi="Apple Watch 10", fiyat=40000, Aktif=false,Resim="4.jpeg", Anasayfa=false,Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.",
                KategoriId=1},
                new Urun(){ Id=5, UrunAdi="Apple Watch 11", fiyat=50000, Aktif=true,Resim="5.jpeg", Anasayfa=false,Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.",
                KategoriId=2},
                new Urun(){ Id=6, UrunAdi="Apple Watch 12", fiyat=60000, Aktif=false,Resim="6.jpeg", Anasayfa=true,Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.",
                KategoriId=4},
                new Urun(){ Id=7, UrunAdi="Apple Watch 13", fiyat=70000, Aktif=false,Resim="7.jpeg", Anasayfa=true,Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.",
                KategoriId=5},
                new Urun(){ Id=8, UrunAdi="Apple Watch 14", fiyat=80000, Aktif=true,Resim="8.jpeg", Anasayfa=true,Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.",
                KategoriId=3},
            }
        );
    }
}

// DataContext context = new DataContext();