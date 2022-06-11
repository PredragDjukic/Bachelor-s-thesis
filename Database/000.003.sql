print('---DROPING TABLES---')
drop table if exists [Session]
drop table if exists [Payment]
go

print('---CREATE Session---')
create table Session 
(
	Id int not null identity primary key,
	SessionNumber int null,
	Location nvarchar(250) not null,
	StartDateTime datetime not null,
	EndDateTime datetime not null,
	Status int not null,
	TrainerId int not null,
	ExerciserId int null,
	BundleId int null,
	CreatedAt datetime not null,
	UpdateAt datetime not null
)

--alter table Session add constraint CK_Session_SessionNumber check(SessionNumber > 0 and SessionNumber <= 30);

alter table Session add constraint FK_Session_Trainer foreign key (TrainerId) references [User](id);
alter table Session add constraint FK_Session_Exerciser foreign key (ExerciserId) references [User](id);
alter table Session add constraint FK_Session_Bundle foreign key (BundleId) references Bundle(id);

print('---CREATE Payment---');
create table Payment
(
		Id int identity not null primary key,
	Price decimal not null,
	ExerciserId int not null,
	TrainerId int not null,
	CreatedAt datetime not null,
	UpdateAt datetime not null
)

alter table Payment add constraint FK_Payment_Trainer foreign key (TrainerId) references [User](id);
alter table Payment add constraint FK_Payment_Exerciser foreign key (ExerciserId) references [User](id);