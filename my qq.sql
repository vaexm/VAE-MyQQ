create database MyQQ1
on
(
  name='MyQQ1_dat',
  filename='E:\���ݿ�\1017\ MyQQ1.mdf',
  size=3mb
)
log on
(
   name=' MyQQ1_log',
   filename='E:\���ݿ�\1017\ MyQQ1.ldf',
   size=3mb
)

use MyQQ1
create table FriendshipPolicy
(
  Id int identity(1,1) primary key,
  FriendshipPolicyId varchar(30) not null
)
insert into FriendshipPolicy
select '�����κ��˼���Ϊ����'union
select '��Ҫ�����֤'union
select '�������κ��˼���Ϊ����'

select *from FriendshipPolicy
create table Star
(
  Id int identity(1,1) primary key,
  Star varchar(20) not null
)
insert into star
select '������'union
select '��Ů��'union
select '��ţ��'union
select 'ˮƿ��'union
select '�����'union
select '��з��'union
select 'ʨ����'union
select 'Ħ����'union
select '������'union
select '˫����'union
select '��Ы��'union
select '˫����'
select*from star



create table BloodType
(
 Id int identity(1,1) not null primary key,

 BloodType varchar(30) not null
)
insert into  BloodType
select 'AB��'union
select 'A��'union
select 'B��'union
select 'O��'
select *from BloodType
create table Users
(
  Id int identity(1000,1) not null primary key,
  LoginPwd varchar(30) ,
  FriendshipPolicyId int not null foreign key references FriendshipPolicy(Id),
  NickName varchar(20) not null,
  FaceId int,
  Sex varchar(2) not null,
  Age int not null,
  Name varchar(20),
  StarId int foreign key references Star(Id),
  BloodTypeId int foreign key references BloodType(Id)
)
insert into Users
select '1234', 1,'VAE', 1,'Ů',20 ,'����',1 ,1 union
select '12345',2 ,'����',2 ,'Ů',19 ,'',10 , 1union
select '963210',1 ,'С��',3 ,'Ů',22 ,'�ɿ�',3 , 2union
select '114842',2 ,'��', 4,'��', 18,'',5 ,3 union
select '861222',2 ,'��',1 ,'��', 21,'', 6,4 
insert into Users
select '135135',3,'��ܰ',6,'Ů',20,'',7,2 union
select '132131',3,'����',10,'Ů',25,'',9,1 union
select '1362356',3,'��ײ�',18,'��',21,'����',8,1 union
select '1539266',3,'������',12,'Ů', 20,'', 1,2  
select *from Users
create table Friends
(
  Id int identity(1,1) not null,
  HostId int foreign key references Users(Id),
  FriendId int foreign key references Users(Id)
)
insert into Friends
select 1000,1001 union
select 1000, 1002union
select 1000,1003 union
select 1003,1002 union
select 1004, 1003 union
select 1002,1001 union
select 1001,1003
insert into Friends
select 1001,1004 union
select 1001,1002 union
select 1002,1003 union
select 1002,1004 union
select 1003,1004 union
select 1003,1001 union
select 1004,1002
insert into Friends select 1005,1000
insert into Friends select 1005,1001
insert into Friends select 1002,1000

insert into Friends select 1002,1009
insert into Friends
select 1000,1005 union
select 1001,1005



select *from Friends
create table MessageType
(
 Id int identity(1,1) not null primary key,
 MessageType varchar(30)
)
insert into MessageType
select '��ͨ������Ϣ'union
select '��Ӻ�����Ϣ'union
select '����Ϣ'
select *from MessageType
create table Messages
(
  Id int identity(1,1) not null,
  FromUserId int foreign key references Users(Id),
  ToUserId int foreign key references Users(Id),
  Message varchar(30),
  MessagetypeId int foreign key references MessageType(Id),
  MessageState int,
  MessageTime DateTime
)

insert into Messages
select 1000,1001 ,'���', 1,1,GETDATE() union
select 1001,1000 ,'���Ϻ�',2 ,1, GETDATE() union
select 1002,1001 ,'�����', 1,1, GETDATE() union
select 1002, 1003,'���ִ���',1 ,1,GETDATE() union
select 1004, 1003,'��V����',1 ,0 ,GETDATE()
select *from Messages

select *from Users where Id=

select *from dbo.FriendshipPolicy

select *from Users
update Users set LoginPwd=114842 where Id=1000
select *from Friends
select *from Star
select *from BloodType

select count(*) from Users where Id=1000 and LoginPwd=114842

select *from Friends where HostId=1
insert into Users  select '111',1,'������',4,'',23,'',3,2 select @@IDENTITY

delete  from Users where Id=1010
select *from dbo.FriendshipPolicy


update Users set LoginPwd='',NickName='��',Sex='��',Age=18 ,Name='С��',StarId='4+1',BloodUTypeId='2+1' where Id=1000
update Users set LoginPwd=114842 where Id=1000
select *from MessageType
insert into Messages (FromUserId,ToUserId,Message,MessageTypeId,MessageState) select '1000','1002','hello','1','1'

select *from Messages FromUserId=  and ToUserId=

update Messages set MessageState=0 where Id=

select *from Messages where FromUserId='1001'  and ToUserId='1000'

select *from Users where Id<>1000

select *from Users where NickName=''

select *from Users where Id=

select COUNT(*)from Friends where HostId=1000 and FriendId=1001

insert into Friends select''
delete from Friends where HostId= and FriendId=

UPDATE Users set LoginPwd=114842 where Id=1000
update Users set LoginPwd=1234 where Id=1001
select count(*) from Users where Id=1000 and LoginPwd=114842
update Users set FriendshipPolicyId=3 where Id=1009

select *from Messages
update Users set FriendshipPolicyId=2 where Id=1007

delete from Friends where Id=25