create table UsuariosRFC (
Id int identity(1,1),
Nombre varchar(50) not null,
Paterno varchar(50) not null,
Materno varchar(50), 
RFC varchar(10),
FNacimiento smalldatetime not null,
primary key(id)
)

create table PalabrasExcentas(
ID int identity(1,1),
Nombre varchar(4) not null
)

insert into PalabrasExcentas VALUES('CAGO');
insert into PalabrasExcentas VALUES('BUEY');
insert into PalabrasExcentas VALUES('CACO');
insert into PalabrasExcentas VALUES('CAKO');
insert into PalabrasExcentas VALUES('COJA');
insert into PalabrasExcentas VALUES('COJI');
insert into PalabrasExcentas VALUES('CULO');
insert into PalabrasExcentas VALUES('GUEY');
insert into PalabrasExcentas VALUES('KACA');
insert into PalabrasExcentas VALUES('KAGA');
insert into PalabrasExcentas VALUES('KOGE');
insert into PalabrasExcentas VALUES('KAKA');
insert into PalabrasExcentas VALUES('MAME');
insert into PalabrasExcentas VALUES('MEAR');
insert into PalabrasExcentas VALUES('MEON');
insert into PalabrasExcentas VALUES('MOCO');
insert into PalabrasExcentas VALUES('PEDA');
insert into PalabrasExcentas VALUES('PENE');
insert into PalabrasExcentas VALUES('PUTO');
insert into PalabrasExcentas VALUES('RATA');

insert into PalabrasExcentas VALUES('BUEI');
insert into PalabrasExcentas VALUES('CACA');
insert into PalabrasExcentas VALUES('CAGA');
insert into PalabrasExcentas VALUES('CAKA');
insert into PalabrasExcentas VALUES('COGE');
insert into PalabrasExcentas VALUES('COJO');
insert into PalabrasExcentas VALUES('FETO');
insert into PalabrasExcentas VALUES('JOTO');
insert into PalabrasExcentas VALUES('KAGO');
insert into PalabrasExcentas VALUES('KACO');
insert into PalabrasExcentas VALUES('KAGO');
insert into PalabrasExcentas VALUES('KOJO');
insert into PalabrasExcentas VALUES('KULO');
insert into PalabrasExcentas VALUES('MAMO');
insert into PalabrasExcentas VALUES('MEAS');
insert into PalabrasExcentas VALUES('MION');
insert into PalabrasExcentas VALUES('MULA');
insert into PalabrasExcentas VALUES('PEDO');
insert into PalabrasExcentas VALUES('PUTA');
insert into PalabrasExcentas VALUES('QULO');

