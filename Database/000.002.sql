
create table Package
(
	Id int primary key identity,
	Name nvarchar(30) not null,
	NumberOfSession int not null,
	Price decimal(12, 2) not null,
	TrainerId int not null,
	CreatedAt Date not null,
	UpdatedAt Date not null
)
--#ON DELTE NO ACTION (Case if trainer deletes his package, but exercisers still have active bundles)
create table Bundle
(
	Id int primary key identity,
	SessionsLeft int not null,
	PackageId int not null,
	ExerciserId int not null,
	IsActive bit not null,
	CreatedAt Date not null,
	UpdatedAt Date not null
)