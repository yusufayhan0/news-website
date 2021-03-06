USE [master]
GO
/****** Object:  Database [151601009]    Script Date: 6.07.2020 21:55:22 ******/
CREATE DATABASE [151601009]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bilisimDergisi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\151601009.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bilisimDergisi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\151601009_1.ldf' , SIZE = 3456KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [151601009] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [151601009].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [151601009] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [151601009] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [151601009] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [151601009] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [151601009] SET ARITHABORT OFF 
GO
ALTER DATABASE [151601009] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [151601009] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [151601009] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [151601009] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [151601009] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [151601009] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [151601009] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [151601009] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [151601009] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [151601009] SET  DISABLE_BROKER 
GO
ALTER DATABASE [151601009] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [151601009] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [151601009] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [151601009] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [151601009] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [151601009] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [151601009] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [151601009] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [151601009] SET  MULTI_USER 
GO
ALTER DATABASE [151601009] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [151601009] SET DB_CHAINING OFF 
GO
ALTER DATABASE [151601009] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [151601009] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [151601009] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'151601009', N'ON'
GO
ALTER DATABASE [151601009] SET QUERY_STORE = OFF
GO
USE [151601009]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [151601009]
GO
/****** Object:  Table [dbo].[hakkimizda]    Script Date: 6.07.2020 21:55:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hakkimizda](
	[hakkimizdaID] [int] IDENTITY(1,1) NOT NULL,
	[yazi] [nvarchar](max) NULL,
 CONSTRAINT [PK_hakkimizda] PRIMARY KEY CLUSTERED 
(
	[hakkimizdaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[iletisim]    Script Date: 6.07.2020 21:55:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[iletisim](
	[iletisimID] [int] IDENTITY(1,1) NOT NULL,
	[yazi] [nvarchar](max) NULL,
	[adres] [nvarchar](max) NULL,
	[tel] [nvarchar](20) NULL,
	[harita] [nvarchar](max) NULL,
 CONSTRAINT [PK_iletisim] PRIMARY KEY CLUSTERED 
(
	[iletisimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kategoriler]    Script Date: 6.07.2020 21:55:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kategoriler](
	[kateID] [int] IDENTITY(1,1) NOT NULL,
	[kategori] [nvarchar](50) NULL,
 CONSTRAINT [PK_kategori] PRIMARY KEY CLUSTERED 
(
	[kateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[news]    Script Date: 6.07.2020 21:55:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[news](
	[haberID] [int] IDENTITY(1,1) NOT NULL,
	[haberBasligi] [nvarchar](100) NULL,
	[sliderBasligi] [nvarchar](100) NULL,
	[yazi] [nvarchar](max) NULL,
	[resim] [nvarchar](500) NULL,
	[eklenmeTarihi] [datetime] NULL,
	[kategori] [int] NULL,
	[yazar] [int] NULL,
	[tiklanma] [int] NULL,
 CONSTRAINT [PK_news] PRIMARY KEY CLUSTERED 
(
	[haberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[videolar]    Script Date: 6.07.2020 21:55:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[videolar](
	[vID] [int] IDENTITY(1,1) NOT NULL,
	[adres] [nvarchar](200) NULL,
	[tarih] [datetime] NULL,
 CONSTRAINT [PK_videolar] PRIMARY KEY CLUSTERED 
(
	[vID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[yazarlar]    Script Date: 6.07.2020 21:55:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[yazarlar](
	[yazarID] [int] IDENTITY(1,1) NOT NULL,
	[adi] [nvarchar](50) NULL,
	[soyadi] [nvarchar](50) NULL,
	[mail] [nvarchar](50) NULL,
	[kullaniciAdi] [nvarchar](50) NULL,
	[sifre] [nvarchar](50) NULL,
	[P_resim] [nvarchar](500) NULL,
	[yetki] [bit] NULL,
 CONSTRAINT [PK_yazarlar] PRIMARY KEY CLUSTERED 
(
	[yazarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[hakkimizda] ON 

INSERT [dbo].[hakkimizda] ([hakkimizdaID], [yazi]) VALUES (1, N'Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500''lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960''larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.sadasd DeNEnende')
SET IDENTITY_INSERT [dbo].[hakkimizda] OFF
GO
SET IDENTITY_INSERT [dbo].[iletisim] ON 

INSERT [dbo].[iletisim] ([iletisimID], [yazi], [adres], [tel], [harita]) VALUES (1, N'dsfds fsdfsd fsd fsd fsd f sdf ds f sdf sd fsdfsdf sdf sdf ds f sdfsdfsdfsfsfsd f sdf sd fsd f sd f dsfdsfsdfsd fsd f ', N'klsdnd fgdf g d fgdf kjg df gdf g', N'464616546', N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d385398.5898646992!2d28.731988572376714!3d41.0049822726693!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14caa7040068086b%3A0xe1ccfe98bc01b0d0!2zxLBzdGFuYnVs!5e0!3m2!1str!2str!4v1493460095900')
SET IDENTITY_INSERT [dbo].[iletisim] OFF
GO
SET IDENTITY_INSERT [dbo].[kategoriler] ON 

INSERT [dbo].[kategoriler] ([kateID], [kategori]) VALUES (1, N'Teknolojı')
INSERT [dbo].[kategoriler] ([kateID], [kategori]) VALUES (2, N'Mobıl')
INSERT [dbo].[kategoriler] ([kateID], [kategori]) VALUES (3, N'Donanım')
INSERT [dbo].[kategoriler] ([kateID], [kategori]) VALUES (4, N'İnternet')
INSERT [dbo].[kategoriler] ([kateID], [kategori]) VALUES (5, N'Oyun')
INSERT [dbo].[kategoriler] ([kateID], [kategori]) VALUES (6, N'Yazılım')
SET IDENTITY_INSERT [dbo].[kategoriler] OFF
GO
SET IDENTITY_INSERT [dbo].[news] ON 

INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (1, N'deneme45 784 679', N'deneme45 784 679', N'000000000000', N'http://4.bp.blogspot.com/-cR7s-v5KoGM/UO8X8HAXunI/AAAAAAAAHy8/dItcUp6fYjM/s1600/jaguar+hd+2013+resimler+rooteto.jpg', CAST(N'2017-08-03T00:00:00.000' AS DateTime), 5, 1, 345)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (2, N'111111 dffdf df', N'deneme45 784 679', N'sf  dfg dfg fd gdf gfd g dfg', N'http://4.bp.blogspot.com/-cR7s-v5KoGM/UO8X8HAXunI/AAAAAAAAHy8/dItcUp6fYjM/s1600/jaguar+hd+2013+resimler+rooteto.jpg', CAST(N'2017-09-03T00:00:00.000' AS DateTime), 3, 1, 365)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (3, N'2222222 dffdf dffd', N'deneme45 784 679', N'Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia''daki Hampden-Sydney College''dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan ''consectetur'' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan "de Finibus Bonorum et Malorum" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan "Lorem ipsum dolor sit amet" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.', N'http://3.bp.blogspot.com/-y2ehfr4NRac/VHWS9iiDLaI/AAAAAAAAByo/kYVt3KO_T_8/s1600/hd-resimler-rooteto16.jpg%20border=', CAST(N'2017-08-03T00:00:00.000' AS DateTime), 2, 1, 54)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (4, N'333333 dffd dffdgg', N'deneme45 784 679', N'Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia''daki Hampden-Sydney College''dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan ''consectetur'' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan "de Finibus Bonorum et Malorum" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan "Lorem ipsum dolor sit amet" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.', N'http://3.bp.blogspot.com/-y2ehfr4NRac/VHWS9iiDLaI/AAAAAAAAByo/kYVt3KO_T_8/s1600/hd-resimler-rooteto16.jpg%20border=', CAST(N'2017-07-03T00:00:00.000' AS DateTime), 2, 1, 668)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (5, N' dfvfb fdfdgfd dffg', N'deneme45 784 679', N'sf  dfg dfg fd gdf gfd g dfg', N'http://3.bp.blogspot.com/-y2ehfr4NRac/VHWS9iiDLaI/AAAAAAAAByo/kYVt3KO_T_8/s1600/hd-resimler-rooteto16.jpg%20border=', CAST(N'2017-01-03T00:00:00.000' AS DateTime), 3, 1, 562)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (6, N'55555555 dfdffdg', N'deneme45 784 679', N'sf  dfg dfg fd gdf gfd g dfg', N'http://4.bp.blogspot.com/-cR7s-v5KoGM/UO8X8HAXunI/AAAAAAAAHy8/dItcUp6fYjM/s1600/jaguar+hd+2013+resimler+rooteto.jpg', CAST(N'2017-02-03T00:00:00.000' AS DateTime), 3, 1, 696)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (7, N'6666666 dfffdgdf', N'deneme45 784 679', N'Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia''daki Hampden-Sydney College''dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan ''consectetur'' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan "de Finibus Bonorum et Malorum" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan "Lorem ipsum dolor sit amet" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.', N'http://3.bp.blogspot.com/-y2ehfr4NRac/VHWS9iiDLaI/AAAAAAAAByo/kYVt3KO_T_8/s1600/hd-resimler-rooteto16.jpg%20border=', CAST(N'2017-03-03T00:00:00.000' AS DateTime), 2, 1, 352)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (8, N'7777777 dfdfggdf', N'deneme45 784 679', N'Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia''daki Hampden-Sydney College''dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan ''consectetur'' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan "de Finibus Bonorum et Malorum" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan "Lorem ipsum dolor sit amet" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.', N'http://3.bp.blogspot.com/-y2ehfr4NRac/VHWS9iiDLaI/AAAAAAAAByo/kYVt3KO_T_8/s1600/hd-resimler-rooteto16.jpg%20border=', CAST(N'2017-04-03T00:00:00.000' AS DateTime), 2, 2, 31)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (11, N'888888888888 dfdfgdfg', N'deneme45 784 679', N'Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia''daki Hampden-Sydney College''dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan ''consectetur'' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan "de Finibus Bonorum et Malorum" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan "Lorem ipsum dolor sit amet" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.', N'http://3.bp.blogspot.com/-y2ehfr4NRac/VHWS9iiDLaI/AAAAAAAAByo/kYVt3KO_T_8/s1600/hd-resimler-rooteto16.jpg%20border=', CAST(N'2017-06-03T00:00:00.000' AS DateTime), 2, 2, 10)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (12, N'duranın deneme kaydı', N'duranın kaydı', N'<p>adasdadasd dasfdsfs sdf sdf s fs df sdf sdf sd fs f sf sdfsdfds fs fs f sf sfsfsdf s fdsf dsfdsfdsf dsf ds f</p>', N'/Content/img/4993f151227e399bf9d1671c09c395ad_large.jpeg', CAST(N'2017-04-21T14:43:41.047' AS DateTime), 1, 2, 14)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (13, N'editör', N'abdulsamet dündar', N'<p><span style="font-family: ''Open Sans'', Arial, sans-serif; text-align: justify;">&nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</span></p>', N'http://www.arabaresimleri2.com/var/albums/2013-Audi-R8/Audi_R8_2013_Resim.jpg?m=1359471838', CAST(N'2017-05-04T19:41:04.527' AS DateTime), 6, 1, 4)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (14, N'asdasdasd', N'asdasd', N'<p><strong style="margin: 0px; padding: 0px; font-family: ''Open Sans'', Arial, sans-serif; text-align: justify;">Lorem Ipsum</strong><span style="font-family: ''Open Sans'', Arial, sans-serif; text-align: justify;">&nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</span></p>', N'http://www.resimyukleyin.net/images/2016/02/13/Lamborghini-Aventador-Resim.jpg', CAST(N'2017-05-12T13:44:22.253' AS DateTime), 1, 1, 2)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (15, N'sdasdas', N'dasdasd', N'<p><strong style="margin: 0px; padding: 0px; font-family: ''Open Sans'', Arial, sans-serif; text-align: justify;">Lorem Ipsum</strong><span style="font-family: ''Open Sans'', Arial, sans-serif; text-align: justify;">&nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</span></p>', N'https://wallpaperscraft.com/image/lamborghini_murcielago_lp670_4_sv_front_jackdarton_glare_night_lights_95095_602x339.jpg', CAST(N'2017-05-12T13:45:26.790' AS DateTime), 1, 1, 2)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (16, N'asdasdasd asdasdasd', N'asdasd asdasda dasdasdasd asdasdas', N'<p>sadsadasd sadasdas dasdasd</p>', N'http://www.webmasto.com/wp-content/uploads/2015/07/teknoloji.jpg', CAST(N'2017-05-13T00:01:30.090' AS DateTime), 5, 1, 1)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (17, N'asdasd dgdghgj hgjjkhjk hljkl', N'asdasd dgdghgj hgjjkhjk hljkl', N'<p>asdasda ğşjk4kluı4&ouml;uku k 76444 8646 44 684 6</p>', N'http://www.algiozelegitim.com.tr/wp-content/uploads/teknoloji-otizm.jpg', CAST(N'2017-05-13T00:02:14.810' AS DateTime), 5, 1, 1)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (18, N'dfghjh dfgdfg fdgfdgdfg', N'dhgjh dfgfdgd fgdfgfdg', N'fhjghjk gdfgfd gdgdfg dfgdgdg', N'\Content\img\10612945_728094303893024_6348138190360358863_n.jpg', CAST(N'2017-05-20T13:20:02.767' AS DateTime), 1, 1, 1)
INSERT [dbo].[news] ([haberID], [haberBasligi], [sliderBasligi], [yazi], [resim], [eklenmeTarihi], [kategori], [yazar], [tiklanma]) VALUES (19, N'aesf rgfthjkhfgh fgghfh', N'ddfhgjk dffghfg fghfgh', N'fghgfhf fhfghfgh fgfhfgh gfhgfhgfh', N'/Content/img/12936641_862346467224753_7783078990875773263_n.jpg', CAST(N'2017-05-20T13:27:21.563' AS DateTime), 2, 1, 3)
SET IDENTITY_INSERT [dbo].[news] OFF
GO
SET IDENTITY_INSERT [dbo].[videolar] ON 

INSERT [dbo].[videolar] ([vID], [adres], [tarih]) VALUES (3, N'https://www.youtube.com/embed/N7BbpEC-7i4', CAST(N'2017-04-22T00:59:01.383' AS DateTime))
INSERT [dbo].[videolar] ([vID], [adres], [tarih]) VALUES (4, N'https://www.youtube.com/embed/N7BbpEC-7i4', CAST(N'2017-04-22T01:01:52.810' AS DateTime))
SET IDENTITY_INSERT [dbo].[videolar] OFF
GO
SET IDENTITY_INSERT [dbo].[yazarlar] ON 

INSERT [dbo].[yazarlar] ([yazarID], [adi], [soyadi], [mail], [kullaniciAdi], [sifre], [P_resim], [yetki]) VALUES (1, N'Yusuf', N'AYHAN', N'yusufay.ay@gmail.com', N'yusufay', N'123', N'http://sendeyim.com/uploads/resim-galerisi/kaplan-resimleri_913822.jpg', 1)
INSERT [dbo].[yazarlar] ([yazarID], [adi], [soyadi], [mail], [kullaniciAdi], [sifre], [P_resim], [yetki]) VALUES (2, N'Ahmet', N'DURAN', N'ahmet.duran@gmail.com', N'duran22', N'12', NULL, 0)
INSERT [dbo].[yazarlar] ([yazarID], [adi], [soyadi], [mail], [kullaniciAdi], [sifre], [P_resim], [yetki]) VALUES (3, N'ali', N'haha', N'ali@gmail.com', N'ha', N'11', NULL, 0)
INSERT [dbo].[yazarlar] ([yazarID], [adi], [soyadi], [mail], [kullaniciAdi], [sifre], [P_resim], [yetki]) VALUES (4, N'sdgsg', N'wtrstd', N'sdfsdf', N'fgdfg', N'gfhfgh', NULL, 0)
SET IDENTITY_INSERT [dbo].[yazarlar] OFF
GO
ALTER TABLE [dbo].[news]  WITH CHECK ADD  CONSTRAINT [FK_news_kategoriler] FOREIGN KEY([kategori])
REFERENCES [dbo].[kategoriler] ([kateID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[news] CHECK CONSTRAINT [FK_news_kategoriler]
GO
ALTER TABLE [dbo].[news]  WITH CHECK ADD  CONSTRAINT [FK_news_yazarlar] FOREIGN KEY([yazar])
REFERENCES [dbo].[yazarlar] ([yazarID])
GO
ALTER TABLE [dbo].[news] CHECK CONSTRAINT [FK_news_yazarlar]
GO
USE [master]
GO
ALTER DATABASE [151601009] SET  READ_WRITE 
GO
