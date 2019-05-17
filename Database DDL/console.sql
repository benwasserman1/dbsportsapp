create table Games
(
	Id int auto_increment
		primary key,
	GameDate datetime null,
	HomeScore int null,
	VisitingScore int null,
	HomeTeamId int null,
	VisitingTeamId int null
)
engine=InnoDB
;

create index Games_GameDate_index
	on Games (GameDate)
;

create index Games_Teams__fk_ht
	on Games (HomeTeamId)
;

create index Games_Teams_fk_vt
	on Games (VisitingTeamId)
;

create table Picks
(
	Id int auto_increment
		primary key,
	Pick int null,
	Game int null,
	User int not null,
	constraint Picks_Games_Id_fk
		foreign key (Game) references Games (Id)
)
engine=InnoDB
;

create index Picks_Teams_Id_fk
	on Picks (Pick)
;

create index Picks_Games_Id_fk
	on Picks (Game)
;

create index Picks_Users_Id_fk
	on Picks (User)
;

create table Players
(
	Id int auto_increment
		primary key,
	Name varchar(100) null,
	TeamId int null
)
engine=InnoDB
;

create index Players_Teams_Id_fk
	on Players (TeamId)
;

create table Stats
(
	Id int auto_increment
		primary key,
	Points int null,
	Rebounds int null,
	Steals int null,
	Blocks int null,
	Assists int null,
	PlayerId int null,
	GameId int null,
	constraint Stats_Players_Id_fk
		foreign key (PlayerId) references Players (Id),
	constraint Stats_Games_Id_fk
		foreign key (GameId) references Games (Id)
)
engine=InnoDB
;

create index Stats_Players_Id_fk
	on Stats (PlayerId)
;

create index Stats_Games_Id_fk
	on Stats (GameId)
;

create table Teams
(
	Id int auto_increment
		primary key,
	Name varchar(100) null,
	City varchar(100) null,
	State varchar(75) null
)
engine=InnoDB
;

create index Teams_Name_index
	on Teams (Name)
;

alter table Games
	add constraint Games_Teams__fk_ht
		foreign key (HomeTeamId) references Teams (Id)
;

alter table Games
	add constraint Games_Teams_fk_vt
		foreign key (VisitingTeamId) references Teams (Id)
;

alter table Players
	add constraint Players_Teams_Id_fk
		foreign key (TeamId) references Teams (Id)
;

create table Users
(
	Id int auto_increment
		primary key,
	Name varchar(75) not null,
	Email varchar(75) not null,
	Psw varchar(255) not null
)
engine=InnoDB
;

alter table Picks
	add constraint Picks_Users_Id_fk
		foreign key (User) references Users (Id)
			on delete cascade
;



