use master
go
create database DiWork
go
use DiWork

go


create table repuestos
(
	ID int primary key not null identity(1,1),
	nombre varchar(100) not null,
	precio money not null check (precio >0),
	estado bit not null
)

go

create table Desperfectos
(
	ID int primary key not null identity(1,1),
	descripcion varchar(500) not null,
	manoDeObra varchar(300) not null,
	tiempo int not null,
	estado bit not null
)

go

create table DesperfectosXRepuestos
(
	IDDesperfectos int foreign key references Desperfectos(ID),
	IDRepuestos int foreign key references Repuestos(ID),
	primary key (IDDesperfectos, IDRepuestos),
	estado bit not null
)

go

create table Marcas
(
	ID int primary key not null identity(1,1),
	nombre varchar(100) not null,
	estado bit not null
)

go

create table Modelos
(
	ID int not null identity(1,1),
	IDMarcas int foreign key references Marcas(ID),
	nombre varchar(100) not null,
	estado bit not null
	primary key(ID, IDMarcas)
)

go

create table TiposAutomovil
(
	ID int primary key not null identity(1,1),
	nombre varchar(100) not null,
	estado bit not null
)

go

create table Automoviles
(
	IDMarca int not null,
	IDModelo int not null,
	patente varchar(8) not null,
	IDTipo int foreign key references TiposAutomovil(ID),
	cantidadPuetas int null check(CantidadPuetas > 0 and CantidadPuetas <= 5),
	foreign key (IDMarca, IDModelo) references Modelos(ID, IDMarcas),
	primary key(IDMarca, IDModelo, patente, IDTipo)
)

go

create table Motos
(
	IDMarca int not null,
	IDModelo int not null,
	patente varchar(8) not null,
	cilindrada int not null check(cilindrada > 0),
	foreign key (IDMarca, IDModelo) references Modelos(ID, IDMarcas),
	primary key(IDMarca, IDModelo, patente)
)

go

create table DesperfectosXMotos
(
	IDMarca int not null,
	IDModelo int not null,
	patente varchar(8) not null,
	IDDesperfecto int not null foreign key references Desperfectos(ID),
	foreign key (IDMarca, IDModelo, patente) references Motos(IDMarca, IDModelo, patente),
	primary key(IDMarca, IDModelo, patente, IDDesperfecto)
)

go

create table DesperfectosXAutos
(
	IDMarca int not null,
	IDModelo int not null,
	patente varchar(8) not null,
	IDTipo int not null,
	IDDesperfecto int not null foreign key references Desperfectos(ID),
	foreign key (IDMarca, IDModelo, patente, IDTipo) references Automoviles(IDMarca, IDModelo, patente, IDTipo),
	primary key(IDMarca, IDModelo, patente, IDTipo, IDDesperfecto)
)

/* -- vehiculos -- */
