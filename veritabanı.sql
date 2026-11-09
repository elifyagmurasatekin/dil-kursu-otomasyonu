CREATE TABLE [dbo].[KursTbl] (
    [KursId]   INT            IDENTITY (1, 1) NOT NULL,
    [KursAdi]  VARCHAR (50)   NOT NULL,
    [KursSaat] VARCHAR (50)   NOT NULL,
    [Aciklama] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([KursId] ASC)
);

CREATE TABLE [dbo].[OgrenciTbl] (
    [OgrenciId] INT           IDENTITY (1, 1) NOT NULL,
    [AdSoyad]   VARCHAR (50)  NOT NULL,
    [Telefon]   VARCHAR (50)  NOT NULL,
    [DogumTrh]  VARCHAR (50)  NOT NULL,
    [Cinsiyet]  VARCHAR (6)   NOT NULL,
    [Resim]     VARCHAR (500) NOT NULL,
    [Adres]     VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([OgrenciId] ASC)
);

CREATE TABLE [dbo].[PuanTbl] (
    [PuanId]    INT          IDENTITY (1, 1) NOT NULL,
    [OgrenciId] INT          NOT NULL,
    [Puan]      VARCHAR (50) NOT NULL,
    [Kurs]      VARCHAR (50) NOT NULL,
    [Aciklama]  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([PuanId] ASC)
);

