# Gezgin Gemi Şirketi: Sefer Yönetim Sistemi

Bir gemi şirketinin gemilerini, limanlarını, kaptanlarını, mürettebatını ve seferlerini yönetmek için yazılmış Windows Forms uygulaması. Veritabanı Yönetim Sistemleri dersi projesi.

Hatice Reyhan Çalışkan ve Betül Canol, Kocaeli Sağlık ve Teknoloji Üniversitesi, Bilgisayar Mühendisliği (Mayıs 2024).

## Ne yapıyor

Ana pencereden beş ayrı forma geçiliyor. Her formda ilgili tablo için ekleme, silme ve güncelleme yapılabiliyor:

| Form | Tablo | Tutulan bilgiler |
|---|---|---|
| Ships | `Ships` | seri no, ad, ağırlık, yapım yılı, tip, yolcu / petrol / konteyner kapasitesi |
| Ports | `Ports` | liman adı, ülke, nüfus, pasaport gerekip gerekmediği, yanaşma ücreti |
| Captains | `Captains` | ad, adres, uyruk, doğum ve işe giriş tarihi, lisans |
| Crew | `Crew` | ad, adres, uyruk, doğum ve işe giriş tarihi, görev |
| Voyages | `Voyages` | gemi, kaptan, mürettebat, kalkış/dönüş tarihi, kalkış limanı |

`Voyages` tablosu gemi, kaptan ve mürettebata yabancı anahtarla bağlı.

## Gereksinimler

- Windows
- Visual Studio (.NET Framework 4.8)
- SQL Server veya SQL Server Express

## Kurulum

1. SQL Server'da `Project_DB` adında bir veritabanı oluştur.
2. `SQL_QUERY.txt` içindeki `CREATE TABLE` komutlarını bu veritabanında çalıştır.
3. Bağlantı adresi koda sabit yazılmış: `Server=reyhan\SQLEXPRESS`. Kendi sunucu adınla değiştirmen gerekiyor. Değiştirilecek yerler:
   - `CaptainsForm.cs`, `CrewForm.cs`, `PortsForm.cs`, `ShipsForm.cs`, `VoyagesForm.cs` içindeki `connectionString` satırı
   - `App.config` içindeki `connectionString`
4. `_220501001_HaticeReyhanCaliskan_220501009_BetulCanol.sln` dosyasını Visual Studio ile açıp çalıştır.

## Dosyalar

```
SQL_QUERY.txt                         tablo şeması
*_labrapor.pdf                        proje raporu
_220501001_.../                       Visual Studio projesi
  Form1.cs                            ana menü
  ShipsForm.cs, PortsForm.cs, ...     her tablo için bir form
  Classes.cs                          veri sınıfları
```

Repoda Visual Studio'nun ürettiği `.vs/`, `bin/` ve `obj/` klasörleri de var; projeyi derlemek için gerekli değiller.
