print('---DROPING TABLES---')
drop table if exists [User]
drop table if exists [Trainer]
drop table if exists [Exerciser]
go

print('---CREATE USER TABLE---')
create table [User]
(
	Id int primary key identity,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Email nvarchar(100),
	Password nvarchar(64),
	Username nvarchar(75),
	PhoneNumber nvarchar(20),
	Nationality nvarchar(40),
	IsEmailVerified bit,
	IsPhoneNumberVerified bit,
	SecretCode nvarchar(6),
	SecretCodeExpiry Date,
	AreTermsAndServicesAccepted bit,
	IsPrivacyPolicyAccepted bit,
	DateOfBirth Date,
	ProfilePhotoUrl nvarchar(255),
	CreatedAt Date,
	UpdatedAt Date
)

print('---CREATE TRAINER TABLE---')
create table [Trainer]
(
	Bio nvarchar(1000),
	Experience int,
);
go

print('---CREATE EXERCISER TABLE---')
create table [Exerciser]
(
	ExerciseHistory int,
	Goal int,
	MessageForCoaches nvarchar(1000),
	EmergencyContactFullName nvarchar(100),
	EmergencyContactPhoneNumber nvarchar(20)
);
go