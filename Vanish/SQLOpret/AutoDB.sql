use master
if exists(select * from sys.databases where name = 'AutoDB')
begin
	print 'Databasen AutoDB er der i forvejen - drop den'
	drop database AutoDB
end
else
begin
	Print 'Databasen er der ikke'
end
go
print 'Opretter databaseb AutoDB'
create database AutoDB
go
use AutoDB
go
create table postnrby
(
	postnr int primary key check(postnr > 999 AND postnr < 10000),
	bynavn varchar(100) not null
)
create table Kunde
(
	kundeID int identity(1,1) primary key,
	fornavn nvarchar(50) not null,
	efternavn nvarchar(50) not null,
	vejnavn nvarchar(40) not null,
	husnr int not null check(husnr >= 1),
	postnr int not null foreign key references postnrby (postnr),
	mobil varchar(12) default 'Ingen mobil',
	email varchar(255) default 'Ingen Email',
	[type] int check([type] >= 0 AND [type] <= 1), -- type her  Privat/Buissnes
	[status] int check([status] >= 0 AND [status] <= 2)

)
create table Bil
(
	regNR nvarchar(7) not null,
	maerke nvarchar(50) not null,
	model nvarchar(50) not null,
	aargang int not null check(aargang > 1900),
	km int not null check(km >= 0),
	kundeID int foreign key references kunde (kundeID)
)
go

-- opretter lige nogle test data
-- senere skal data BCP loades....

insert into Postnrby values (3660,'Stenløse'),
							(3650,'Ølstykke'),
							(2900,'Hellerup'),
							(4000,'Roskilde'), -- indlæser senere alle fra ekstern fil
							(3000,'Helsingør'),
							(3400,'Hillerød'),
							(5000,'Odense'),
							(2300,'Islands Brygge')
go
insert into Kunde values ('Hans','Knudsen','Nissevejen',15,3660,default,default,0,0),
						('Linda','Petersen','Sydhavnen 1 th',23,2900,'+4512345678','Linda@snotdum.dk',1,1),
						('Birgit','Nissen','Æblehaven',21,3650,'+4522334455','BN@SNASK,dk',1,1),
						('Niels','Lattermild','Bromlevej',14,3000,'+4529495969','NiLa@torsk.dk',0,1),
						('Fisan','Lügther','Ægirsgade',12,4000,'+4621345678',default,1,0),
						('Linse','Kessler','Tits',6,2300,'+4577665544','lk@plastictits.dk',1,1),
						('Gustav','Salinas','Bøsserup Strandvej',6,5000,'+4620204040','GuSa@diller.dk',0,0),
						('Amalie','Zigherty','Nullerstrædet',1,5000,'+4566332244','AmZi@nobrains.dk',1,1)
go
insert into Bil values ('XY19222','WV','Polo',2018,0,1),
						('NY39848','Toyota','Corolla',1976,0,2),
						('GL33445','Volvo','945',1999,200000,3),
						('FÆ23986','Nissan','Patrol',2017,150000,4),
						('BÆ20499','BMW','323i',2016,15500,5),
						('AMALIE','Tesla','D85',2018,0,8),
						('GG12399','WV','Up',2016,120000,7),
						('KK12004','Opel','Astra',2015,10000,5)

go


select * from postnrby
select * from Kunde
select * from Bil