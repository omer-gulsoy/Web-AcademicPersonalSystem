# 🎓 Akademik Personel Başvuru Sistemi

Bu proje, Akademik personel alım süreçlerini dijitalleştirmek amacıyla geliştirilen sistem, adayların ilanlara başvuru yapabilmesini, belgelerini yükleyebilmesini, jüri üyelerinin adayları değerlendirmesini ve yöneticilerin tüm bu süreci merkezi olarak yönetmesini sağlamaktadır.

## 📚 Proje Amacı

- Fiziksel başvuru sürecini dijital ortama taşımak  
- Belge karmaşasını ve zaman kaybını azaltmak  
- Şeffaf ve merkezi bir değerlendirme sistemi sunmak  
- Tüm kullanıcı rollerine özel panel ve işlevler geliştirmek  
- Otomatik değerlendirme ve belge üretimi sağlamak  

---

## 👥 Kullanıcı Rolleri ve İşlevleri

| Rol      | Yetkiler ve İşlevler |
|----------|----------------------|
| **Aday** | Aktif ilanları görüntüleyebilir, başvuru yapabilir, belgeleri yükleyebilir, başvuru sürecini takip edebilir. "Şifremi Unuttum" seçeneğiyle şifresini sıfırlayabilir. |
| **Yönetici** | Yeni ilan oluşturabilir, jüri atayabilir, başvuruları yönetebilir, istatistiksel verilere erişebilir. |
| **Jüri** | Kendisine atanan adayların belgelerini inceler, puanlama yapar, değerlendirmeyi sisteme yükler. |
| **Admin** | Tüm kullanıcıları ve ilanları yönetir, sistem güvenliği ve yetkilendirme ayarlarını kontrol eder. |

---

## ⚙️ Teknik Bilgiler

### 🎨 Frontend

- **HTML5 / CSS3 / SCSS**
- **JavaScript (Vanilla)**
- **Responsive tasarım (Bootstrap)**

### 🧠 Backend

- **ASP.NET Core MVC (C#)**
  - Model-View-Controller mimarisi
  - Razor sayfa şablonları
  - Katmanlı yapı ve modülerlik

### 🗃️ Veritabanı

- **Microsoft SQL Server (MSSQL)**
  - Entity Framework Core (ORM)
  ![Veritabanı Diyagramı](https://raw.githubusercontent.com/omer-gulsoy/web-academicPersonalSystem/%C3%B6mer/images/UML.png)





### 🔐 Kimlik Doğrulama ve Güvenlik

- ASP.NET Identity ile kullanıcı yönetimi
- E-Devlet API simülasyonu ile kimlik doğrulama
- Rol bazlı erişim kontrolü
- JWT destekli oturum yapısı

---

## 🔄 Sistem Akışı

1. Aday sisteme kayıt olur veya giriş yapar.
2. Uygun ilanlara başvuru yapar, belgelerini yükler.
3. Yönetici ilanlara jüri üyeleri atar.
4. Jüri üyeleri sisteme giriş yaparak kendilerine atanan adayları değerlendirir.
5. Sistem her jüri üyesinden gelen puanları toplayarak otomatik olarak PDF çıktısı üretir.
6. Aday, başvurusunun sonucunu sistem üzerinden takip edebilir.

---

## 📁 Kurulum Talimatları

> Proje ASP.NET Core MVC tabanlıdır. .NET 6 veya üzeri kurulu olmalıdır.





