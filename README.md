# Axos Payment App
Microserice

# Getting started
## Copy the database scripts below
			      USE [DB_PAYMENTS]
GO
/****** Object:  Table [dbo].[CURRENCY]    Script Date: 29/01/2023 01:35:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CURRENCY](
	[CurrencyId] [int] IDENTITY(1,1) NOT NULL,
	[Nationality] [varchar](100) NOT NULL,
	[shorthand] [char](3) NOT NULL,
 CONSTRAINT [PK_CURRENCY_ID] PRIMARY KEY CLUSTERED 
(
	[CurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAYMENT]    Script Date: 29/01/2023 01:35:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAYMENT](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Amount] [decimal](12, 8) NULL,
	[CurrencyId] [int] NULL,
	[Comments] [varchar](255) NULL,
	[PaymentStatus] [bit] NOT NULL,
	[RecordingDate] [datetime] NOT NULL,
	[UpdatingDate] [datetime] NULL,
	[DeleteingDate] [datetime] NULL,
 CONSTRAINT [PK_BILLING_ID] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SUPPLIER]    Script Date: 29/01/2023 01:35:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SUPPLIER](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [varchar](100) NOT NULL,
	[RecordingDate] [datetime] NOT NULL,
	[UpdatingDate] [datetime] NULL,
	[DeleteingDate] [datetime] NULL,
 CONSTRAINT [PK_SUPPLIER_ID] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER]    Script Date: 29/01/2023 01:35:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[RecordingDate] [datetime] NOT NULL,
	[UpdatingDate] [datetime] NULL,
	[DeleteingDate] [datetime] NULL,
 CONSTRAINT [PK_USER_ID] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PAYMENT]  WITH CHECK ADD  CONSTRAINT [FK_CURRENCY_ID] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[CURRENCY] ([CurrencyId])
GO
ALTER TABLE [dbo].[PAYMENT] CHECK CONSTRAINT [FK_CURRENCY_ID]
GO
ALTER TABLE [dbo].[PAYMENT]  WITH CHECK ADD  CONSTRAINT [FK_SUPPLIER_ID] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[SUPPLIER] ([SupplierId])
GO
ALTER TABLE [dbo].[PAYMENT] CHECK CONSTRAINT [FK_SUPPLIER_ID]
GO
ALTER TABLE [dbo].[PAYMENT]  WITH CHECK ADD  CONSTRAINT [FK_USER_ID] FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[PAYMENT] CHECK CONSTRAINT [FK_USER_ID]
GO
/****** Object:  StoredProcedure [dbo].[spAuth]    Script Date: 29/01/2023 01:35:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spAuth](

	 @Password       VARCHAR(50)       = NULL,
	 @Email          VARCHAR(50)       = NULL

)
AS 
BEGIN
	
	SELECT UserId, Email, RecordingDate FROM [USER] WHERE Email = @Email AND Password = @Password

END
GO
/****** Object:  StoredProcedure [dbo].[spCatalogs]    Script Date: 29/01/2023 01:35:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spCatalogs](
	@Accion INT = NULL
)
AS
BEGIN	
	IF @Accion =  1
	BEGIN	
		SELECT * FROM [SUPPLIER]
	END

	IF @Accion =  2
	BEGIN	
		SELECT * FROM [CURRENCY]
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spPayments]    Script Date: 29/01/2023 01:35:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spPayments](

     @Accion     INT            = NULL,
     @PaymentId  INT            = NULL,
	 @SupplierId INT            = NULL,
	 @UserId     INT			= NULL,
	 @Amount     DECIMAL(12,8)  = NULL,
	 @CurrencyId INT            = NULL,
	 @Comments   VARCHAR(255)   = NULL,

	 --FILTERS
	 @Email VARCHAR(50) =  NULL

)
AS 
BEGIN
	IF @Accion = 1 --VIEW RECORDS
	BEGIN

		SELECT
			PY.PaymentId, 
			SP.SupplierName, 
			US.Email, 
			PY.Amount,
			CR.shorthand AS Currency
		FROM PAYMENT PY
		INNER JOIN [SUPPLIER] SP ON PY.SupplierId = SP.SupplierId
		INNER JOIN [USER] US ON PY.UserId = US.UserId
		INNER JOIN [CURRENCY] CR ON PY.CurrencyId = CR.CurrencyId
		WHERE
			  (PY.PaymentId = @PaymentId OR @PaymentId IS NULL) AND
			  (SP.SupplierId = @SupplierId OR @SupplierId IS NULL) AND
		      (US.Email LIKE CONCAT('%',@Email,'%') OR @Email IS NULL) AND
			  (PY.PaymentStatus = 1 )
			   
	END

	IF @Accion = 2
	BEGIN
		INSERT INTO PAYMENT (SupplierId,UserId, Amount, CurrencyId,Comments, PaymentStatus, RecordingDate)
		OUTPUT inserted.PaymentId
		VALUES(@SupplierId,@UserId, @Amount, @CurrencyId, @Comments, 1, GETDATE())	
	END			
	
	IF @Accion = 3
	BEGIN
		UPDATE PAYMENT
		SET SupplierId = @SupplierId,
		    UserId = @UserId,
			Amount = @Amount,
			CurrencyId = @CurrencyId,
			Comments = @Comments,
			UpdatingDate = GETDATE()
		WHERE PaymentId = @PaymentId
	END			

	IF @Accion = 4
	BEGIN
		UPDATE PAYMENT
		SET PaymentStatus = 0,
			DeleteingDate = GETDATE()
		WHERE PaymentId = @PaymentId
	END			

	IF @Accion = 5
	BEGIN
		SELECT * FROM PAYMENT WHERE PaymentId = @PaymentId
	END


END											      
											    
											    
GO

									
# Switch the connection strings in appSettings file
## Current string
 ![image](https://user-images.githubusercontent.com/52724854/215151809-1a39cae3-6737-4089-bad2-af1e1436b9ab.png)

                  
                  
                  
											    
