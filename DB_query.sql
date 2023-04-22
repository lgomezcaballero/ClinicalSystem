--Sistema de clínicas
-------------------
--La clinica cuenta con una lista con medicos y pacientes
--De los medicos se conoce el numero de matricula, nombre y especialidad.
--De los pacientes se conoce numero de hstoria clinica, nombre y una lista de las consultas realizadas.
--Las consultas pueden ser en consultorio o la realizacion de una practica medica. 
--De todas las consultas se sabe la fecha de realizacion, el profesional que la realiza, el costo, y la descripcion y el costo del material descartable en las pracicas medicas.

-- * Plantear diseño UML y de Base de Datos *
-- * Llevar a cabo en VB.NET con asp.net como front-end*
-- * Generar una herencia persona - médico - paciente * 

--No es necesario armar algo funcional. Se evaluara a nivel conceptual como se resuelve.

use master
go
Create Database ClinicalSystem
go
use ClinicalSystem
go
Create Table Personas(
	DNI int not null,
	Nombre varchar(200) not null,
	Activo bit not null default(1)
	Primary key (DNI)
)
go
Create Table Pacientes(
	NroHistoriaClinica bigint not null identity(1000,1),
	DNI int not null unique,
	Activo bit not null default(1)
	Primary key (NroHistoriaClinica),
	Foreign key (DNI) references Personas(DNI)
)
go
Create Table Medicos(
	NroMatricula int not null identity(100,1),
	DNI int not null unique,
	Activo bit not null default(1)
	Primary key (NroMatricula),
	Foreign key (DNI) references Personas(DNI)
)
go
Create Table Especialidades(
	IDEspecialidad int not null,
	Especialidad varchar(200),
	Primary key (IDEspecialidad)
)
go
Create Table Medicos_x_Especialidades(
	NroMatricula int not null,
	IDEspecialidad int not null,
	Primary key (NroMatricula, IDEspecialidad),
	Foreign key (NroMatricula) references Medicos(NroMatricula),
	Foreign key (IDEspecialidad) references Especialidades(IDEspecialidad)
)
go
Create Table TipoConsultas(
	IDTipoConsulta int not null,
	TipoConsulta varchar(200),
	Primary key (IDTipoConsulta)
)
go
Create Table ConsultasMedicas(
	IDConsulta bigint not null,
	NroHistoriaClinica bigint not null,
	IDTipoConsulta int not null,
	NroMatricula int not null,
	FechaRealizacion datetime not null default(GETDATE()),
	Costo decimal(16,2) not null,
	Descripcion varchar(2000),
	CostoMaterialDescartable decimal(16,2),
	Activo bit not null default(1),
	Primary key(IDConsulta),
	Foreign key (NroHistoriaClinica) references Pacientes(NroHistoriaClinica),
	Foreign key (IDTipoConsulta) references TipoConsultas(IDTipoConsulta),
	Foreign key (NroMatricula) references Medicos(NroMatricula)
)