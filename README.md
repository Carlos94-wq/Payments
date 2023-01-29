# Axos Payment App
Microserice

# Getting started
## Copy the database scripts below
USE master
GO

--DROP DATABASE DB_PAYMENTS
 
CREATE DATABASE DB_PAYMENTS
GO

USE DB_PAYMENTS
GO

CREATE TABLE [dbo].[USER](

	 UserId         INT IDENTITY(1,1) NOT NULL,
	 Email          VARCHAR(50)       NOT NULL,
	 Password       VARCHAR(50)       NOT NULL,
			    			      
	 RecordingDate  DATETIME          NOT NULL,
	 UpdatingDate   DATETIME          NULL,
	 DeleteingDate  DATETIME	      NULL,

	 CONSTRAINT PK_USER_ID PRIMARY KEY(UserId)

)
GO

CREATE TABLE [dbo].[SUPPLIER](
	
	 SupplierId     INT IDENTITY(1,1) NOT NULL,
	 SupplierName   VARCHAR(100)    NOT NULL,

	 RecordingDate  DATETIME      NOT NULL,
	 UpdatingDate   DATETIME      NULL,
	 DeleteingDate  DATETIME	  NULL,

	CONSTRAINT PK_SUPPLIER_ID PRIMARY KEY(SupplierId)
)
GO

CREATE TABLE [dbo].[CURRENCY](
	
	 CurrencyId     INT IDENTITY(1,1) NOT NULL,
	 Nationality    VARCHAR(100)      NOT NULL,
	 shorthand      CHAR(3)           NOT NULL,


	CONSTRAINT PK_CURRENCY_ID PRIMARY KEY(CurrencyId)
)
GO

CREATE TABLE [dbo].[PAYMENT](

	 PaymentId      INT IDENTITY(1,1) NOT NULL,
	 SupplierId     INT               NOT NULL,
	 UserId         INT				  NOT NULL,
	 Amount         DECIMAL(12,8)     NULL,
	 CurrencyId     INT               NULL,
	 Comments       VARCHAR(255)      NULL,
	 PaymentStatus  BIT               NOT NULL,

	
	 RecordingDate  DATETIME          NOT NULL,
	 UpdatingDate   DATETIME          NULL,
	 DeleteingDate  DATETIME	      NULL,

	 CONSTRAINT PK_BILLING_ID  PRIMARY KEY (PaymentId),
	 CONSTRAINT FK_SUPPLIER_ID FOREIGN KEY (SupplierId) REFERENCES [SUPPLIER] (SupplierId),
	 CONSTRAINT FK_USER_ID     FOREIGN KEY (UserId)     REFERENCES [USER]     (UserId),
	 CONSTRAINT FK_CURRENCY_ID FOREIGN KEY (CurrencyId) REFERENCES [CURRENCY] (CurrencyId)
)
GO


INSERT INTO [SUPPLIER] (SupplierName, RecordingDate) VALUES('Dummy Supplier', GETDATE()), ('Dunder Mifflin', GETDATE()), ('Michael Scott Paper Company', GETDATE())
INSERT INTO [USER] (Email, Password, RecordingDate) VALUES ('email@dummy.com', '123', GETDATE())
INSERT INTO [USER] (Email, Password, RecordingDate)
VALUES
  ('sit.amet.ante@yahoo.net','DOB67KDR3MH','2023-06-10'),
  ('et.eros@outlook.ca','WUO78IXS0AM','2023-05-26'),
  ('mus.proin.vel@protonmail.net','MTZ21EIZ6HM','2018-01-26'),
  ('in.sodales.elit@yahoo.edu','LIL47WEN1AX','2021-07-25'),
  ('lorem.auctor@outlook.couk','DIS25BXU1UH','2012-07-14'),
  ('mi@icloud.edu','JEI71ZQU0CH','2010-01-07'),
  ('sit.amet@hotmail.edu','PUU55OPK3XB','2009-11-16'),
  ('eleifend.non.dapibus@aol.net','MRH42XRS8YF','2011-08-04'),
  ('parturient.montes@icloud.ca','DXE03BHX6RJ','2010-10-25'),
  ('in.cursus.et@outlook.edu','YFD70QIZ6VN','2017-12-13');


INSERT INTO [CURRENCY] VALUES ('United States dollar', 'USD' ),
                              ('Mexican peso', 'MXN' ),
							  ('Euro', 'EUR' )

INSERT INTO [PAYMENT] (SupplierId,UserId,Amount,CurrencyId,PaymentStatus,RecordingDate,UpdatingDate)
VALUES
  (2, 10, 26.97, 1, 1,'2012-07-17',NULL),
  (3, 4,  37.83, 3, 1,'2016-04-28','2019-06-23'),
  (2, 6,  14.83, 1, 0,'2022-08-27','2012-11-15'),
  (2, 2,  69.96, 3, 0,'2005-07-01',NULL),
  (1, 3,  86.98, 2, 0,'2007-04-05','2003-04-02'),
  (1, 4,  55.85, 3, 1,'2022-08-02','2008-09-19'),
  (2, 9,  15.14, 3, 0,'2008-05-04', NULL),
  (2, 2,  79.59, 2, 0,'2014-07-04','2011-01-30'),
  (1, 7,  77.74, 2, 0,'2017-02-06','2021-04-15'),
  (1, 1,  91.35, 3, 1,'2010-01-26','2022-12-29');


 INSERT INTO [PAYMENT] (SupplierId,UserId,Amount,CurrencyId,PaymentStatus,RecordingDate,UpdatingDate)
