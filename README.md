# English
## Academic Personal System Project
***Academic Personal Application System project is implemented; Different user types application system different flexibility capability.
It is a platform that aims to provide benefits and create an efficient institution. This purpose is to provide better management
easy application management; A more accessible institution for candidates and those who are considering becoming candidates;
A more informative institution for admins and jurys; Creating an informative and accessible platform about the institution for guest users.***

***As mentioned above, there have been 5 different users on the platform and these users have different authorities.***

### General Functions:

    - Guest Module: Guest unit can get information about academic staff advertisements,
    View the advertisement and get information about themselves, benefit from educational articles and ask questions to the institution management.
    The accuracy of the Turkish ID number, name, surname and date of birth entered during registration to the system is checked.
    
    Academic Personal Application System e-mail newsletter participation, school communication
    To view records, open the site. Capacity for registered users to log in.
    
    - Administrator Module: In the administrator module, to make all the arrangements of the framed system.
    
    There are academic advertisement, staff, advertisement information, jury, statistics display and registration calendar.
    It has the capacity to display communication packages provided by, e-mail bulletin details, visitor display. It is designed for easy access to all these functions and is user-friendly.
    
    - Jury Module: The jury module allows the institution's staff to evaluate their applications,
    It has the function of displaying personnel registered in the institution system.
    
    - Candidate Module: In the candidate module, the total of academic staff advertisements in the institution, advertisements applied by the candidate are collected.
    It is planned to be displayed in a way that one can create their own academic profile.
    
    - Users can view their own profiles in the administrator, jury, candidate modules
    The area is shared. The areas of all these user profiles can be clearly separated and their locations can be determined.

### Programming Languages ​​I Use:

    Frontend:   - HTML
                - CSS
                - JavaScript
                - SCSS
    
    Backend:    - C#

    Database: - MS SQL

> This project is a web application that aims to make people productive in the nursery. It will be developed and improved for educators.

> The texts in the program are in Turkish.

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



