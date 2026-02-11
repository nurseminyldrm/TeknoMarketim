-- TEKNOMARKETİM KATEGORİ LİSTESİ --
-- =============================================

SET IDENTITY_INSERT [dbo].[Categories] ON 

GO
 
INSERT [dbo].[Categories] ([Id], [Name], [Status]) VALUES 

(1, N'Arduino & Geliştirme Kartları', 1),

(2, N'Sensörler & Modüller', 1),

(3, N'3D Yazıcı & Filament', 1),

(4, N'Robotik Kodlama Setleri', 1),

(5, N'Motorlar & Sürücüler', 1),

(6, N'Güç Kaynakları & Bataryalar', 1),

(7, N'Elektronik Komponentler', 1),

(8, N'Prototipleme & Lehimleme', 1),

(9, N'Eğitici Robotik Kitler', 1),

(10, N'Wireless & Bluetooth Modülleri', 1),

(11, N'Raspberry Pi & Single Board', 1),

(12, N'Ölçü Aletleri & El Aletleri', 1)

GO

select * from Categories