VALUES
  (2,2, 82.30,3,0,'2015-07-26','2007-12-17'),
  (2,1, 4.49,2,1,'2016-04-16','2013-09-06'),
  (1,4, 89.94,2,1,'2021-03-23','2021-03-28'),
  (1,3, 86.06,2,1,'2005-02-13','2015-12-16'),
  (1,11,48.69,2,0,'2016-06-26','2020-02-19'),
  (3,2, 37.52,2,0,'2003-12-19','2003-10-04'),
  (1,10,2.08,3,1,'2004-03-08','2016-08-18'),
  (1,7, 72.20,2,1,'2007-08-02','2018-05-30'),
  (2,9, 74.82,3,1,'2009-10-06','2013-05-16'),
  (3,11,51.60,2,0,'2023-08-14','2009-09-15');
INSERT INTO [PAYMENT] (SupplierId,UserId,Amount,CurrencyId,PaymentStatus,RecordingDate,UpdatingDate)
VALUES
  (2,2, 0.80,2,1,'2018-02-04','2023-10-01'),
  (2,2, 22.75,2,0,'2007-09-27','2012-03-25'),
  (2,1, 73.28,2,1,'2005-11-27','2011-06-21'),
  (3,7, 93.59,1,1,'2011-09-19','2004-07-22'),
  (2,8, 20.98,1,1,'2019-09-19','2015-05-29'),
  (2,6, 18.72,1,1,'2011-02-20','2008-07-21'),
  (1,7, 6.05,2,0,'2015-09-29','2022-05-25'),
  (2,6, 11.47,2,0,'2008-06-15','2016-03-27'),
  (3,4, 29.65,1,0,'2010-07-27','2021-10-21'),
  (2,4, 7.37,3,1,'2005-06-02','2022-08-26');
INSERT INTO [PAYMENT] (SupplierId,UserId,Amount,CurrencyId,PaymentStatus,RecordingDate,UpdatingDate)
VALUES
  (3,5, 64.49,1,1,'2021-12-01','2015-05-06'),
  (1,3, 86.65,2,1,'2007-12-16','2019-01-17'),
  (2,2, 49.15,2,0,'2016-12-26','2011-11-28'),
  (2,8, 30.13,1,1,'2022-01-01','2021-07-26'),
  (2,4, 78.45,2,1,'2016-12-21','2013-10-03'),
  (2,10,66.64,3,1,'2008-01-18','2003-02-05'),
  (2,5, 45.24,2,0,'2022-04-19','2007-12-16'),
  (1,1, 8.25,3,1,'2003-09-16','2020-05-16'),
  (2,8, 35.90,1,0,'2022-05-31','2021-08-14'),
  (1,5, 11.31,2,1,'2009-11-21','2013-09-26');

INSERT INTO [PAYMENT] (SupplierId,UserId,Amount,CurrencyId,PaymentStatus,RecordingDate,UpdatingDate)
VALUES
  (2,10,58.65,3,0,'2014-07-09','2015-05-15'),
  (2,3, 1.24,2,0,'2019-12-18','2010-01-08'),
  (2,5, 56.65,1,0,'2014-10-03','2020-12-11'),
  (2,2, 53.99,1,0,'2015-02-12','2008-12-09'),
  (2,4, 28.88,1,0,'2005-05-25','2017-06-25'),
  (2,4, 26.03,3,1,'2015-04-06','2019-03-09'),
  (1,10,74.14,2,1,'2008-09-05','2014-02-10'),
  (2,8, 11.73,3,0,'2007-06-28','2008-08-18'),
  (2,3, 81.09,1,1,'2019-07-06','2020-04-03'),
  (2,2, 83.39,2,0,'2023-11-07','2006-05-12');


INSERT INTO [PAYMENT] (SupplierId,UserId,Amount,CurrencyId,PaymentStatus,RecordingDate,UpdatingDate)
VALUES
  (2,11,45.57,1,0,'2003-12-31','2008-04-07'),
  (2,1, 44.63,3,0,'2015-05-05','2011-08-07'),
  (2,8, 92.35,1,0,'2017-07-17','2005-10-28'),
  (2,6, 79.40,2,1,'2021-12-26','2011-03-01'),
  (2,6, 96.95,2,0,'2021-03-24','2022-12-03'),
  (2,8, 9.48,3,0,'2014-09-03','2021-09-22'),
  (1,7, 37.39,2,1,'2007-02-18','2021-05-25'),
  (2,8, 72.38,3,1,'2015-12-28','2011-05-25'),
  (1,3, 62.60,1,1,'2017-01-10','2005-09-03'),
  (3,6, 40.40,2,1,'2023-08-12','2015-08-18');

SELECT * FROM [USER]
SELECT * FROM [CURRENCY]
SELECT * FROM [SUPPLIER]
SELECT * FROM [PAYMENT]

--DROP TABLE [CURRENCY]
--DROP TABLE [SUPPLIER]
--DROP TABLE [USER]
--DROP TABLE [PAYMENT]



IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE NAME = 'spCatalogs')
BEGIN
	DROP PROC [dbo].[spCatalogs]
END
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

IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE NAME = 'spAuth')
BEGIN
	DROP PROC [spAuth]
END
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

IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE NAME = 'spPayments')
BEGIN
	DROP PROC spPayments
END
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
			CONCAT(Amount,' ',CR.shorthand) AS Amount 
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
									
# Switch the connection strings in appSettings file
## Current string
 ![image](https://user-images.githubusercontent.com/52724854/215151809-1a39cae3-6737-4089-bad2-af1e1436b9ab.png)

                  
                  
                  
											    
