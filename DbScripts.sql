
CREATE DATABASE TESTDB
USE [TESTDB]
GO
---------------------------------------------------------------
Create proc [dbo].[getQuote]
	as
		begin
			select * from Quote ORDER BY Id DESC
		end
GO

-----------------------------------------------------------------

CREATE PROCEDURE [dbo].[SaveQuote]
	-- Add the parameters for the stored procedure here
	@Mode varchar(50),
	@MovementType varchar(100),
	@Incoterm varchar(100),
	@OriginCountry varchar(50),
	@OriginCity varchar(50),
	@DestinationCountry varchar(50),
	@DestinationCity varchar(50),
	@Zip int,
	@PackageType varchar(50),
	@Quantity int,
	@Lenght int,
	@Width int,
	@Height int,
	@UnitHeight varchar(10),
	@Weight int,
	@UnitWeight varchar(10),
	@CargoDescription varchar(200),
	@IsHazardous bit,
	@IsEventCargo bit,
	@IsPersonalGoods bit,
	@Currency varchar(20)

AS
BEGIN
    -- Insert statements for procedure here
	Insert Quote(Mode,MovementType,Incoterm,OriginCountry,OriginCity,DestinationCountry,DestinationCity,Zip,PackageType,Quantity,Lenght,Width,Height,UnitHeight,Weight,UnitWeight,CargoDescription,IsHazardous,
	IsEventCargo,IsPersonalGoods,Currency)
		values  
	(@Mode,@MovementType,@Incoterm,@OriginCountry,@OriginCity,@DestinationCountry,@DestinationCity,@Zip,@PackageType,@Quantity,@Lenght,@Width,@Height,@UnitHeight,@Weight,@UnitWeight,@CargoDescription,@IsHazardous,
	@IsEventCargo,@IsPersonalGoods,@Currency)  
END
GO
--------------------------------------------------
--Delete-----------------------------------------
CREATE proc [dbo].[DeleteQuote]
@Id int
as
begin
Delete from Quote  Where Id=@Id
end
GO

-------------------------------------------------------


exec SaveQuote 'LCL', 'Door to Door', 'Delivered Duty Paid', 'Türkiye', 'Istanbul', 'USA', 'Miami', 2, 'Pallets', 0, 0, 0, 0, 'CM', 0, 'KG','Cargo Service',NULL,0,1,'USD-US DOLLAR'
exec SaveQuote 'Air', 'Port to Door', 'Delivered At Place', 'USA', 'Boston', 'USA', 'Miami', 2, 'Boxes', 4, 5, 6, 7, 'IN', 0, 'KG','Cargo Service',NULL,0,1,'CHINESE-YUAN'

