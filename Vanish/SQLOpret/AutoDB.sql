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
use autoDB
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

insert into postnrby values (3660,'Stenløse'),
							(3650,'Ølstykke'),
							(2900,'Hellerup'),
							(4000,'Roskilde') -- indlæser senere alle fra ekstern fil

go
insert into kunde values ('Hans','Knudsen','Nissevejen',15,3660,default,default,0,0),
						('Linda','Petersen','Sydhavnen 1 th',23,2900,'+4512345678','Linda@snotdum.dk',1,1)
go
insert into bil values ('XY19222','WV','Polo',2018,0,1)
go


