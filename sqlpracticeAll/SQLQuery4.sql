--data integrity
--domain integrity (for columns)
--check ,default we will use
--we only use default only once in a column and also
--only with insert wewill use
--cant be used with identity property.
create table defaultdemo
(
cid int,
cname varchar(20),
caddress varchar(30) 
);

alter table defaultdemo
add constraint default_adress default 'bangalore'
for caddress;

insert into defaultdemo(cid,cname) values
(1,'monika');
select * from defaultdemo;
--drop constraint
alter table defaultdemo drop constraint default_address;

--check
create table checkdemo
(cid int,
age varchar(20) check(age>0 and age<100)
);
insert into checkdemo values(1,20);

--primary key
--1.no duplicate records
--2.index applied for the table
--3.table will be sorted in ascending order

create table pkdemo
(
cid int constraint cpk primary key,
cname varchar(20)
);
--to remove the primary key we will use the name of constraint we given we will use drop
insert into pkdemo values
(1,'moni');
insert into pkdemo values
(2,'moni')
insert into pkdemo values
(3,'moni');
insert into pkdemo values
(5,'moni');
insert into pkdemo values
(0,'moni');
select * from pkdemo;
--how to remoce primary key
alter table pkdemo
drop constraint cpk;
--if i dont want clustering 
alter table pkdemo
add constraint cpk primary key nonclustered(cid)
--unique demo
create table uniquedemo
(cid int,
aadhar varchar(20) unique,
pan varchar(20) unique);
insert into uniquedemo values (1,'abc123','xyz123');
--foreign table
create table fkdemo
(
cid int constraint fk foreign key references pkdemo(cid),
product varchar(20)
)
insert into fkdemo values (1,'books');

--we cant delete a record from te primary key whre is is used by the foreign key
--first we need to delete the recoed from fktable and next from the primary key tabel
--on delete cascade 
--using this if we delete in primary key table it will dlelte infk aslo




