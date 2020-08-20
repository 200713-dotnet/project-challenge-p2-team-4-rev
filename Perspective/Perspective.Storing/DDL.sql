
create table Catagory
(
CatagoryId int PRIMARY key,
[Name] NVARCHAR(50) not null,
Description NVARCHAR(50) not null,
DateModified DATETIME not null
);

create table [User]
(
UserId int PRIMARY key,
[Name] NVARCHAR(50) not null,
[Password] NVARCHAR(50) not null,
DateModified DATETIME not null
);

create table Room
(
RoomId int PRIMARY key,
CatagoryId int not null,
WaitList INT not null,
[Name] NVARCHAR(50) not null,
Topic NVARCHAR(50),
DateModified DATETIME not null,
FOREIGN KEY (CatagoryId) REFERENCES Catagory(CatagoryId)
);

create table [Message]
(
MessageId int PRIMARY key,
[Name] NVARCHAR(50),
content NVARCHAR(250) not null,
DateModified DATETIME not null
);

create table CatagoryUserJunction
(
CatagoryUserId int PRIMARY key,
UserId int not null,
CatagoryId int not null,
DateModified DATETIME not null,
FOREIGN KEY (UserId) REFERENCES [User](UserId),
FOREIGN KEY (CatagoryId) REFERENCES Catagory(CatagoryId)
);

create table MessageJunction
(
MessageJunctionId int PRIMARY key,
RoomId int not null,
UserId int not null,
MessageId int not null,
DateModified DATETIME not null,
FOREIGN KEY (RoomId) REFERENCES Room(RoomId),
FOREIGN KEY (UserId) REFERENCES [User](UserId),
FOREIGN KEY (MessageId) REFERENCES [Message](MessageId)
);

create table TopicList
(
    TopicListId int PRIMARY KEY,
    CatagoryId int not null,
    [Name] NVARCHAR(50) not null,
    DateModified DATETIME not null,
    FOREIGN KEY (CatagoryId) REFERENCES Catagory(CatagoryId)
);
