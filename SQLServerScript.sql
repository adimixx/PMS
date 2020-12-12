use master
go

DECLARE @DatabaseName nvarchar(50)
SET @DatabaseName = N'photog'

DECLARE @SQL varchar(max)

SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
FROM MASTER..SysProcesses
WHERE DBId = DB_ID(@DatabaseName) AND SPId <> @@SPId

--Uncomment this to run it
EXEC(@SQL)

DROP DATABASE IF EXISTS photog
GO

Create Database photog
GO

Use Photog

create table SystemRole (
	id int identity(1,1) primary key,
	name varchar(50) not null unique
);

create table [User] (
	id int identity(1,1) primary key,
	email varchar(50) not null unique,
	password varchar(32) not null,
	name varchar(100),
	dateofbirth datetime,
	phonenumber varchar(12) unique,
	imgprofile varbinary(max),
	isVerified bit not null,
	verifiedKey varchar(max)
);

create table UserSystemRole (
	id int identity(1,1) primary key,
	systemroleid int references SystemRole(id),
	userid int references [User](id),
	Constraint uc_usersystemrole unique (systemroleid, userid)
);

create table StudioRole (
	id int identity(1,1) primary key,
	name varchar(50) not null unique
);

create table Studio (
	id int identity(1,1) primary key,
	name varchar(50) not null,
	uniquename varchar(15) not null unique,
	location varchar(100),
	ImgLogo varbinary(max)
);

create table UserStudio (
	id int identity(1,1) primary key,
	studioid int references studio(id),
	userid int references [User](id),
	studioroleid int references StudioRole(id),
	Constraint uc_userstudio unique (studioid, userid)
);

create table StudioLink (
	id int identity(1,1) primary key,
	name varchar(50) not null,
	address varchar(250) not null,
	studioid int references studio(id)
);

create table Package (
	id int identity(1,1) primary key,
	studioid int references studio(id),
	name varchar(50) not null,
	price decimal(6,2) not null,
	depositprice decimal(3,2) not null,
	details varchar(100)
);

create table JobStatus (
	id int identity(1,1) primary key,
	name varchar(50) not null unique
);

create table Job (
	id int identity(1,1) primary key,
	packageid int references package(id),
	userid int references [user](id),
	jobstatusid int references JobStatus(id),
	DateCreated datetime not null,
	paymentstatus varchar(20) not null
);

create table JobDate (
	id int identity(1,1) primary key,
	jobid int references job(id),
	jobdate datetime not null,
	location varchar(100) not null,
	description varchar(100),
	jobstatusid int references JobStatus(id)
);

create table JobDateUser (
	id int identity(1,1) primary key,
	jobdateid int references jobdate(id),
	userstudioid int references userstudio(id),
	charge decimal(6,2) not null
	Constraint uc_JobDateUser unique (jobdateid, userstudioid)
);

create table Invoice (
	id int identity(1,1) primary key,
	jobid int references job(id),
	invdate datetime not null,
	expirydate datetime not null,
	total decimal(6,2) not null,
	totalunpaid decimal(6,2) not null
);

create table PaymentMethod (
	id int identity(1,1) primary key,
	name varchar(50) not null unique
);

create table [Transaction] (
	id int identity(1,1) primary key,
	transdate datetime not null,
	total decimal(6,2) not null,
	invoiceid int references invoice(id),
	paymentmethodid int references paymentmethod(id),
	reference varchar(100)
);

create table Charges (
	id int identity(1,1) primary key,
	name varchar(50) not null unique
);

create table JobCharges (
	id int identity(1,1) primary key,
	jobid int references job(id),
	chargeid int references charges(id),
	amount decimal(6,2) not null,
	remarks varchar(50)
);

create table UserFeedback (
	id int identity(1,1) primary key,
	jobid int references job(id),
	rate int not null,
	comment varchar(100)
);

INSERT INTO [dbo].[SystemRole]
           ([name])
     VALUES
           ('Admin'),('User')
GO

INSERT INTO [dbo].[StudioRole]
           ([name])
     VALUES
           ('Admin'),
		   ('Staff')
GO

INSERT INTO [dbo].[User]
           ([email]
           ,[password]
           ,[name]
           ,[dateofbirth]
           ,[phonenumber]
           ,[isVerified])
     VALUES
           ('admin'
           ,'admin'
           ,'Admin System'
           ,'08/07/1999'
           ,'0185759971'
           ,1)
GO

INSERT INTO [dbo].[UserSystemRole]
           ([systemroleid]
           ,[userid])
     VALUES
           (1
           ,1),
		   (2
           ,1)
GO

INSERT INTO [dbo].[Studio]
           ([name]
		   ,[uniquename]
           ,[location])
     VALUES
           ('Admin Testing Studio',
		   'testadmin'
           ,'Petaling Jaya')
GO

INSERT INTO [dbo].[UserStudio]
           ([studioid]
           ,[userid]
           ,[studioroleid])
     VALUES
           (1
           ,1
           ,1)
GO
