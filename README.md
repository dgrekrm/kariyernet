# KariyerApp

KariyerApp, iş ilanı yönetim sistemi olarak tasarlanmış bir uygulamadır. İşverenlerin iş ilanı oluşturmasına, güncellemesine ve silmesine olanak tanır. Ayrıca, ilanların Elasticsearch kullanılarak hızlı bir şekilde sorgulanmasını sağlar.

## 1. Solution Katmanlarının Açıklanması

KariyerApp projesi, aşağıdaki katmanlardan oluşmaktadır:


### Katman Açıklamaları

- **KariyerApp.Api**: Uygulamanın API katmanıdır. İstemci taleplerini alır ve yanıtları döner.
- **KariyerApp.Core**: İş mantığının ve veri erişim katmanının bulunduğu alandır. Uygulamanın temel işlevselliği burada tanımlanır.
- **KariyerApp.Elastic**: Elasticsearch ile entegrasyon için gerekli sınıflar ve metotlar burada yer alır.

## 2. Endpointlerin Açıklanması

### 1. İşveren Kaydı Oluşturma

- **URL**: `/api/recruiters`
- **HTTP Method**: `POST`
- **Request Body**: `CreateRecruiterRequest`
- **Açıklama**: Yeni bir işveren kaydı oluşturur.

### 2. İş İlanı Oluşturma

- **URL**: `/api/jobadvertisements`
- **HTTP Method**: `POST`
- **Request Body**: `CreateJobAdvertisementRequest`
- **Açıklama**: Yeni bir iş ilanı oluşturur ve bu ilanı Elasticsearch'e kaydeder.

### 3. Son 5 Gün İçinde Eklenen İş İlanları

- **URL**: `/api/jobadvertisements/last/{days}`
- **HTTP Method**: `GET`
- **Açıklama**: Belirtilen gün sayısı içinde eklenen iş ilanlarını getirir.

## 3. Projenin Ayağa Kaldırılması

Proje kurulumunu gerçekleştirmek için aşağıdaki adımları izleyin:

1. **Gerekli NuGet Paketlerini Yükleyin**:
   - `Microsoft.EntityFrameworkCore`
   - `Microsoft.EntityFrameworkCore.Design`
   - `Npgsql.EntityFrameworkCore.PostgreSQL`
   - `Elasticsearch.Net`
   - `Nest`

2. **Veritabanı Bağlantısını Yapılandırın**:
   - `appsettings.json` dosyasında PostgreSQL ve Elasticsearch bağlantı ayarlarını güncelleyin.

3. **Migration Oluşturma ve Veritabanını Güncelleme**:
   ```bash
   Add-Migration InitialCreate -Project KariyerApp.Core
   Update-Database -Project KariyerApp.Core
