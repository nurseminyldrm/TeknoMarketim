SET IDENTITY_INSERT [dbo].[Campaigns] ON 

GO
 
INSERT [dbo].[Campaigns] ([Id], [Description]) VALUES 

(1, N'Robotik setlerde ve 3D yazıcılarda %30''a varan büyük indirim başladı!'),

(2, N'İlk siparişinize özel %10 indirim kuponu! Kod: TEKNO10'),

(3, N'Arduino ve Raspberry Pi modellerinde eğitim kurumlarına özel toplu indirim fırsatı!'),

(4, N'Sensör ve modüllerde dev kampanya! 5 al 4 öde fırsatını kaçırmayın!'),

(5, N'1000 TL ve üzeri teknolojik alışverişlerinizde kargo bedava!'),

(6, N'Sistemlerimizde 02:00-04:00 saatleri arasında bakım yapılmaktadır.')

GO
 
SET IDENTITY_INSERT [dbo].[Campaigns] OFF

GO

select * from Campaigns