print('---DROPING FOREIGN KEYS---')
alter table Bundle drop constraint if exists FK_Bundle_Package
alter table Bundle drop constraint if exists FK_Bundle_Exerciser
go

print('---DROPING TABLES---')
drop table if exists [Package]
drop table if exists [Bundle]
go

print('---CREATE PACKAGE---')
create table Package
(
	Id int primary key identity,
	NumberOfSessions int not null,
	Price decimal(12, 2) not null,
	IsActive bit not null,
	TrainerId int not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null
)

alter table Package add constraint CK_Package_NumberOfSessions check (NumberOfSessions > 0 AND NumberOFSessions < 30);
alter table Package add constraint CK_Package_Price check (Price >= 0);

print('---CREATE BUNDLE---')
create table Bundle
(
	Id int primary key identity,
	SessionsLeft int not null,
	PackageId int not null,
	ExerciserId int not null,
	IsActive bit not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null
)
go

alter table Bundle add constraint CK_SessionsLeft check (SessionsLeft >= 0)

--alter table Bundle add constraint DF_Bundle_IsActive default 1 for IsActive;

--ON DELTE NO ACTION (Case if trainer deletes his package, but exercisers still have active bundle)
alter table Bundle add constraint FK_Bundle_Package foreign key (PackageId) references Package(Id) on delete no action;
--ON DELTE NO ACTION (Case if trainer exerciser is deleted, trainer still has a history or something similar)
alter table Bundle add constraint FK_Bundle_Exerciser foreign key (ExerciserId) references [User](Id) on delete no action;