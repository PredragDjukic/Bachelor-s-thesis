print('---DROPING TABLES---')
drop table if exists [Rate]
go

print('---CREATE Rate---')
create table Rate
(
	Id int not null identity primary key,
	Comment nvarchar(1000) null,
	Rate int not null,
	SessionId int not null,
	CreatedAt datetime not null,
	UpdateAt datetime not null
)

alter table Rate add constraint FK_Rate_Session foreign key (SessionId) references [Session](id);

alter table Rate add constraint CK_Rate_Rate check(Rate > 0 and Rate <= 10);
