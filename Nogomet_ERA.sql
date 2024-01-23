use master;
go
drop database if exists nogomet;
go
create database nogomet;
go
use nogomet;

create table igraci (
id int primary key identity (1,1) not null,
ime varchar(50) not null,
prezime varchar(50) not null,
pozicija varchar(50) not null,
broj_golova int,
momcad int
);

create table momcadi (
id int primary key identity (1,1) not null,
naziv_kluba varchar(50) not null,
liga varchar(50) not null,
trener int
);

create table treneri(
id int primary key identity (1,1) not null,
ime varchar(50) not null,
prezime varchar (50) not null,
datum_rodenja datetime,
broj_postignuca int
);

alter table igraci add foreign key(momcad) references momcadi(id);
alter table momcadi add foreign key(trener) references treneri(id);

alter table treneri
alter column broj_postignuca int not null;

insert into igraci (ime, prezime, pozicija)values 
('Francesco','Toldo','vratar'),
('Julio','Cesar','vratar'),
('Paolo','Orlandoni','vratar'),
('Ivan','Cordoba','branic'),
('Javier','Zanetti','branic'),
('Maxwell','Andrade','branic'),
('Fabio','Grosso','branic'),
('Maicon','Sisenando','branic'),
('Nicolas','Burdisso','branic'),
('Marco','Materazzi','branic'),
('Walter','Samuel','branic'),
('Dejan','Stankovic','vezni_igrac'),
('Luis','Figo','vezni_igrac'),
('Patrick','Vieira','vezni_igrac'),
('Olivier','Dacourt','vezni_igrac'),
('Esteban','Cambiasso','vezni_igrac'),
('Santiago','Solari','vezni_igrac'),
('Mariano','Gonzalez','vezni_igrac'),
('Zlatan','Ibrahimovic','napadac'),
('Julio','Cruz','napadac'),
('Adriano','Ribeiro','napadac'),
('Hernan','Crespo','napadac'),
('Alvaro','Recoba','napadac');

insert into momcadi (naziv_kluba, liga) values
('Inter','Serie_A'),
('Milan','Serie_A'),
('Real_Madrid','La_Liga');

insert into treneri (ime, prezime, broj_postignuca) values
('Roberto','Mancini',5),
('Carlo','Ancelotti',25),
('Fabio','Capello',7);
