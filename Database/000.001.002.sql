print('---DROPING TABLES---')
drop table if exists [User]
drop table if exists [Trainer]
drop table if exists [Exerciser]
go

print('---CREATE TRAINER TABLE---')
create table [Trainer]
(
	Id int not null primary key identity,
	Bio nvarchar(1000) not null,
	Experience int not null,
	UserId int not null
);

--alter table [Trainer] add constraint FK_Trainer_User Foreign Key (UserId) references [User](Id) on delete cascade;
alter table [Trainer] add constraint UC_Trainer_UserId unique (UserId)
go

print('---CREATE EXERCISER TABLE---')
create table [Exerciser]
(
	Id int not null primary key identity,
	ExerciseHistory int not null,
	Goal int not null,
	MessageForCoaches nvarchar(1000) not null,
	EmergencyContactFullName nvarchar(100) not null,
	EmergencyContactPhoneNumber nvarchar(20) not null,
	UserId int not null
);

--alter table [Exerciser] add constraint FK_Exerciser_User Foreign Key (UserId) references [User](Id) on delete cascade;
alter table [Exerciser] add constraint UC_Exerciser_UserId unique (UserId)
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
	UpdatedAt Date not null,
	TrainerId int null,
	ExerciserId int null
)

alter table [User] add constraint UC_User_Email unique (Email)
alter table [User] add constraint UC_User_PhoneNumber unique (PhoneNumber)

alter table [User] add constraint FK_User_Trainer Foreign Key (TrainerId) references [Trainer](Id) on delete cascade;
alter table [User] add constraint FK_User_Exerciser Foreign Key (ExerciserId) references [Exerciser](Id) on delete cascade;

alter table [User] add constraint UC_User_TrainerId unique (TrainerId)
alter table [User] add constraint UC_User_ExerciserId unique (ExerciserId)

alter table [User] add constraint CHK_User_Role check ((TrainerId is null AND ExerciserId is not null) OR (TrainerId is not null AND ExerciserId is null))
