# TECHWAVE E-Commerce Project

Bu proje, **ASP.NET Core MVC** mimarisi kullanılarak sıfırdan geliştirilmiş kapsamlı bir e-ticaret uygulamasıdır. İçerisinde kullanıcı yönetimi (Identity), sepete ürün ekleme, kategori filtreleme, sipariş takibi ve **İyzico** ödeme entegrasyonu gibi bir e-ticaret platformunun ihtiyaç duyduğu temel dinamikleri barındırmaktadır.

*Not: Projenin mimarisi, veritabanı kurgusu (Entity Framework), backend mantığı ve ödeme sistemleri tamamen tarafımca geliştirilmiş olup, yalnızca Frontend (Önyüz/Tasarım) tarafındaki Bootstrap 5 entegrasyonu, CSS modernleştirme işlemleri ve UI/UX pürüzlerinin giderilmesi aşamalarında Yapay Zeka (AI) asistanından destek alınmıştır.*

## 🚀 Teknolojiler ve Özellikler
*   **.NET 10.0 & C#**
*   **ASP.NET Core MVC**
*   **Entity Framework Core (SQLite)** - Veritabanı ve ORM yönetimi
*   **ASP.NET Core Identity** - Güvenli kayıt, giriş, yetkilendirme (Admin/User rolleri) ve parola işlemleri
*   **İyzico (Iyzipay)** - Sanal POS ile güvenli ödeme altyapısı (Sandbox)
*   **SMTP Email Entegrasyonu** - Şifre sıfırlama vb. mailler için
*   **HTML, CSS, Bootstrap 5 & FontAwesome** - Modern, minimalist ve responsive (mobil uyumlu) arayüz tasarımı

## 📦 Kurulum ve Çalıştırma

> ⚠️ **ÇOK ÖNEMLİ BİLGİLENDİRME (DİKKAT!)** ⚠️
> 
> Projenin veritabanı dosyası (`store.db`) güvenlik ve en iyi kodlama pratikleri gereği GitHub'a **yüklenmemiştir**. Projeyi bilgisayarınıza indirdiğinizde uygulamanın çalışabilmesi için veritabanı tablolarını (Identity, Ürünler, Sepet vb.) oluşturmanız **zorunludur**.
> 
> Projeyi çalıştırabilmek için `dotnet run` komutundan **ÖNCE** veritabanı migration'larını uygulamalısınız. Aksi takdirde `SQLite Error 1: no such table: AspNetRoles` hatası ile karşılaşırsınız!

1. Projeyi bilgisayarınıza klonlayın:
   ```bash
   git clone https://github.com/pedrorhan/dotnet-store.git
   ```
2. Proje dizinine gidin ve bağımlılıkları yükleyin:
   ```bash
   cd dotnet-store
   dotnet restore
   ```
3. E-posta (SMTP) ve İyzico API anahtarlarınızı yapılandırmak için `appsettings.json` veya `appsettings.Development.json` dosyalarını güncelleyin. *(Not: Github'da güvenlik gereği hassas şifreler yer almamaktadır, kendi key'lerinizi girmelisiniz).*
4. **Veritabanı tablolarını oluşturun (ZORUNLU):**
   ```bash
   dotnet ef database update
   ```
5. Projeyi derleyip çalıştırın:
   ```bash
   dotnet run
   ```

## 👥 Örnek Kullanıcı Rolleri
Proje ilk kez çalıştığında veritabanı (SeedDatabase) otomatik olarak bazı örnek veriler ve hesaplar oluşturur:
*   **Admin Hesabı:** `admin@techwave.com` / Şifre: `12345678`
*   **Müşteri Hesabı:** `customer@techwave.com` / Şifre: `12345678`

---
> 💡 *Güvenlik Uyarıları: CSRF korumaları sağlanmış ve hassas API anahtarları `.gitignore` kuralları ile gizlenmiştir.*
