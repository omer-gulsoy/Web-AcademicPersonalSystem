# Akademik Personel Başvuru Sistemi

Bu proje, Kocaeli Üniversitesi akademik kadro başvuru süreçlerini dijitalleştirmek amacıyla geliştirilmiştir. ASP.NET Core MVC mimarisiyle inşa edilen bu sistem, aday başvurularından jüri değerlendirmelerine kadar tüm süreci çevrim içi olarak yönetebilmektedir.

## 📌 Proje Özellikleri

- Adayların ilanlara başvuru yapabilmesi ve belgelerini yüklemesi
- Şifre sıfırlama (e-posta ile yeni şifre belirleme)
- Yöneticilerin ilan oluşturup jüri atayabilmesi
- Jüri üyelerinin aday belgelerini sistem üzerinden puanlayabilmesi
- Otomatik PDF formatında puanlama çıktısı
- Rol bazlı kullanıcı yönetimi (Aday, Yönetici, Jüri, Admin)
- E-Devlet API üzerinden kimlik doğrulama entegrasyonu

## ⚙️ Kullanılan Teknolojiler

| Katman       | Teknoloji                              |
|--------------|-----------------------------------------|
| Frontend     | HTML, CSS, SCSS, JavaScript, Bootstrap |
| Backend      | C#, ASP.NET Core MVC                   |
| Veritabanı   | Microsoft SQL Server (MSSQL)           |
| ORM          | Entity Framework Core                  |
| Kimlik Doğrulama | ASP.NET Identity, E-Devlet API     |



