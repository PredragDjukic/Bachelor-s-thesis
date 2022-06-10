alter table [User]
drop column if exists CustomerId;

alter table [User]
drop column if exists IsDeleted;

alter table [User]
add CustomerId nvarchar(55) null;

alter table [User]
add IsDeleted bit not null default 0;