SET IDENTITY_INSERT [dbo].[Products] ON 
GO

INSERT [dbo].[Products] ([Id], [Name], [Brand], [BrandId], [ImageUrl], [Description], [StockQuantity], [Price], [DiscountedPrice], [ShowOnPageAsMonthlyHighlight], [ShowOnPageAsDailyHighlight], [ShowOnPageAsSpecialOffer], [ShowOnPageAsPopular], [IsActive], [IsApproved]) VALUES 

-- 1. ARDUINO & GELİŞTİRME KARTLARI
(1, N'Arduino Uno R3 (Klon)', N'Arduino', 1, N'uno.jpg', N'Elektronik projelerin temel kartı.', 200, 250, 195, 1, 1, 1, 1, 1, 1),
(2, N'Arduino Nano R3', N'Arduino', 1, N'nano.jpg', N'Küçük boyutlu projeler için ideal mikrodenetleyici.', 150, 180, 145, 0, 1, 0, 1, 1, 1),
(3, N'ESP8266 NodeMCU WiFi', N'Espressif', 3, N'nodemcu.jpg', N'WiFi destekli IoT geliştirme kartı.', 120, 160, 130, 1, 0, 1, 1, 1, 1),

-- 2. SENSÖRLER & MODÜLLER
(4, N'HC-SR04 Mesafe Sensörü', N'Generic', 15, N'hcsr04.jpg', N'Engel algılama ve mesafe ölçümü.', 500, 75, 55, 0, 1, 1, 1, 1, 1),
(5, N'DHT22 Isı ve Nem Sensörü', N'Generic', 15, N'dht22.jpg', N'Yüksek hassasiyetli iklim sensörü.', 100, 140, 115, 0, 0, 1, 1, 1, 1),
(6, N'Yağmur Sensörü Modülü', N'Generic', 15, N'rain.jpg', N'Su seviyesi ve yağmur algılama kartı.', 85, 65, 45, 0, 1, 0, 0, 1, 1),

-- 3. 3D YAZICI & FİLAMENT
(7, N'Creality Ender 3 V3 SE', N'Creality', 4, N'ender3.jpg', N'Otomatik yatak kalibrasyonlu 3D yazıcı.', 15, 8900, 8250, 1, 1, 1, 1, 1, 1),
(8, N'ABG PLA Filament 1kg Siyah', N'ABG', 5, N'abg-siyah.jpg', N'Sorunsuz baskı için kaliteli yerli filament.', 50, 550, 490, 0, 1, 1, 1, 1, 1),
(9, N'Anycubic Reçine 1kg Gri', N'Anycubic', 6, N'resin.jpg', N'LCD yazıcılar için yüksek detaylı reçine.', 25, 1200, 950, 1, 0, 0, 1, 1, 1),

-- 4. ROBOTİK KODLAMA SETLERİ
(10, N'4WD Engelden Kaçan Robot', N'TeknoMarketim', 7, N'4wd.jpg', N'Kapsamlı robotik eğitim kiti.', 30, 1250, 1100, 1, 0, 1, 1, 1, 1),
(11, N'Çizgi İzleyen Robot Kiti', N'TeknoMarketim', 7, N'line-follower.jpg', N'Yarışmalar için optimize edilmiş robot kiti.', 20, 1450, 1200, 0, 1, 1, 1, 1, 1),

-- 5. MOTORLAR & SÜRÜCÜLER
(12, N'SG90 Mini Servo Motor', N'TowerPro', 8, N'sg90.jpg', N'9g ağırlığında mikro servo motor.', 400, 95, 75, 0, 1, 0, 1, 1, 1),
(13, N'L298N Motor Sürücü', N'Generic', 15, N'l298n.jpg', N'DC motor kontrol kartı.', 180, 140, 110, 0, 0, 1, 1, 1, 1),

-- 6. GÜÇ KAYNAKLARI & BATARYALAR
(14, N'Li-Po Pil 7.4V 1500mAh', N'Turnigy', 9, N'lipo74.jpg', N'Hafif ve güçlü robot bataryası.', 60, 650, 580, 0, 1, 1, 1, 1, 1),
(15, N'12V 5A Adaptör', N'Generic', 15, N'adapter.jpg', N'Projeler için stabil güç kaynağı.', 70, 350, 290, 0, 0, 0, 1, 1, 1),

-- 7. ELEKTRONİK KOMPONENTLER
(16, N'Breadboard (Büyük Boy)', N'Generic', 15, N'breadboard.jpg', N'Devre kurmak için delikli pano.', 200, 110, 85, 0, 1, 0, 1, 1, 1),
(17, N'Jumper Kablo Erkek-Erkek', N'Generic', 15, N'jumper.jpg', N'40''lı bağlantı kablosu seti.', 500, 65, 45, 0, 0, 1, 1, 1, 1),

-- 8. PROTOTİPLEME & LEHİMLEME
(18, N'Soldex Lehim Teli 50g', N'Soldex', 10, N'soldex.jpg', N'Kolay eriyen kaliteli lehim teli.', 150, 120, 95, 0, 1, 0, 1, 1, 1),
(19, N'Kalem Havya 60W', N'Generic', 15, N'havya60.jpg', N'Ayarlanabilir sıcaklıklı kalem havya.', 90, 350, 280, 1, 0, 1, 1, 1, 1),

-- 9. EĞİTİCİ ROBOTİK KİTLER
(20, N'Makeblock mBot V1.1', N'Makeblock', 11, N'mbot.jpg', N'Dünyanın en popüler eğitim robotu.', 12, 3600, 3250, 1, 1, 1, 1, 1, 1),
(21, N'Micro:bit Başlangıç Seti', N'Microbit', 12, N'microbit.jpg', N'Okullar için kodlama eğitim kiti.', 40, 950, 850, 0, 0, 1, 1, 1, 1),

-- 10. WIRELESS & BLUETOOTH MODÜLLERİ
(22, N'HC-06 Bluetooth Modülü', N'Generic', 15, N'hc06.jpg', N'Slave mod kablosuz iletişim birimi.', 120, 190, 160, 0, 1, 1, 1, 1, 1),
(23, N'NRF24L01+ Kablosuz Haberleşme', N'Nordic', 13, N'nrf.jpg', N'2.4GHz uzun menzilli RF modülü.', 140, 85, 65, 0, 0, 0, 1, 1, 1),

-- 11. RASPBERRY PI & SINGLE BOARD
(24, N'Raspberry Pi 4 - 4GB', N'Raspberry Pi', 2, N'pi4.jpg', N'Endüstriyel ve hobi kullanımı için PC.', 18, 2200, 1950, 1, 1, 0, 1, 1, 1),
(25, N'Raspberry Pi Pico', N'Raspberry Pi', 2, N'pico.jpg', N'RP2040 tabanlı mikrodenetleyici.', 300, 180, 155, 0, 1, 1, 1, 1, 1),

-- 12. ÖLÇÜ ALETLERİ & EL ALETLERİ
(26, N'Unit UT33D+ Multimetre', N'UNI-T', 14, N'unit.jpg', N'Dijital hassas ölçü aleti.', 45, 650, 595, 1, 0, 1, 1, 1, 1),
(27, N'Yan Keskı 5 inç', N'Generic', 15, N'keski.jpg', N'Elektronik işleri için hassas kesici.', 110, 150, 125, 0, 1, 0, 1, 1, 1),
(28, N'Kargaburun 5 inç', N'Generic', 15, N'karga.jpg', N'Komponent bükme ve tutma aleti.', 95, 160, 135, 0, 1, 0, 1, 1, 1)

GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO

select * from Products