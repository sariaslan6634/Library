# 📚 Library API

![.NET](https://img.shields.io/badge/.NET-10.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-10.0-blue)
![EF Core](https://img.shields.io/badge/Entity_Framework_Core-10.0-green)
![SQL Server](https://img.shields.io/badge/SQL_Server-red)
![JWT](https://img.shields.io/badge/JWT-Authentication-orange)
![Docker](https://img.shields.io/badge/Docker-supported-blue)

## 📌 Proje Hakkında

Library API, ASP.NET Core teknolojileri kullanılarak geliştirilmiş bir kütüphane yönetim sistemidir.

Bu proje; kullanıcıların kitap ekleyip yönetebildiği, üyelerin kitap ödünç alıp iade edebildiği ve JWT ile korunan endpoint'lere sahip RESTful bir API olarak geliştirilmiştir.

Proje modern yazılım geliştirme prensipleri ve Clean Architecture yaklaşımı kullanılarak oluşturulmuştur.

---

## 🚀 Özellikler

### 📖 Kitap Yönetimi
- Kitapları listeleme
- Kitap detayı görüntüleme
- Kitap ekleme, güncelleme, silme
- Kitap ödünç verme ve iade alma

### 👤 Üye Yönetimi
- Üyeleri listeleme
- Yeni üye ekleme

### 🔐 Kimlik Doğrulama
- Kullanıcı kaydı (Register)
- Kullanıcı girişi (Login)
- JWT Token ile korumalı endpoint'ler

---

## 🛠️ Kullanılan Teknolojiler

### Backend
- ASP.NET Core 10
- ASP.NET Web API
- Entity Framework Core 10
- SQL Server
- JWT Authentication
- MediatR (CQRS)
- AutoMapper
- FluentValidation
- Serilog
- Docker
- BCrypt.Net

### Documentation
- Swagger / OpenAPI

### Test
- xUnit
- Moq
- FluentAssertions

---

## 🏗️ Mimari Yapı

Proje Clean Architecture yaklaşımı ile geliştirilmiştir.

```text
Library
│
├── src
│   ├── Library.Domain          → Entity sınıfları
│   ├── Library.Application     → CQRS, MediatR, Interface, DTO
│   ├── Library.Infrastructure  → EF Core, JWT, DbContext
│   └── Library.WebAPI          → Controller, Middleware, Program.cs
│
└── test
    └── Library.Application.Tests → Unit testler
```

| Katman | Açıklama |
|--------|----------|
| Domain | Entity sınıfları, iş kuralları |
| Application | CQRS komutları, MediatR handler'ları, DTO'lar |
| Infrastructure | Veritabanı işlemleri, JWT token servisi |
| WebAPI | HTTP endpoint'leri, middleware'ler |

---

## 🎯 Kullanılan Tasarım Desenleri

### Clean Architecture
Bağımlılıkların içe doğru aktığı, katmanların birbirinden bağımsız olduğu mimari yapı.

### CQRS (Command Query Responsibility Segregation)
Okuma ve yazma işlemlerinin birbirinden ayrıldığı tasarım deseni.

### MediatR
Handler'lar arasındaki iletişimi sağlayan mediator pattern implementasyonu.

### Repository Pattern
Veri erişim katmanının ILibraryDbContext üzerinden soyutlanması.

### Dependency Injection
Bağımlılıkların gevşek bağlı şekilde yönetilmesi.

---

## 🔐 Kimlik Doğrulama ve Yetkilendirme

JWT Authentication kullanılmaktadır.

- Kullanıcı kayıt ve giriş işlemleri
- Token bazlı kimlik doğrulama
- Korumalı endpoint'lere `[Authorize]` attribute'u

---

## ⚙️ Kurulum

### 1. Projeyi Klonlayın

```bash
git clone https://github.com/sariaslan6634/Library.git
```

### 2. Veritabanı Bağlantısını Güncelleyin

`appsettings.json` dosyasında connection string bilgisini düzenleyin.

```json
"ConnectionStrings": {
  "SqlConnection": "YOUR_CONNECTION_STRING"
}
```

### 3. JWT Ayarlarını Güncelleyin

```json
"JwtSettings": {
  "SecretKey": "YOUR_SECRET_KEY",
  "Issuer": "LibraryAPI",
  "Audience": "LibraryClient",
  "ExpirationMinutes": 60
}
```

### 4. Migration İşlemlerini Gerçekleştirin

```bash
Update-Database
```

### 5. Projeyi Çalıştırın

```bash
dotnet run --project Library.WebAPI
```

### 6. Docker ile Çalıştırın

```bash
docker build -t library-api .
docker run -p 8080:8080 library-api
```

---

## 🧪 Testleri Çalıştırın

```bash
dotnet test
```

---

## 👨‍💻 Geliştirici

**İbrahim SARIASLAN**

**GitHub:** https://github.com/sariaslan6634

**LinkedIn:** https://www.linkedin.com/in/ibrahimsariaslan/

---

## 📄 Lisans

Bu proje eğitim, öğrenim ve portföy amaçlı geliştirilmiştir.
