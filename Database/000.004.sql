alter table [User]
drop column if exists CustomerId;

alter table [User]
add CustomerId nvarchar(55) null;
