use master
drop database DiWork
go
create database DiWork
go
use DiWork
go

create table Marcas(
	ID int primary key not null identity(1,1),
	marca varchar(65) not null,
	estado bit not null
)

go

create table Modelos(
	ID int primary key not null identity(1,1),
	IDMarca int foreign key references Marcas(ID) not null,
	modelo varchar(65) not null,
	estado bit not null
)

go

create table TipoAutomoviles(
	ID int primary key not null,
	tipo varchar(40) not null
)

go

create table presupuestos(
	ID int primary key not null identity(1,1),
	descripcion varchar(250) null,
	costo money not null check(costo >= 0),
	diasTrabajo int not null check(diasTrabajo >= 0)
)

go

create table Repuestos(
	ID int primary key not null identity(1,1),
	repuesto varchar(75) not null,
	precio money not null check(precio >= 0),
	estado bit not null
)

go

create table RepuestosxPresupuestos(
	IDRepuesto int foreign key references Repuestos(ID) not null,
	IDPresupuesto int foreign key references Presupuestos(ID) not null,
	cantidadRepuestos int not null check(cantidadRepuestos > 0),
	costoRepuestos money not null check(costoRepuestos >= 0),
	primary key(IDRepuesto, IDPresupuesto)
)

go

create table Motos(
	ID int primary key not null identity(1,1),
	IDModelo int foreign key references Modelos(ID) not null,
	patente varchar(15) null,
	cilindrada int null check(cilindrada <= 9999)
)

go

create table Automoviles(
	ID int primary key not null identity(1,1),
	IDModelo int foreign key references Modelos(ID) not null,
	IDTipo int foreign key references TipoAutomoviles(ID) not null,
	patente varchar(15) null,
	cantidadPuertas int null check(cantidadPuertas <= 6)
)

go

create table PresupuestosxMotos(
	IDMoto int foreign key references Motos(ID) not null,
	IDPresupuesto int foreign key references Repuestos(ID) not null,
	CostoTotal money not null check(costoTotal >= 0),
	primary key(IDMoto, IDPresupuesto)
)

go

create table PresupuestosxAutomovil(
	IDAutomovil int foreign key references Automoviles(ID) not null,
	IDPresupuesto int foreign key references Repuestos(ID) not null,
	CostoTotal money not null check(costoTotal >= 0),
	primary key(IDAutomovil, IDPresupuesto)
)




