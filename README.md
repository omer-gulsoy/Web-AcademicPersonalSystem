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

![image](https://github.com/user-attachments/assets/85707963-e6c3-4b59-871c-ed5c6e05bbca)

![image](https://github.com/user-attachments/assets/a9ac5a91-292d-4fd8-ae5c-bb49a54e4b52)

![image](https://github.com/user-attachments/assets/d9037150-2bb7-4da6-8be7-0fa7f513221d)

![image](https://github.com/user-attachments/assets/e18a7d92-af00-4bd9-88d6-6e8b2586fa48)

![image](https://github.com/user-attachments/assets/c8517c02-76c1-4abf-af4e-5300a3ba2a76)



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
  - 
  ## 📊 Veritabanı Diyagramı

Aşağıda sistemin temel UML veritabanı yapısı görselleştirilmiştir:

![UML Şeması](https://raw.githubusercontent.com/DeryaGelmez/AkademikPersonel/main/images/UML.png)


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

---

## 📄 Proje Raporu
📄 [Grup 17 Proje Raporu](Grup%2017%20Rapor.pdf)



