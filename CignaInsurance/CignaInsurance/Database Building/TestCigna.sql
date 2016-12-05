
use Health_Insurance
create table [Credentials]
(
	CreID int primary key identity,
	Credentials int
);

create table [Users]
(
	UserID int primary key identity not null,
	UserName nvarchar(30) unique not null ,
	Password nvarchar(20) not null,
	CreID int foreign key references credentials(creid)
);

create table City
(
CityID int primary key identity,
CityName nvarchar(20) not null
);

create table State 
(
StateID int primary key identity,
StateName nvarchar(20) not null
);

create table Hospital 
(
HospitalID int primary key identity,
Name nvarchar(100) not null,
Address nvarchar (30) not null,
CityID int not null foreign key references city (cityid),
StateID int not null foreign key references state (stateid),
ZipCode varchar(10) not null,
Phone varchar(20)
);

create table Doctor 
(
	DoctorID int primary key identity,
	Firstname nvarchar (20) not null,
	Lastname nvarchar(20) not null , 
	Gender bit not null ,
	DateofBirth datetime not null,
	Phone varchar(20) not null unique,
	Email nvarchar (100) not null unique,
	SSN varchar(20) not null unique,
	Address nvarchar(20) not null,
	CityID int not null,
    StateID int not null,
	Zip varchar(10) not null, 
	DoctorType varchar(20) not null,
	HospitalID int foreign key references hospital (hospitalid),
);

create table Customer
(
	CustomerID int primary key identity,
	UserID int not null unique foreign key references [users] (userid),
	Firstname nvarchar(20) not null,
	Lastname nvarchar(20) not null,
	Gender bit not null, 
	DateofBirth datetime not null,
	Address nvarchar(20) not null,
	CityID int not null , 
    StateID int not null,
	Zip varchar(10) not null, 
	Phone varchar(20) not null unique, 
	Email nvarchar(100) not null unique, 
	SSN nvarchar(20) not null unique,
	DoctorID int foreign key references doctor (doctorid)
);

create table Agent
(
	AgentID int primary key identity,
	UserID int not null unique foreign key references [users] (userid),
	Firstname nvarchar(20) not null, 
	Lastname nvarchar(20) not null, 
	Gender bit not null , 
	DateofBirth datetime not null,
	Address nvarchar(20) not null,
	CityID int not null , 
    StateID int not null,
	Zip varchar(10) not null,
	Phone varchar(20) not null unique,
	Email nvarchar(100) not null unique,
	SSN varchar(20) not null unique
);

create table Quote
(
	QuoteID int primary key identity,
	QuoteName nvarchar(20), 
	CustomerID int not null foreign key references customer (customerid), 
	QuoteDescription nvarchar(100),
	QuoteFee int,
    StartDate datetime,
    EndDate datetime,
    ExpireDate datetime,
	IsActive bit not null 
);

create table Claims
(
	ClaimID int primary key identity,
	ClaimStatus nvarchar(20) not null , 
	CustomerID int not null foreign key references customer (customerid), 
	AgentID int foreign key references agent (agentid), 
	Description nvarchar(100) not null, 
	DeclareDate datetime not null,
	PaidDate datetime,
	AmountPaid int 
);

create table PlanType
(
	PlanTypeID int primary key identity, 
	PlanTypeName nvarchar(20) not null,
	PlanTypeDescription nvarchar(100),
	PlanDetails nvarchar(4000),
	PlanTypeFee int not null
);

create table [Plan]
(
PlanID int primary key identity,
PlanTypeID int not null foreign key references plantype (plantypeid),
CustomerID int not null foreign key references customer (customerid),
PlanDescription nvarchar(100) not null, 
StartDate datetime not null, 
EndDate datetime not null,
PlanFee int not null
);
