# 🚀 TECHWAVE E-Commerce Project (dotnet-store)

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white&style=for-the-badge)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white&style=for-the-badge)
![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET_Core_MVC-512BD4?logo=microsoft&logoColor=white&style=for-the-badge)
![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-336791?logo=sqlite&logoColor=white&style=for-the-badge)
![Bootstrap 5](https://img.shields.io/badge/Bootstrap-5-7952B3?logo=bootstrap&logoColor=white&style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge)

Bu proje, **ASP.NET Core MVC** mimarisi kullanılarak sıfırdan geliştirilmiş kapsamlı bir e-ticaret uygulamasıdır. İçerisinde kullanıcı yönetimi (Identity), sepete ürün ekleme, kategori filtreleme, sipariş takibi ve **İyzico** ödeme entegrasyonu gibi bir e-ticaret platformunun ihtiyaç duyduğu temel dinamikleri barındırmaktadır.

*Not: Projenin mimarisi, veritabanı kurgusu (Entity Framework), backend mantığı ve ödeme sistemleri tamamen tarafımca geliştirilmiş olup, yalnızca Frontend (Önyüz/Tasarım) tarafındaki Bootstrap 5 entegrasyonu, CSS modernleştirme işlemleri ve UI/UX pürüzlerinin giderilmesi aşamalarında Yapay Zeka (AI) asistanından destek alınmıştır.*

---

## 📌 İçindekiler
- [✨ Öne Çıkan Özellikler](#-öne-çıkan-özellikler)
- [🛠 Teknoloji Yığını](#-teknoloji-yığını)
- [📂 Proje Mimarisi](#-proje-mimarisi)
- [📦 Kurulum ve Çalıştırma](#-kurulum-ve-çalıştırma)
- [👥 Örnek Kullanıcı Rolleri](#-örnek-kullanıcı-rolleri)

---

## ✨ Öne Çıkan Özellikler
*   **Kapsamlı E-Ticaret Akışı**: Ürün listeleme, kategori bazlı filtreleme, sepete ekleme, sipariş oluşturma ve İyzico ile ödeme.
*   **ASP.NET Core Identity**: Güvenli kayıt, giriş, yetkilendirme (Admin ve User rolleri) ve parola şifreleme mekanizmaları.
*   **Entity Framework Core & SQLite**: Performanslı veritabanı işlemleri, `SeedDatabase` ile başlangıç verisi (mock data) üretimi.
*   **SMTP Email Entegrasyonu**: Şifre sıfırlama, bilgilendirme gibi senaryolar için SMTP e-posta gönderimi.
*   **Güvenli Mimari**: CSRF (Cross-Site Request Forgery) korumaları sağlanmış ve hassas API anahtarları `.gitignore` kuralları ile gizlenmiştir.
*   **Responsive Arayüz**: Bootstrap 5 ve FontAwesome ile desteklenen şık, mobil uyumlu, modern arayüz tasarımı.

---

## 🛠 Teknoloji Yığını

| Kategori | Teknoloji / Araç |
| :--- | :--- |
| **Backend & Framework** | C#, .NET 10.0, ASP.NET Core MVC |
| **ORM & Veritabanı** | Entity Framework Core, SQLite |
| **Güvenlik & Kimlik** | ASP.NET Core Identity |
| **Ödeme Altyapısı** | İyzico (Iyzipay Sandbox) |
| **Frontend** | HTML5, CSS3, Bootstrap 5, FontAwesome, Razor (CSHTML) |

---

## 📂 Proje Mimarisi

```plaintext
dotnet-store/
│
├── Controllers/              # MVC mimarisinin Controller (Yönlendirici) katmanı
├── Models/                   # Veritabanı modelleri (Entities) ve veri yapısı
├── Views/                    # Razor HTML sayfaları (CSHTML)
├── ViewComponents/           # Tekrar kullanılabilen bağımsız arayüz bileşenleri
├── Services/                 # İyzico, Email, Sepet (Cart) gibi servislerin iş mantıkları (Business Logic)
├── Data/                     # DbContext ve SeedDatabase (başlangıç verileri) sınıfı
├── Migrations/               # Entity Framework Core veritabanı şema güncellemeleri
├── wwwroot/                  # CSS, JS ve imaj dosyalarının barındırıldığı statik klasör
└── Program.cs                # Dependency Injection (DI) ve Middleware yapılandırmaları
```

---

## 📦 Kurulum ve Çalıştırma

> ⚠️ **ÇOK ÖNEMLİ BİLGİLENDİRME (DİKKAT!)** ⚠️
> 
> Projenin veritabanı dosyası (`store.db`) güvenlik ve en iyi kodlama pratikleri gereği GitHub'a **yüklenmemiştir**. Projeyi bilgisayarınıza indirdiğinizde uygulamanın çalışabilmesi için veritabanı tablolarını (Identity, Ürünler, Sepet vb.) oluşturmanız **zorunludur**.
> 
> Projeyi çalıştırabilmek için `dotnet run` komutundan **ÖNCE** veritabanı migration'larını uygulamalısınız. Aksi takdirde `SQLite Error 1: no such table: AspNetRoles` hatası ile karşılaşırsınız!

1. **Projeyi bilgisayarınıza klonlayın:**
   ```bash
   git clone https://github.com/pedrorhan/dotnet-store.git
   ```
2. **Proje dizinine gidin ve bağımlılıkları yükleyin:**
   ```bash
   cd dotnet-store
   dotnet restore
   ```
3. **Konfigürasyonları ayarlayın:**
   E-posta (SMTP) ve İyzico API anahtarlarınızı yapılandırmak için `appsettings.json` veya `appsettings.Development.json` dosyalarını güncelleyin. *(Not: Github'da güvenlik gereği hassas şifreler yer almamaktadır, kendi key'lerinizi girmelisiniz).*
4. **Veritabanı tablolarını oluşturun (ZORUNLU ADIM):**
   ```bash
   dotnet ef database update
   ```
5. **Projeyi derleyip çalıştırın:**
   ```bash
   dotnet run
   ```

---

## 👥 Örnek Kullanıcı Rolleri

Proje ilk kez çalıştığında (eğer veritabanı boşsa) `SeedDatabase` sınıfı devreye girer ve otomatik olarak bazı örnek veriler ve demo hesaplar oluşturur:

*   👑 **Admin Hesabı:** 
    * **Email:** `admin@techwave.com` 
    * **Şifre:** `12345678`
*   👤 **Müşteri Hesabı:** 
    * **Email:** `customer@techwave.com` 
    * **Şifre:** `12345678`

---

