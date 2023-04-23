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
	IDConsulta bigint not null identity(100,1),
	NroHistoriaClinica bigint not null,
	IDTipoConsulta int not null,
	IDEspecialidad int not null,
	NroMatricula int not null,
	FechaRealizacion datetime not null default(GETDATE()),
	Costo decimal(16,2) not null,
	Descripcion varchar(2000) not null,
	CostoMaterialDescartable decimal(16,2) not null,
	Activo bit not null default(1),
	Primary key(IDConsulta),
	Foreign key (NroHistoriaClinica) references Pacientes(NroHistoriaClinica),
	Foreign key (IDTipoConsulta) references TipoConsultas(IDTipoConsulta),
	Foreign key (IDEspecialidad) references Especialidades(IDEspecialidad),
	Foreign key (NroMatricula) references Medicos(NroMatricula)
)
go
INSERT INTO TipoConsultas (IDTipoConsulta, TipoConsulta) VALUES (1, 'Consultorio');
INSERT INTO TipoConsultas (IDTipoConsulta, TipoConsulta) VALUES (2, 'Practica Medica');