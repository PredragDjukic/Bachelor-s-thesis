print('---DROPING TABLES---')
drop table if exists [Session]
drop table if exists [Payment]
go

print('---CREATE Session---')
create table Session 
(
	Id int identity primary key,
	SessionNumber int null,
	Location nvarchar(250) not null,
	StartDateTime Date not null,
	EndDateTime Date not null,
	Status int not null,
	TrainerId int not null,
	ExerciserId int null,
	PackageId int null,
	CreatedAt Date not null,
	UpdateAt Date not null
)

alter table Session add constraint CK_Session_SessionNumber check(SessionNumber > 0 and SessionNumber <= 30);

alter table Session add constraint FK_Session_Trainer foreign key (TrainerId) references [User](id);
alter table Session add constraint FK_Session_Exerciser foreign key (ExerciserId) references [User](id);
alter table Session add constraint FK_Session_Package foreign key (PackageId) references Package(id);