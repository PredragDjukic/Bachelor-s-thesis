print('---DROPING TABLES---')
drop table if exists [Trainer]
drop table if exists [Exerciser]
drop table if exists [User]
go

print('---CREATE USER TABLE---')
create table [User]
(
	Id int primary key identity,
	Role int not null,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(100) not null,
	Password nvarchar(64) not null,
	Username nvarchar(75) not null,
	PhoneNumber nvarchar(20) not null,
	Nationality nvarchar(40) not null,
	IsEmailVerified bit not null,
	IsPhoneNumberVerified bit not null,
	SecretCode nvarchar(6) not null,
	SecretCodeExpiry Date not null,
	AreTermsAndServicesAccepted bit not null,
	IsPrivacyPolicyAccepted bit not null,
	DateOfBirth Date not null,
	ProfilePhotoUrl nvarchar(255) not null,
	CreatedAt Date not null,
	UpdatedAt Date not null
)

alter table [User] add constraint UC_User_Email unique (Email)
alter table [User] add constraint UC_User_PhoneNumber unique (PhoneNumber)

print('---CREATE TRAINER TABLE---')
create table [Trainer]
(
	Bio nvarchar(1000) not null,
	Experience int not null,
	UserId int not null
);

alter table [Trainer] add constraint FK_Trainer_User Foreign Key (UserId) references [User](Id) on delete cascade;
alter table [Trainer] add constraint UC_Trainer_UserId unique (UserId)
go

print('---CREATE EXERCISER TABLE---')
create table [Exerciser]
(
	ExerciseHistory int not null,
	Goal int not null,
	MessageForCoaches nvarchar(1000) not null,
	EmergencyContactFullName nvarchar(100) not null,
	EmergencyContactPhoneNumber nvarchar(20) not null,
	UserId int not null
);

alter table [Exerciser] add constraint FK_Exerciser_User Foreign Key (UserId) references [User](Id) on delete cascade;
alter table [Exerciser] add constraint UC_Exerciser_UserId unique (UserId)
go