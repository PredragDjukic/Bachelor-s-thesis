print('---DROPING TABLES---')
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
	SecretCode nvarchar(6) null,
	SecretCodeExpiry Date null,
	AreTermsAndServicesAccepted bit not null,
	IsPrivacyPolicyAccepted bit not null,
	DateOfBirth Date not null,
	CreatedAt Date not null,
	UpdatedAt Date not null
)

alter table [User] add constraint UC_User_Email unique (Email)
alter table [User] add constraint UC_User_PhoneNumber unique (PhoneNumber)

alter table [User] add constraint DF_User_IsEmailVerified default 0 for IsEmailVerified;
alter table [User] add constraint DF_User_IsPhoneNumberVerified default 0 for IsPhoneNumberVerified;
alter table [User] add constraint DF_User_AreTermsAndServicesAccepted default 0 for AreTermsAndServicesAccepted;
alter table [User] add constraint DF_User_IsPrivacyPolicyAccepted default 0 for IsPrivacyPolicyAccepted;