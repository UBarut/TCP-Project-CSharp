USE [master]
GO
/****** Object:  Database [CepteSefdb]    Script Date: 6.02.2022 19:56:50 ******/
CREATE DATABASE [CepteSefdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CepteSefdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CepteSefdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CepteSefdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CepteSefdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CepteSefdb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CepteSefdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CepteSefdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CepteSefdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CepteSefdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CepteSefdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CepteSefdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [CepteSefdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CepteSefdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CepteSefdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CepteSefdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CepteSefdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CepteSefdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CepteSefdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CepteSefdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CepteSefdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CepteSefdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CepteSefdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CepteSefdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CepteSefdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CepteSefdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CepteSefdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CepteSefdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CepteSefdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CepteSefdb] SET RECOVERY FULL 
GO
ALTER DATABASE [CepteSefdb] SET  MULTI_USER 
GO
ALTER DATABASE [CepteSefdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CepteSefdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CepteSefdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CepteSefdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CepteSefdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CepteSefdb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CepteSefdb', N'ON'
GO
ALTER DATABASE [CepteSefdb] SET QUERY_STORE = OFF
GO
USE [CepteSefdb]
GO
/****** Object:  Table [dbo].[Category_Of_Food]    Script Date: 6.02.2022 19:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_Of_Food](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](50) NULL,
	[Category_Picture] [nvarchar](50) NULL,
 CONSTRAINT [PK_Type_Of_Food] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorites]    Script Date: 6.02.2022 19:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorites](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Favorite_FoodID] [int] NULL,
 CONSTRAINT [PK_Favorites] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 6.02.2022 19:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Food] [nvarchar](50) NULL,
	[CategoryID] [int] NULL,
	[Ingredients] [nvarchar](100) NULL,
	[Steps] [text] NULL,
	[FoodExplanation] [nvarchar](1000) NULL,
	[IngredientsText] [text] NULL,
	[Food_Picture] [nvarchar](50) NULL,
	[Total_Views] [int] NULL,
 CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nutrients]    Script Date: 6.02.2022 19:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nutrients](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nutrient_Name] [nvarchar](50) NULL,
	[Group_Of_Nutrient] [nvarchar](50) NULL,
	[TON_ID] [int] NULL,
	[OON_ID] [int] NULL,
 CONSTRAINT [PK_Nutrients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Origin_Of_Nutrient]    Script Date: 6.02.2022 19:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Origin_Of_Nutrient](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Origin] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Origin_Of_Nutrient] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_Of_Nutrient]    Script Date: 6.02.2022 19:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_Of_Nutrient](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Types] [nvarchar](50) NULL,
 CONSTRAINT [PK_Type_Of_Nutrient] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Information]    Script Date: 6.02.2022 19:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Information](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Mail] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[CardID] [int] NULL,
	[Port] [int] NULL,
 CONSTRAINT [PK_User_Information] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category_Of_Food] ON 

INSERT [dbo].[Category_Of_Food] ([ID], [Category], [Category_Picture]) VALUES (1, N'Çorbalar', N'corba.jpg')
INSERT [dbo].[Category_Of_Food] ([ID], [Category], [Category_Picture]) VALUES (2, N'Et Yemekleri', N'et_yemekleri.jpg')
INSERT [dbo].[Category_Of_Food] ([ID], [Category], [Category_Picture]) VALUES (3, N'Etli Sebzeli Yemekler', N'etli_sebzeli_yemekler.jpg')
INSERT [dbo].[Category_Of_Food] ([ID], [Category], [Category_Picture]) VALUES (4, N'Sebze Yemekler', N'sebze_yemekleri.jpg')
INSERT [dbo].[Category_Of_Food] ([ID], [Category], [Category_Picture]) VALUES (5, N'Zeytinyağlılar', N'zeytinyaglilar.jpg')
INSERT [dbo].[Category_Of_Food] ([ID], [Category], [Category_Picture]) VALUES (6, N'Hamur İşleri', N'hamur_isleri.jpg')
INSERT [dbo].[Category_Of_Food] ([ID], [Category], [Category_Picture]) VALUES (7, N'Salatalar', N'salatalar.jpg')
INSERT [dbo].[Category_Of_Food] ([ID], [Category], [Category_Picture]) VALUES (8, N'Fast Food', N'fastfood.jpg')
INSERT [dbo].[Category_Of_Food] ([ID], [Category], [Category_Picture]) VALUES (9, N'Kahvaltı', N'kahvaltı.jpg')
INSERT [dbo].[Category_Of_Food] ([ID], [Category], [Category_Picture]) VALUES (10, N'Meze ve Turşu', N'meze_ve_tursular.jpg')
INSERT [dbo].[Category_Of_Food] ([ID], [Category], [Category_Picture]) VALUES (11, N'Baklagiller', N'baklagiller.jpg')
INSERT [dbo].[Category_Of_Food] ([ID], [Category], [Category_Picture]) VALUES (12, N'Tatlı', N'tatli.jpg')
INSERT [dbo].[Category_Of_Food] ([ID], [Category], [Category_Picture]) VALUES (13, N'Kek ve Kurabiye', N'kurabiye.jpg')
SET IDENTITY_INSERT [dbo].[Category_Of_Food] OFF
GO
SET IDENTITY_INSERT [dbo].[Favorites] ON 

INSERT [dbo].[Favorites] ([ID], [UserID], [Favorite_FoodID]) VALUES (3, 1, 4)
INSERT [dbo].[Favorites] ([ID], [UserID], [Favorite_FoodID]) VALUES (21, 1, 2)
INSERT [dbo].[Favorites] ([ID], [UserID], [Favorite_FoodID]) VALUES (24, 2, 11)
INSERT [dbo].[Favorites] ([ID], [UserID], [Favorite_FoodID]) VALUES (25, 2, 3)
INSERT [dbo].[Favorites] ([ID], [UserID], [Favorite_FoodID]) VALUES (26, 2, 1)
INSERT [dbo].[Favorites] ([ID], [UserID], [Favorite_FoodID]) VALUES (28, 1, 1)
SET IDENTITY_INSERT [dbo].[Favorites] OFF
GO
SET IDENTITY_INSERT [dbo].[Foods] ON 

INSERT [dbo].[Foods] ([ID], [Food], [CategoryID], [Ingredients], [Steps], [FoodExplanation], [IngredientsText], [Food_Picture], [Total_Views]) VALUES (1, N'Mercimek Çorbası', 1, N'1,2,3,4', N'Kırmızı mercimek çorbası için sıvı yağı tencereye alınarak yemeklik doğranan soğanlar hafif pembeleşinceye kadar kavrulur.
Daha sonra un ilave edilerek kısık ateşte kavurmaya devam edilir.
Salça kullanılacak ise salça ilave edilir, kavrulduktan sonra küp küp doğranmış havuç ve iyice yıkanıp suyu süzülen mercimekler ilave edilir.
Üzerine su eklenerek karıştırılır ve tencerenin kapağı kapatılır. Çorbamız kaynayana kadar orta ateşte, kaynadıktan sonra mercimekler ve havuçlar yumuşayana kadar ara ara karıştırılarak kısık ateşte pişirilir.
Çorba piştikten sonra el blenderı ile güzelce ezilir. Eğer blenderiniz yoksa süzgeçten de geçirebilirsiniz.
Karabiber, tuz ve isteğe bağlı olarak kimyon eklenir ve karıştırılır. 5 dakika daha pişirelerek ocaktan alınır.
Kıvamı koyu gelirse size, bir miktar su ilave edilerek bir taşım kaynatılır.
Bu arada küçük bir tavaya iki yemek kaşığı tereyağı alınır, kızdırılır ve bir tatlı kaşığı kırmızı toz biber eklenerek ocaktan alınır.
Mercimek çorbası servis kasesine alındıktan sonra üzerine kırmızı biberli sos gezdirilir ve bir dilim limon ile servis edilir.', N'Mercimek çorbası tarifimi deneyeceklere şimdiden afiyet olsun.', N'2 su bardağı kırmızı mercimek
1 adet soğan
2 yemek kaşığı un
1 adet havuç
Yarım yemek kaşığı biber ya da  domates salçası (rengi kırmızı olsun isterseniz artırabilir ya da hiç kullanmayabilirsiniz)
1 tatlı kaşığı tuz
Yarım çay kaşığı karabiber
1 çay kaşığı kimyon (isteğe bağlı)
2 litre sıcak su
5 yemek kaşığı sıvı yağ', N'mercimek_corbasi.jpg', 72)
INSERT [dbo].[Foods] ([ID], [Food], [CategoryID], [Ingredients], [Steps], [FoodExplanation], [IngredientsText], [Food_Picture], [Total_Views]) VALUES (2, N'Ezogelin', 1, N'1,3', N'Ezogelin çorbası yapmak için düdüklü tencerede önce rendelemiş olduğumuz soğanı ve ezmiş olduğumuz sarımsağı tereyağında kavuruyoruz. Soğanlar diriliğini kaybetsin yeterli yakmadan orta ateşte kavuralım.
Soğanlar kavrulunca naneyi, kırmızı biberi ve salçayı ilave edip. Kavurmaya devam edelim.
Bir iki karıştırdıktan sonra yıkadığımız mercimeği, pirinci, bulguru ve tuzunu da ilave ederek karıştıralım.
Başka bir tarafta kaynamakta olan 2 litreye yakın suyu üzerine boşaltalım.
Düdüklünün kapağını ve düdüğünü kapattıktan sonra 10 dakika pişiriyoruz. Normal tencerede de yapabilirsiniz ama biraz daha geç pişecektir (yaklaşık 30-40 dakika sürecektir).', N'Zenginliği ile kendini kanıtlamış mutfağımıza özgü olan, çok sevilen ezogelin çorbasının bu kez pratik bir halini paylaşmak istiyorum. Düdüklü tencerede 10 dakikada pişen çorbamızı isterseniz normal tencerede de pişirebilirsiniz. Detayını tarifin devamında güzelce açıklayacağım.Çorbamızın ana malzemeleri olan kırmızı mercimek, pirinç  ve bulgur baharatlar ile lezzetine lezzet katıyor. Besleyici değeri çok yüksek ve uzun süre tokluk hissi veren ezogelin çorbasını sevmeyen yoktur sanırım.Gelelim Ezogelin Çorbasının yapımına,', N'1 su bardağı kırmızı mercimek
1 tatlı kaşığı pirinç
1 tatlı kaşığı bulgur
2 çay kaşığı pul biber
1 yemek kaşığı nane
2 diş sarımsak
1 orta boy soğan
1 yemek kaşığı biber salçası
1 yemek kaşığı tereyağı
2 litreye yakın sıcak su
Tuz', N'ezogelin.jpg', 34)
INSERT [dbo].[Foods] ([ID], [Food], [CategoryID], [Ingredients], [Steps], [FoodExplanation], [IngredientsText], [Food_Picture], [Total_Views]) VALUES (3, N'Tavuksuyu', 1, N'1,4,6', N'İlk olarak tavuk butunu haşlayalım.
Daha sonra uygun bir tencereye sıvı yağı alalım, ardından tereyağını da ekleyerek yağımızı eritelim.
Yağımız eridikten sonra küp küp doğradığımız havuçları ve rendelediğimiz sarımsağı tencereye alalım, 2-3 dakika kadar kavuralım.
Unu da ilave edip 1-2 dakika daha kavurduktan sonra tavuk suyunu tencereye alalım ve kaynayana kadar pişirelim.
Kaynayan çorbamıza tel şehriyeyi ilave edelim, haşladığımız tavuk etlerini, tuzu ve karabiberi ekleyip karıştırarak şehriyeler pişene kadar çorbamızı pişirelim.
Son olarak ince ince kıydığımız maydanozu da ekleyerek ocaktan alalım. Sıcak sıcak çorbamızı servis edelim. Deneyeceklere şimdiden afiyet olsun.', N'Yapması hem çok kolay hem de çok lezzetli bir çorba tarifim var. Deneyenlerin yorumlarını ve fotoğraflarını bekliyorum', N'1 çay bardağı tel şehriye
1 adet tavuk but
6 su bardağı tavuk suyu
2 yemek kaşığı sıvı yağ
1 yemek kaşığı tereyağı
1 adet havuç
1 diş sarımsak
1,5 yemek kaşığı un
Tuz 
Karabiber 
Maydanoz', N'tavuk_suyu_corba.jpg', 19)
INSERT [dbo].[Foods] ([ID], [Food], [CategoryID], [Ingredients], [Steps], [FoodExplanation], [IngredientsText], [Food_Picture], [Total_Views]) VALUES (4, N'Köfte', 2, N'1,3,8', N'Köfte harcı için kıymayı yoğurma kabına alıyoruz. (eğer ekmek kullanacaksınız ayrı bir kapta ekmeği az su ile ıslatıp yumuşatın. )
Kıymanın üzerine rendelenmiş soğanı ve sarımsağı ekmek içini ya da galeta ununu 4 yemek kaşığı kadar suyu(ekmek kullanıp ıslattıysanız su eklemeyin. Galeta unu kullanırsanız suyu ekleyin. )ve bütün baharatları ekleyip iyice yoğurun.
Son olarak yumurtayı,irmiği ve karbonatı ekleyip yaklaşık 10 dakika boyunca yoğurmaya devam edin.
En son köfte harcını 10 kez yukarı kaldırıp kaba sertçe vurun. Bu işlemi mutlaka yapın.
Hazır olan köfte harcının üzerini streç filmle kapatıp dinlenmeye bırakın.
Pişireceğiniz vakit köfte harcını uzun ince parmak şeklinde şekillendirip yapışmaz yüzeyli bir tavada arkalı önlü kızartın.
Kıymanız yağlıysa tavaya yağ eklemenize gerek yoktur. Eğer yağsız bir kıymayla yapıyorsanız az sıvı yağ ekleyip kızartabilirsiniz.
Piyazı için haşlanmış fasülyeleri salatayı yapacağınız kaba alın.
Üzerine ince kıyılmış maydanozu,küp doğranmış domatesleri,yeşil soğanı ve piyazlık doğranmış soğanı alıp karıştırın.
En son zeytinyağı,limon suyu ve baharatlarını da ekleyip karıştırın.
İsteğe bağlı olarak nar ekşisi de ekleyebilirsiniz. Afiyet olsun.', N'Köfte harcını bir gece önceden yapıp buzdolabında dinlendirirseniz çok daha lezzetli olacaktır. Ama vaktiniz yoksa dolapta mutlaka 2 saat dinlendirin.', N'500 gram kıyma
1 adet soğan
2 dilim ekmek ya da galeta unu
1 adet yumurta
2 diş sarımsak
Yarım yemek kaşığı irmik
4 yemek kaşığı su
Yarım çay kaşığı karbonat(silme)
1 tatlı kaşığı tuz
1 çay kaşığı karabiber
1 çay kaşığı kimyon
1 çay kaşığı pul biber', N'köfte.jpg', 61)
INSERT [dbo].[Foods] ([ID], [Food], [CategoryID], [Ingredients], [Steps], [FoodExplanation], [IngredientsText], [Food_Picture], [Total_Views]) VALUES (5, N'Adana Dürüm', 2, N'2,4,9', N'Sogˆanı sarımsagˆı rendeleyin, maydanozu ince ince kıyın. Kıymayı derin bir kaba alıp u¨zerine sogˆan, sarımsak, maydanoz ve baharatları ekleyip iyice yogˆuralım. Harcımızı yarım saat dinlendirelim.
Fırını 200 derece de ısıtıp ızgara telinin altına bir tane fırın tepsisi yerles¸tirelim, adanaları da telin u¨zerine koyup, u¨zeri kızarsan kadar pis¸meye bırakalım.
Salatamızı hazırlayalım sogˆanları ay s¸eklinde dogˆrayalım domatesleri bu¨yu¨k ku¨pler halinde dogˆrayalım bir tutam maydanozu kıyalım derin bir kaba alalım üzerine sumak ve tuz koyup karıs¸tıralım.
Sos ic¸in ku¨c¸u¨k bir tavaya sıvı yağ ve salc¸ayı koyup kavuralım ve altını kapatalım. Pidelerin u¨zerine sosu su¨ru¨p kenara koyalım.
Fırından c¸ıkardıgˆımız adanaları pidelerin u¨zerine koyalım u¨stu¨ne salatayı koyup saralım.', N'Adana kebabı, Adana''ya özgü, "zırh" adı verilen, satıra benzer bir bıçak ile elde kıyılan parça etten yapılan Türk mutfağında bir kebap veya şiş köfte çeşidi. Adana kebabını diğer kebaplardan ayıran en belirgin özellik kullanılan ettir.', N'350 gram dana koyun karıs¸ık kıyma
1 adet orta boy sogˆan
1 dis¸ sarımsak
Bir tutam maydanoz
1 tatlı kas¸ıgˆı domates biber karıs¸ık salc¸a
Pul biber
Karabiber
Kırmızı toz biber
I·sot
Tuz
Tırnak pide', N'adana_dürüm.jpg', 25)
INSERT [dbo].[Foods] ([ID], [Food], [CategoryID], [Ingredients], [Steps], [FoodExplanation], [IngredientsText], [Food_Picture], [Total_Views]) VALUES (6, N'Kıymalı Mercimek', 4, N'2,4,7,8', N'Sıvı yağı aldığımız tencerede, kıyma ile küçük küçük doğradığımız kuru soğanı kavurup, salçayı ekliyoruz.
Yıkanmış mercimeği de ekleyip, 3-4 dk daha kavurduktan sonra tuz ve baharatları ekliyoruz.
Üzerini kapatacak kadar kaynamış su ekleyip, mercimekler yumuşayıncaya kadar pişiriyoruz.', N'Mercimek, baklagiller familyasında yer alan Lens cinsine dahil 4 türden biridir. Lens cinsi içinde bulunan tüm türler, mercek şekilleri ve yenilebilir tohumları sebebiyle topluca "mercimekler" olarak anılsa da Lens culinaris "mercimek" denildiğinde en çok akla gelen ve en sık tüketilen mercimek türüdür. ', N'1 su bardağı yeşil mercimek
150 gram kıyma
1 adet kuru soğan
1 yemek kaşığı salça
Tuz
Karabiber
Kimyon
Sıvı yağ', N'kiymali_mercimek.jpg', 34)
INSERT [dbo].[Foods] ([ID], [Food], [CategoryID], [Ingredients], [Steps], [FoodExplanation], [IngredientsText], [Food_Picture], [Total_Views]) VALUES (7, N'Mercimek', 3, N'2,3', N'Yeşil mercimek tencereye koyulur. 4 su bardağı su ile 20 dakika haşlanır.
Haşlandıktan sonra suyu süzülür ve azıcık yıkanır.
Soğan ve sarımsak yağda kavrulur ve üzerine salçası ilave edilir ve az daha kavrulur.
Sonrasında tencereye alınan yeşil mercimeklerin üzerine kavrulan soğan ve salça ilave edilir.
Üzerine 7 su bardağı su eklenir. Tuzu da atıldıktan sonra pişmeye bırakılır.', N'Mercimek, baklagiller familyasında yer alan Lens cinsine dahil 4 türden biridir. Lens cinsi içinde bulunan tüm türler, mercek şekilleri ve yenilebilir tohumları sebebiyle topluca "mercimekler" olarak anılsa da Lens culinaris "mercimek" denildiğinde en çok akla gelen ve en sık tüketilen mercimek türüdür. ', N'1,5 su bardağı yeşil mercimek
1 adet kuru soğan
3-4 diş sarımsak
2 yemek kaşığı salça
7 su bardağı su
2 çay kaşığı tuz
Yarım çay bardağı zeytinyağı (ya da sıvı yağ)', N'mercimek.jpg', 23)
INSERT [dbo].[Foods] ([ID], [Food], [CategoryID], [Ingredients], [Steps], [FoodExplanation], [IngredientsText], [Food_Picture], [Total_Views]) VALUES (8, N'Kuru Fasulye', 3, N'1,2,3,8', N'Kuru fasulyeler 1 gece önceden suya ıslanır. Islama suyu dökülüp yeni su eklenerek haşlanır.
Minik küpler halinde doğranmış kuru soğan ve biber sıvı yağda pembeleşene kadar kavrulur.
Üzerine salçalar eklenerek karıştırılır, haşlanmış kuru fasulyeler de eklenerek kavrulmaya devam edilir (etsiz kuru fasulyede su eklenmeden önce bolca kavurmak gerekir.)
Yaklaşık 3-4 dk. kavrulduktan sonra üzerini 3 parmak geçecek kadar su eklenir baharatlar da eklenerek harlı ateşte 5 dk. kadar pişirilip altı kısılır.
Fasulyeler yumuşayana kadar pişirilir (fasulyenin cinsine göre değişiklik gösterir.). Afiyet olsun.', N'Kuru fasulye, Türk mutfağında pişmiş bir fasulye yemeğidir. Başta beyaz fasulye ve zeytinyağı ile yapılır ve neredeyse her zaman soğan ve domates salçası kullanılır. Bazen başka sebze veya et de eklenebilir. Kuru fasulye pirinç veya bulgurla birlikte servis edilir.', N'2 su bardağı kuru fasulye
1 adet kuru soğan
1 adet kırmızı süs biberi
1 yemek kaşığı domates salçası
1 yemek kaşığı biber salçası
4 yemek kaşığı sıvı yağ
1 çay kaşığı karabiber
1 çay kaşığı kırmızı toz biber
1 çay kaşığı kimyon', N'kuru_fasulye.jpg', 7)
INSERT [dbo].[Foods] ([ID], [Food], [CategoryID], [Ingredients], [Steps], [FoodExplanation], [IngredientsText], [Food_Picture], [Total_Views]) VALUES (9, N'Nohut', 3, N'2,3,4,7', N'İlk olarak etimizi uygun bir tencereye alalım, üzerini 2 parmak geçecek kadar su ilave ederek yaklaşık 20-25 dakika kaynamaya bırakalım. Etler haşlanırken üzerinde biriken kahve rengi köpükleri kaşık yardımı ile alalım.
Sürenin sonunda etlerimizi kontrol edelim ve kevgir yardımı ile etlerimizi alarak suyunu bir kenarda bekletelim.
Ayrı bir tencereye sıvı yağ ve yemeklik doğranmış soğanı alarak soğanlar pembeleşene kadar 1-2 dakika kavuralım.
Daha sonra yeşil biber ve kırmızı biberi ekleyerek kavurmaya devam edelim. Biberlerin çok kavrulup erimesini istemediğim için bu aşamada çok uzun kavurmadım.
Yemeğimize salçaları da ilave edip 1-2 dakika daha kavrulduktan sonra haşlanmış nohutları ekleyelim. Ben bu tarifte kullanmak için 2 su bardağı kadar nohutu sıcak suda 3-4 saat kadar beklettim, ardından düdüklü tencerede 15 dakika pişirdim. Pişme süresi nohutun cinsine göre değişecektir, kontrollü olmakta fayda var.
Ardından etlerimizi tenceremize ekleyelim, karıştıralım.
Kırmızı toz biber, karabiber ve tuzu ilave edip son olarak 4-5 dakika karıştıralım ve yemeğin suyunu ekleyelim. ben bu aşamada 1 su bardağı et suyu, 3 su bardağı sıcak su kullandım. Siz dilerseniz hiç et suyu kullanmadan ya da sadece et suyu ile de hazırlayabilirsiniz.
Yemeğimizi şöyle bir karıştıralım ve tencerenin kapağını kapatarak 15-20 dakika kadar kısık ateşte pişmeye bırakalım. Eğer yemeğinizi etsiz yapmak isterseniz eti ekleme kısmını atlayarak diğer aşamaları uygulayabilirsiniz.
Nohut yemeği servise hazır, deneyeceklere şimdiden afiyet olsun.', N'Kuru fasulye, Türk mutfağında pişmiş bir fasulye yemeğidir. Başta beyaz fasulye ve zeytinyağı ile yapılır ve neredeyse her zaman soğan ve domates salçası kullanılır. Bazen başka sebze veya et de eklenebilir. Kuru fasulye pirinç veya bulgurla birlikte servis edilir.', N'250g kuşbaşı et
3-4 yemek kaşığı sıvı yağ
1 adet soğan
2 adet yeşil biber
1 adet kırmızı biber
1 yemek kaşığı domates salçası
1 yemek kaşığı biber salçası
2 su bardağı nohut
1 çay kaşığı kırmızı toz biber
Yarım çay kaşığı karabiber
Tuz', N'nohut.jpg', 5)
INSERT [dbo].[Foods] ([ID], [Food], [CategoryID], [Ingredients], [Steps], [FoodExplanation], [IngredientsText], [Food_Picture], [Total_Views]) VALUES (10, N'Taze Fasulye', 5, N'1,3,4,5', N'Yeşil fasulye yemeği için öncelikle zeytinyağında yemeklik doğranmış soğanı pembeleşinceye kadar kavuralım.
Ardından salça, doğranmış domatesler ve baharatları da ekleyip bir iki dakika kavuralım.
Yıkayıp ortadan ikiye kestiğimiz ve dilimlediğimiz fasulyeleri ekleyip kavurmaya devam edelim.
Fasulyeler renk değiştirip yumuşamaya başlayıncaya kadar kavuralım. Fasulyenin hızlı pişmesi için suyunu eklemeden iyice kavurmak önemli. Pişme süresi fasulyenin cinsine göre değişir, çatal kolay batıyorsa ve gıcırdamıyorsa yumuşamış demektir :) Ben çalı fasulye kullandım bu arada, enli bir fasulye olduğu için ortadan da dikine kesiyorum, siz nasıl tercih ederseniz. Kavururken tenceyi kısık ateşe alıp kapağı kapatmayı unutmayın. Yeterince taze güzel bir fasulye ise su eklemeye gerek kalmadan kendi suyu ile kavrulurken bile pişebilir.
Tuzunu ayarlayalım, yeşil fasulye yeterince kavrulunca sıcak suyunu ekleyip pişmeye bırakalım.
Arada bir fasulye alıp ısırarak pişip pişmediğini kontrol edebilirsiniz.
Ocağı kapatınca 15-20 dk ilk sıcaklığının çıkmasını bekleyelim. Taze fasulye yemeğini sıcak olarak da ılık olarak da servis edebilirsiniz. Zeytinyağlı gibi soğuk servis etmek isterseniz salça eklemeden aynı şekilde pişirebilirsiniz. Şimdiden afiyet olsun.', N'Yeşil fasulye, adi fasulyenin çeşitli çeşitlerinin genç, olgunlaşmamış meyveleridir, ancak koşucu fasulye, yardlong fasulye ve sümbül fasulyesinin olgunlaşmamış veya genç baklaları benzer şekilde kullanılır.', N'Yarım kg taze yeşil fasulye (çalı fasulye kullandım)
2 adet domates
1 adet soğan
Yarım çay kaşığı pul biber
Yarım çay kaşığı karabiber
2 çay kaşığı tuz
Yarım çay bardağı zeytinyağı (veya sıvı yağ)
1,5 yemek kaşığı domates salçası
3 su bardağı sıcak su', N'taze_fasulye.jpg', 45)
INSERT [dbo].[Foods] ([ID], [Food], [CategoryID], [Ingredients], [Steps], [FoodExplanation], [IngredientsText], [Food_Picture], [Total_Views]) VALUES (11, N'Su Böreği', 6, N'1,3,4', N'Yumurtalara suyu ekledikten sonra karıştırırız.
Karışınca unu ve tuzu ilave ederek sıkı bir hamur yoğururuz.
Bu hamurdan yumurtadan biraz büyük bezeler yaparız. 12 tane beze çıkar.
Bezelerin üzerini hafif nemli bir tülbentle örter, yarım saat dinlendiririz.
Diğer tarafta rendelemiş olduğumuz peyniri ve ince kıydığımız maydanozu birbiriyle harmanlarız.
Başka bir tavaya yağı koyar eritiriz. Yağ ve peynir hazır olur.
Dinlenmiş olan bezeleri un yardımıyla açarız.
4 tanesini açınca genişçe bir tencerede kaynamakta olan suyun içerisine öncelikle tuz atarız. Tuz olmazsa yufka parçalanır. Sudan çıkmaz.
Sonra açtığımız yufkaları iki elimizle tutarak yavaşça suyun içine serer gibi bırakırız.
Tahta kaşıkla kenarlardan yufkanın üzerine su atarız ki yufka birbirine yapışmasın.
Islanan yufkayı hemen yanımızda bulunan soğuk su dolu kabın içine alırız.
Sonra elimizle fazla suyunu sızdırarak yağlamış olduğumuz tepsiye buruşuk bir şekilde yerleştiririz.
Soğuk su ılıklaşacağından 3 yufkada bir suyu değiştiririz. Soğuk olmalı.
4. yufkaya da aynı işlemi uyguladıktan sonra arasına peynirli karışımdan yayar, üzerine tereyağını gezdiririz. Her 4 yufkada aynı işlemi yaparız (2 defa). Tereyağını da bu işlemleri yapmak için göz kararı 3’e böleriz.
En üst kısmada 4 yufkayı aynı şekilde serdikten sonra üzerini tereyağıyla yağlarız.
Pişerken kabarmaması için pişirmeden önce dilim dilim keseriz.
200 derece fırında üzeri kızarıncaya kadar yarım saat pişiririz.', N'Su böreği, Türk mutfağında bir tepsi böreği çeşididir. Haşlanmış yufka katmanları arasına su böreğinin çeşidine göre kıyma veya beyaz peynir harcı serpiştirilip en üstü yumurtalanmış bir şekilde fırınlanarak yapılır. Doğu Anadolu Bölgesinde ise genellikle civil peynirli yapılmaktadır.', N'6 adet yumurta
 1 çay bardağı su
 1 yemek kaşığı tuz
 Ele yapışmayan sıkı bir hamur için alabildiğince un
İçi için:

 Salamura köy peyniri veya herhangi bir peynir
 Yarım kilo tereyağı
 Maydanoz', N'su_böregi.jpg', 16)
INSERT [dbo].[Foods] ([ID], [Food], [CategoryID], [Ingredients], [Steps], [FoodExplanation], [IngredientsText], [Food_Picture], [Total_Views]) VALUES (12, N'Çoban Salatası', 7, N'1,2,4,6', N'İlk olarak domatesleri küçük küçük doğrayın ve karıştırma kabına alın.
Daha sonra soğanı da küçük küçük doğrayın ve üzerine tuz serpip elinizle güzelce ovun.
İnce ince doğradığımız yeşil biber ve küçük küçük doğradığımız salatalığımızı da karıştırma kabına alalım.
Son olarak maydanozu da ince ince doğrayalım ve doğradığımız diğer malzemelerimizin üzerine ekleyelim.
Salatamızın zeytin yağını ve limon suyunu da ekledikten sonra güzelce harmanlayalım ve servis tabağına alarak servis edelim. ', N'Salata, genellikle sebze veya meyvelerden oluşan sade karışım ya da üzerine yoğurt ya da sos dökülmesiyle hazırlanan ve yemeklere eşlik eden yiyecek karışımı. Kimi zaman içine et ya da peynir gibi yiyecekler de konulur. Mevsimine ve yapıldığı yöreye özgü sayısız çeşidi yapılır.', N'4 adet domates
1 adet soğan
1 çay kaşığı tuz
2 adet yeşil biber
1 adet salatalık
Maydanoz
Limon suyu
Zeytinyağı', N'coban_salatasi.jpg', 16)
SET IDENTITY_INSERT [dbo].[Foods] OFF
GO
SET IDENTITY_INSERT [dbo].[Nutrients] ON 

INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (1, N'Pirinc', N'Tahillar', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (2, N'Bugday', N'Tahillar', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (3, N'Yulaf', N'Tahillar', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (4, N'Bulgur', N'Tahillar', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (5, N'Arpa', N'Tahillar', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (6, N'Cavdar', N'Tahillar', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (7, N'Dinkel', N'Tahillar', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (8, N'Kavılca', N'Tahillar', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (9, N'Misir', N'Tahillar', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (10, N'Kara bugday', N'Tahillar', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (11, N'Siyez', N'Tahillar', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (12, N'Pirinc Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (13, N'Yulaf Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (14, N'Siyez Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (15, N'Kavılca Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (16, N'Kızıl Buğday Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (17, N'Çavdar Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (18, N'Arpa Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (19, N'Dinkel Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (20, N'Karakılçık Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (21, N'Sarı Buğday Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (22, N'Kırmızı Buğday Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (23, N'Kirik Buğday Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (24, N'Menekşe Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (25, N'Kunduru Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (26, N'Uveyik Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (27, N'Bugday Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (28, N'Mısır Unu', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (29, N'Bakla', N'Tahıl Unları', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (30, N'Soya fasulyesi', N'Baklagiller', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (31, N'Börülce', N'Baklagiller', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (32, N'Fasulye', N'Baklagiller', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (33, N'Kirmizi fasulye', N'Baklagiller', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (34, N'Yeşil Mercimek', N'Baklagiller', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (35, N'Sarı Mercimek', N'Baklagiller', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (36, N'Nohut', N'Baklagiller', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (37, N'Kuru fasulye', N'Baklagiller', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (38, N'Kırmızı Mercimek', N'Baklagiller', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (39, N'Soya sutu', N'Tahıl Sutleri', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (40, N'Pirinc sutu', N'Tahıl Sutleri', 1, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (41, N'Patates', N'Patates', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (42, N'Kırmızı tatli patates', N'Patates', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (43, N'Mor Patates', N'Patates', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (44, N'Hint yer elmasi', N'Patates', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (45, N'Konjac(japon)', N'Patates', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (46, N'Sarı Bamba Patates', N'Patates', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (47, N'Durabo Patates', N'Patates', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (48, N'Lady Rosetta Patates', N'Patates', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (49, N'Beyaz Fianna Patates', N'Patates', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (50, N'Nigde Patatesi', N'Patates', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (51, N'Seker pancari', N'Seker kaynaklari', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (52, N'Seker kamisi', N'Seker kaynaklari', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (53, N'Hurma Agacı', N'Seker kaynaklari', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (54, N'Japon yabani turp koku', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (55, N'Japon yabani turp yapraklari', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (56, N'Turp koku', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (57, N'Turp yapraklari', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (58, N'Yaban turpu/Siyah turp', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (59, N'Tere', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (60, N'Cin lahanasi', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (61, N'Lahana', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (62, N'Buruksel lahanasi', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (63, N'Kivircik lahana', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (64, N'Komatsuna(Japon)', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (65, N'Kyona(Japon)', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (66, N'Qing-geng-cai(Japon)', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (67, N'Karnabahar', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (68, N'Brokoli', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (69, N'Diger Turpgiller', N'Turpgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (70, N'Dulavrat otu', N'Kompozit sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (71, N'Tekesakali', N'Kompozit sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (72, N'Enginar', N'Kompozit sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (73, N'Radika/Hindiba otu/Frenk salatasi', N'Kompozit sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (74, N'Shungiku(Asya)', N'Kompozit sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (75, N'Marul', N'Kompozit sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (76, N'Diger kompozit sebzeler', N'Kompozit sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (77, N'Sogan', N'Zambakgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (78, N'Galler sogani/gal sogani', N'Zambakgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (79, N'Nira(Cin/Japon/Kore)', N'Zambakgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (80, N'Sarimsak', N'Zambakgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (81, N'Kuskonmaz', N'Zambakgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (82, N'Arpacik sogan/Taze sogan', N'Zambakgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (83, N'Diger zambakgiller', N'Zambakgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (84, N'Havuc', N'Semsiye bicimindeki sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (85, N'Yabani havuc', N'Semsiye bicimindeki sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (86, N'Dereotu', N'Semsiye bicimindeki sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (87, N'Maydanoz', N'Semsiye bicimindeki sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (88, N'Kereviz', N'Semsiye bicimindeki sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (89, N'Mitsuba(Japon)', N'Semsiye bicimindeki sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (90, N'Domates', N'Patlicangiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (91, N'Sarimsak', N'Patlicangiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (92, N'Patlican', N'Patlicangiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (93, N'Salatalik', N'Kabakgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (94, N'Balkabagi', N'Kabakgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (95, N'Kavun', N'Kabakgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (96, N'Karpuz', N'Kabakgiller', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (97, N'Bezelye', N'Baklagil sebzeleri', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (98, N'Barbunya', N'Baklagil sebzeleri', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (99, N'Yesil soya fasulyesi', N'Baklagil sebzeleri', 2, 1)
GO
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (100, N'Kultur mantari', N'Mantarlar', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (101, N'Istiridye mantari', N'Mantarlar', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (102, N'Trüf mantari', N'Mantarlar', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (103, N'Kanlıca mantari', N'Mantarlar', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (104, N'Ispanak', N'Karisik/Cok yonlu sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (105, N'Bamya', N'Karisik/Cok yonlu sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (106, N'Zencefil', N'Karisik/Cok yonlu sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (107, N'Bambu filizleri', N'Karisik/Cok yonlu sebzeler', 2, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (108, N'Satsuma Mandarini', N'Narenciyeler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (109, N'Citrus Natsudaidai(Japon)', N'Narenciyeler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (110, N'Limon', N'Narenciyeler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (111, N'Portakal', N'Narenciyeler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (112, N'Greyfurt', N'Narenciyeler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (113, N'Misket Limonu', N'Narenciyeler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (114, N'Elma', N'Yumusak cekirdekli meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (115, N'Japon armudu', N'Yumusak cekirdekli meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (116, N'Armut', N'Yumusak cekirdekli meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (117, N'Ayva', N'Yumusak cekirdekli meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (118, N'Malta erigi', N'Yumusak cekirdekli meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (119, N'Seftali', N'Sert cekirdekli meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (120, N'Nektarin', N'Sert cekirdekli meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (121, N'Kayisi', N'Sert cekirdekli meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (122, N'Japon erigi', N'Sert cekirdekli meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (123, N'Erik', N'Sert cekirdekli meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (124, N'Kiraz', N'Sert cekirdekli meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (125, N'Visne', N'Sert cekirdekli meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (126, N'Cilek', N'Etli ve zarli kabuksuz meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (127, N'Ahududu', N'Etli ve zarli kabuksuz meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (128, N'Yaban mersini', N'Etli ve zarli kabuksuz meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (129, N'Bogurtlen', N'Etli ve zarli kabuksuz meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (130, N'Kizilcik', N'Etli ve zarli kabuksuz meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (131, N'Uzum', N'Uzumler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (132, N'Japon hurmasi', N'Tropikal Meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (133, N'Hurma', N'Tropikal Meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (134, N'Muz', N'Tropikal Meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (135, N'Kivi', N'Tropikal Meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (136, N'Papaya/Kavunagaci meyvesi', N'Tropikal Meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (137, N'Avokado', N'Tropikal Meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (138, N'Ananas', N'Tropikal Meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (139, N'Guava', N'Tropikal Meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (140, N'Mango', N'Tropikal Meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (141, N'Carkifelek meyvesi', N'Tropikal Meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (142, N'Hindistan cevizi', N'Tropikal Meyveler', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (143, N'Zeytin', N'Zeytingiller', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (144, N'Zeytinyagi', N'Meyve Yagları', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (145, N'Hindistan cevizi yagi', N'Meyve Yagları', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (146, N'Üzüm Sirkesi', N'Meyve Sirkeleri', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (147, N'Elma Sirkesi', N'Meyve Sirkeleri', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (148, N'Hindistan cevizi sutu', N'Meyve Sutleri', 3, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (149, N'Aycicegi tohumu', N'Yagli tohumlar', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (150, N'Susam tohumu', N'Yagli tohumlar', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (151, N'Aspir tohumu', N'Yagli tohumlar', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (152, N'Pamuk tohumu', N'Yagli tohumlar', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (153, N'Kolza tohumu', N'Yagli tohumlar', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (154, N'Diger yagli tohumlar', N'Yagli tohumlar', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (155, N'Gingko', N'Yagli tohumlar', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (156, N'Findik', N'Yagli tohumlar', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (157, N'Pekan cevizi', N'Yagli tohumlar', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (158, N'Badem', N'Yagli tohumlar', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (159, N'Ceviz', N'Yagli tohumlar', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (160, N'Kahve', N'Icecek tohumlari', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (161, N'Kakao', N'Icecek tohumlari', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (162, N'Aycicegi yagi', N'Tohum Yagları', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (163, N'Susam yagi', N'Tohum Yagları', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (164, N'Findik yagi', N'Tohum Yagları', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (165, N'Badem yagi', N'Tohum Yagları', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (166, N'Badem sutu', N'Tohum Sutleri', 4, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (167, N'Karabiber', N'Baharatlar', 5, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (168, N'Kirmizi biber', N'Baharatlar', 5, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (169, N'Nane', N'Otlar', 5, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (171, N'Cay(yesil,siyah,oolong,wulung)', N'Caylar', 6, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (172, N'Fermante caylar(siyah,oolong,wulung)', N'Caylar', 6, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (173, N'Serbetciotu', N'Hop', 7, 1)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (174, N'Sigir Eti', N'Et', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (175, N'Domuz Eti', N'Et', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (176, N'Koyun Eti', N'Et', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (177, N'At Eti', N'Et', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (178, N'Geyik Eti', N'Et', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (179, N'Keci Eti', N'Et', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (180, N'Dana Eti', N'Et', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (181, N'Kuzu Eti', N'Et', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (182, N'Dana Cigeri', N'Sakatat', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (183, N'Kuzu Cigeri', N'Sakatat', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (184, N'Dana Bobregi', N'Sakatat', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (185, N'Kuzu Böbregi', N'Sakatat', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (186, N'Inek Sutu', N'Sut', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (187, N'Koyun Sutu', N'Sut', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (188, N'Kecı Sutu', N'Sut', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (189, N'Peynir', N'Sut Urunleri', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (190, N'Tereyagi', N'Sut Urunleri', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (191, N'Yogurt', N'Sut Urunleri', 8, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (192, N'Tavuk', N'Et', 9, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (193, N'Ordek', N'Et', 9, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (194, N'Hindi', N'Et', 9, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (195, N'Kaz', N'Et', 9, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (196, N'Kaz Cigeri', N'Ciger', 9, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (197, N'Tavuk Yumurtası', N'Yumurta', 9, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (198, N'Diğer Yumurtalar', N'Yumurta', 9, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (199, N'Som baliklari(Alabaliklar,somonlar)', N'Balik', 10, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (200, N'Yilan baligi', N'Balik', 10, 2)
GO
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (202, N'Balon baligi', N'Balik', 10, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (203, N'Diger baliklar', N'Balik', 10, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (206, N'Bal', N'Ari urunleri', 11, 2)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (207, N'Sehriye', N'Un + Yumurta', 12, 3)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (208, N'Makarna', N'Un + Yumurta', 12, 3)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (209, N'Eriste', N'Un + Yumurta', 12, 3)
INSERT [dbo].[Nutrients] ([ID], [Nutrient_Name], [Group_Of_Nutrient], [TON_ID], [OON_ID]) VALUES (210, N'Tarhana', N'Un+Sebze+Yogurt', 13, 3)
SET IDENTITY_INSERT [dbo].[Nutrients] OFF
GO
SET IDENTITY_INSERT [dbo].[Origin_Of_Nutrient] ON 

INSERT [dbo].[Origin_Of_Nutrient] ([ID], [Origin]) VALUES (1, N'bitki')
INSERT [dbo].[Origin_Of_Nutrient] ([ID], [Origin]) VALUES (2, N'hayvan')
INSERT [dbo].[Origin_Of_Nutrient] ([ID], [Origin]) VALUES (3, N'bitki ve hayvan')
SET IDENTITY_INSERT [dbo].[Origin_Of_Nutrient] OFF
GO
SET IDENTITY_INSERT [dbo].[Type_Of_Nutrient] ON 

INSERT [dbo].[Type_Of_Nutrient] ([ID], [Types]) VALUES (1, N'Tahillar/Kuru Baklagiller/Baklagiller')
INSERT [dbo].[Type_Of_Nutrient] ([ID], [Types]) VALUES (2, N'Sebzeler')
INSERT [dbo].[Type_Of_Nutrient] ([ID], [Types]) VALUES (3, N'Meyveler')
INSERT [dbo].[Type_Of_Nutrient] ([ID], [Types]) VALUES (4, N'Sert Kabuklu yemisler ve tohumlar')
INSERT [dbo].[Type_Of_Nutrient] ([ID], [Types]) VALUES (5, N'Baharatlar ve otlar')
INSERT [dbo].[Type_Of_Nutrient] ([ID], [Types]) VALUES (6, N'Caylar')
INSERT [dbo].[Type_Of_Nutrient] ([ID], [Types]) VALUES (7, N'Hop')
INSERT [dbo].[Type_Of_Nutrient] ([ID], [Types]) VALUES (8, N'Karada yasayan hayvanlar')
INSERT [dbo].[Type_Of_Nutrient] ([ID], [Types]) VALUES (9, N'Kumes Hayvanlari')
INSERT [dbo].[Type_Of_Nutrient] ([ID], [Types]) VALUES (10, N'Suda Yasayan Hayvanlar')
INSERT [dbo].[Type_Of_Nutrient] ([ID], [Types]) VALUES (11, N'Ari urunleri')
INSERT [dbo].[Type_Of_Nutrient] ([ID], [Types]) VALUES (12, N'Un + Yumurta')
INSERT [dbo].[Type_Of_Nutrient] ([ID], [Types]) VALUES (13, N'Un+Sebze+Yogurt')
SET IDENTITY_INSERT [dbo].[Type_Of_Nutrient] OFF
GO
SET IDENTITY_INSERT [dbo].[User_Information] ON 

INSERT [dbo].[User_Information] ([ID], [Name], [Surname], [Password], [Mail], [UserName], [Age], [CardID], [Port]) VALUES (1, N'Ufuk', N'Barut', N'123', N'abcd@gmail.com', N'UBarut', 28, 1, 1903)
INSERT [dbo].[User_Information] ([ID], [Name], [Surname], [Password], [Mail], [UserName], [Age], [CardID], [Port]) VALUES (2, N'Emre', N'Ergüven', N'123', N'emrekaya@gmail.com', N'EErgüven', 29, 2, 5758)
SET IDENTITY_INSERT [dbo].[User_Information] OFF
GO
ALTER TABLE [dbo].[Foods]  WITH CHECK ADD  CONSTRAINT [FK_Foods_Category_Of_Food] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category_Of_Food] ([ID])
GO
ALTER TABLE [dbo].[Foods] CHECK CONSTRAINT [FK_Foods_Category_Of_Food]
GO
ALTER TABLE [dbo].[Nutrients]  WITH CHECK ADD  CONSTRAINT [FK_Nutrients_Origin_Of_Nutrient] FOREIGN KEY([OON_ID])
REFERENCES [dbo].[Origin_Of_Nutrient] ([ID])
GO
ALTER TABLE [dbo].[Nutrients] CHECK CONSTRAINT [FK_Nutrients_Origin_Of_Nutrient]
GO
ALTER TABLE [dbo].[Nutrients]  WITH CHECK ADD  CONSTRAINT [FK_Nutrients_Type_Of_Nutrient] FOREIGN KEY([TON_ID])
REFERENCES [dbo].[Type_Of_Nutrient] ([ID])
GO
ALTER TABLE [dbo].[Nutrients] CHECK CONSTRAINT [FK_Nutrients_Type_Of_Nutrient]
GO
/****** Object:  StoredProcedure [dbo].[AccessNutrients]    Script Date: 6.02.2022 19:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[AccessNutrients]
@id int
as
declare @ingredient nvarchar(200)
select @ingredient=Ingredients from Foods where ID=2;	
/*print @ingredient*/
begin
	select Nutrient_Name from Nutrients Where ID in (select * from string_split(@ingredient,','));
end
GO
/****** Object:  StoredProcedure [dbo].[AddFavorite]    Script Date: 6.02.2022 19:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddFavorite]
@userid int,
@foodid int
as
begin
	insert into Favorites(UserID, Favorite_FoodID)
		values(@userid, @foodid)
end
GO
/****** Object:  StoredProcedure [dbo].[AddViews]    Script Date: 6.02.2022 19:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AddViews]
@id int
as
begin
declare @totalView int
	select @totalView=Total_Views from Foods where ID=@id
	update Foods set Total_Views=@totalView+1 where ID=@id
end
GO
/****** Object:  StoredProcedure [dbo].[RemoveFavorite]    Script Date: 6.02.2022 19:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RemoveFavorite]
@userid int,
@foodid int
as
begin
	delete from Favorites where UserID=@userid and Favorite_FoodID=@foodid
end
GO
/****** Object:  StoredProcedure [dbo].[SelectCategory]    Script Date: 6.02.2022 19:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectCategory]
@categoryID int
as
begin
declare @select nvarchar(100)
	return select f.Food from Foods as f inner join Category_Of_Food as c on(f.CategoryID=c.ID) where c.ID=@categoryID;
end
GO
/****** Object:  StoredProcedure [dbo].[UserAdd]    Script Date: 6.02.2022 19:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserAdd]
@name nvarchar(50),
@surname nvarchar(50),
@password nvarchar(50),
@mail nvarchar(50),
@username nvarchar(50),
@age tinyint,
@port int
as
begin
	insert into User_Information(Name,Surname,Password,Mail,UserName,Age,Port)
		values(@name,@surname,@password,@mail,@username,@age,@port)
end
GO
USE [master]
GO
ALTER DATABASE [CepteSefdb] SET  READ_WRITE 
GO
