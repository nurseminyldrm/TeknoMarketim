# TeknoMarketim – E-Ticaret Projesi

Bu proje, .NET tabanlı katmanlı mimari kullanılarak geliştirilmekte olan bir e-ticaret uygulamasıdır.  
Amaç; gerçek hayata yakın, ölçeklenebilir ve sürdürülebilir bir altyapı oluşturmaktır.

## Kullanılan Teknolojiler

- .NET Core / C#
- Entity Framework Core
- Code First Yaklaşımı
- Katmanlı Mimari
- Repository Pattern
- MVC

## Proje Katmanları

### 1. TeknoMarketim.Entities
- Domain modellerini içerir  
- Product, Category, Order, Cart gibi temel varlıklar burada tanımlıdır.

### 2. TeknoMarketim.Data
- Veritabanı işlemleri  
- DbContext yapılandırması  
- Entity Configuration sınıfları  
- Migrations yönetimi

### 3. TeknoMarketim.Business
- İş kuralları  
- Service katmanı  
- Repository implementasyonları

### 4. TeknoMarketim.MvcUI
- Kullanıcı arayüzü  
- Controller ve View yapısı

## Mevcut Durum

- Entity modelleri oluşturuldu  
- DbContext ve configuration sınıfları yazıldı  
- Katmanlı mimari altyapısı kuruldu  
- Migration yapısı eklendi  
- Business katmanında temel yapı hazırlandı

## Geliştirme Planı

- Authentication & Authorization  
- Ürün listeleme ve filtreleme  
- Sepet işlemleri  
- Sipariş süreci  
- Ödeme entegrasyonu
