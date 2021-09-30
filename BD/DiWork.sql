use master

go

create database DiWork

go

use DiWork

go

create table Repuestos
(
	ID int primary key not null identity(1,1),
	nombre varchar(100) not null,
	precio money not null check (precio > 0),
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

create table RepuestosXDesperfecto
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

create table Automoviles
(
	IDMarca int not null,
	IDModelo int not null,
	patente varchar(8) not null,
	Tipo  varchar(40) not null,
	cantidadPuetas int null check(CantidadPuetas > 0 and CantidadPuetas <= 5),
	estado bit not null,
	foreign key (IDMarca, IDModelo) references Modelos(ID, IDMarcas),
	primary key(IDMarca, IDModelo, patente)
)

go

create table Motos
(
	IDMarca int not null,
	IDModelo int not null,
	patente varchar(8) not null,
	cilindrada int not null check(cilindrada > 0),
	estado bit not null,
	foreign key (IDMarca, IDModelo) references Modelos(ID, IDMarcas),
	primary key(IDMarca, IDModelo, patente)
)

go

create table PresupuestoMoto
(
	IDMarca int not null,
	IDModelo int not null,
	patente varchar(8) not null,
	IDDesperfecto int not null foreign key references Desperfectos(ID),
	foreign key (IDMarca, IDModelo, patente) references Motos(IDMarca, IDModelo, patente),
	primary key(IDMarca, IDModelo, patente, IDDesperfecto)
)

go

create table PresupuestoAutos
(
	IDMarca int not null,
	IDModelo int not null,
	patente varchar(8) not null,
	IDTipo int not null,
	IDDesperfecto int not null foreign key references Desperfectos(ID),
	foreign key (IDMarca, IDModelo, patente) references Automoviles(IDMarca, IDModelo, patente),
	primary key(IDMarca, IDModelo, patente, IDDesperfecto)
)

go

/* Procedimientos */

create procedure addMoto 
(
	@IDMarca int, 
	@IDModelo int, 
	@Patente varchar(9), 
	@Cilindrada int
) 
as
begin
	insert into Motos (IDMarca, IDModelo, patente, cilindrada, estado) values (@IDMarca, @IDModelo, @Patente, @Cilindrada, 1)
end

go

create procedure addAutomovil
(
	@IDMarca int, 
	@IDModelo int, 
	@Patente varchar(9), 
	@Tipo varchar(15),
	@CantidadPuertas int
) 
as
begin
	insert into Automoviles(IDMarca, IDModelo, patente, Tipo, cantidadPuetas, estado) values (@IDMarca, @IDModelo, @Patente, @Tipo, @CantidadPuertas, 1)
end

select ma.ID IDMa, ma.nombre nombreMa, ma.estado estadoMa, mo.ID IDMo, mo.nombre nombreMo, mo.estado estadoMo from Modelos mo
inner join Marcas ma on ma.ID = mo.IDMarcas
where mo.estado = 1 and ma.estado = 1 and ma.ID = 1