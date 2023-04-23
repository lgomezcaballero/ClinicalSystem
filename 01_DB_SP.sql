Use ClinicalSystem
go
Create Procedure SP_PatientList
As
Begin
	Select pa.NroHistoriaClinica ID, pe.DNI, pe.Nombre, pa.Activo
	From Pacientes pa Inner Join Personas pe on pa.DNI = pe.DNI
End
go
Create Procedure SP_AddPatient(
	@DNI int,
	@nombre varchar(200)
)
As
Begin
	Begin Try
		Begin Transaction
			Insert into Personas(DNI, Nombre) values (@DNI, @nombre)
			Insert into Pacientes(DNI) values (@DNI)
		Commit Transaction
	End Try
	Begin Catch
		RAISERROR('Error, no se pudo agregar al paciente', 16, 1)
		Rollback Transaction
	End Catch
End
go
Create Procedure SP_ModifyPatient(
	@DNI int,
	@nombre varchar(200)
)
As
Begin
	Begin Try
		Begin Transaction
			Update Personas Set Nombre = @nombre Where DNI = @DNI
		Commit Transaction
	End Try 
	Begin Catch
		RAISERROR('Error, no se pudo modificar el paciente', 16, 1)
		Rollback Transaction
	End Catch
End
go
Create Procedure SP_DeletePatient(
	@DNI int
)
As
Begin
	Begin Try
		Begin Transaction
			Update Pacientes Set Activo = 0 Where DNI = @DNI
		Commit Transaction
	End Try
	Begin Catch
		RAISERROR('Error, no se pudo eliminar el paciente', 16, 1)
		Rollback Transaction
	End Catch
End
go
Create Procedure SP_GetPatient(
	@DNI int
)
As
Begin
	select pa.NroHistoriaClinica ID, pa.DNI, pe.Nombre
	From Pacientes pa inner join Personas pe on pa.DNI = pe.DNI
	Where pa.DNI = @DNI
End
go
-----------------------------------------------------------------
Create Procedure SP_DoctorList
As
Begin
	Select me.NroMatricula ID, pe.DNI, pe.Nombre, me.Activo
	From Medicos me Inner Join Personas pe on me.DNI = pe.DNI
End
go
Create Procedure SP_AddDoctor(
	@DNI int,
	@nombre varchar(200)
)
As
Begin
	Begin Try
		Begin Transaction
			Insert into Personas(DNI, Nombre) values (@DNI, @nombre)
			Insert into Medicos(DNI) values (@DNI)
		Commit Transaction
	End Try
	Begin Catch
		RAISERROR('Error, no se pudo agregar al medico', 16, 1)
		Rollback Transaction
	End Catch
End
go
Create Procedure SP_ModifyDoctor(
	@ID int,
	@DNI int,
	@nombre varchar(200)
)
As
Begin
	Begin Try
		Begin Transaction
			Update Personas Set Nombre = @nombre Where DNI = @DNI
		Commit Transaction
	End Try 
	Begin Catch
		RAISERROR('Error, no se pudo modificar el medico', 16, 1)
		Rollback Transaction
	End Catch
End
go
Create Procedure SP_DeleteDoctor(
	@ID int
)
As
Begin
	Begin Try
		Begin Transaction
			Update Medicos Set Activo = 0 Where NroMatricula = @ID
		Commit Transaction
	End Try
	Begin Catch
		RAISERROR('Error, no se pudo eliminar el medico', 16, 1)
		Rollback Transaction
	End Catch
End
go
Create Procedure SP_GetDoctor(
	@ID int
)
As
Begin
	select me.NroMatricula ID, me.DNI, pe.Nombre, me.Activo
	From Medicos me inner join Personas pe on me.DNI = pe.DNI
	Where me.NroMatricula = @ID
End
go
-----------------------------------------------------------------
Create Procedure SP_SpecialtyList
As
Begin
	Select IDEspecialidad ID, Especialidad From Especialidades
End
go
Create Procedure SP_GetSpecialty(
	@ID int
)
As
Begin
	Select IDEspecialidad ID, Especialidad From Especialidades Where IDEspecialidad = @ID
End
go
-----------------------------------------------------------------
Create Procedure SP_QueryTypeList
As
Begin
	Select IDTipoConsulta ID, TipoConsulta From TipoConsultas
End
go
Create Procedure SP_GetQueryType(
	@ID int
)
As
Begin
	Select IDTipoConsulta ID, TipoConsulta From TipoConsultas Where IDTipoConsulta = @ID
End
go
-----------------------------------------------------------------
Create Procedure SP_MedicalConsultationList
As
Begin
	Select IDConsulta ID, NroHistoriaClinica, IDTipoConsulta, IDEspecialidad, NroMatricula, 
	FechaRealizacion, Costo, Descripcion, CostoMaterialDescartable, Activo
	From ConsultasMedicas
End
go
Create Procedure SP_GetMedicalConsultationByPatient(
	@NroHistoriaClinica bigint
)
As
Begin
	Select IDConsulta ID, NroHistoriaClinica, IDTipoConsulta, IDEspecialidad, NroMatricula, 
	FechaRealizacion, Costo, Descripcion, CostoMaterialDescartable, Activo
	From ConsultasMedicas where NroHistoriaClinica = @NroHistoriaClinica
End
go
Create Procedure SP_GetMedicalConsultation(
	@ID bigint
)
As
Begin
	Select IDConsulta ID, NroHistoriaClinica, IDTipoConsulta, IDEspecialidad, NroMatricula, 
	FechaRealizacion, Costo, Descripcion, CostoMaterialDescartable, Activo
	From ConsultasMedicas where IDConsulta = @ID
End
go
Create Procedure SP_AddMedicalConsultation(
	@NroHistoriaClinica bigint,
	@IDTipoConsulta int,
	@IDEspecialidad int,
	@NroMatricula int,
	@FechaRealizacion datetime,
	@Costo decimal(16,2),
	@Descripcion varchar(2000),
	@CostoMaterialDescartable decimal(16,2)
)
As
Begin
	Begin Try
		Begin Transaction
			Insert into ConsultasMedicas (NroHistoriaClinica, IDTipoConsulta, IDEspecialidad, NroMatricula, FechaRealizacion, Costo, Descripcion, CostoMaterialDescartable)
			values (@NroHistoriaClinica, @IDTipoConsulta, @IDEspecialidad, @NroMatricula, @FechaRealizacion, @Costo, @Descripcion, @CostoMaterialDescartable)
		Commit Transaction
	End Try
	Begin Catch
		RAISERROR('Error, no se pudo agregar la consulta', 16, 1)
		Rollback Transaction
	End Catch
End
go
Create Procedure SP_ModifyMedicalConsultation(
	@IDConsulta bigint,
	@FechaRealizacion datetime,
	@Descripcion varchar(2000)
)
As
Begin
	Begin Try
		Begin Transaction
			Update ConsultasMedicas Set FechaRealizacion = @FechaRealizacion, Descripcion = @Descripcion
			Where IDConsulta = @IDConsulta
		Commit Transaction
	End Try 
	Begin Catch
		RAISERROR('Error, no se pudo modificar el medico', 16, 1)
		Rollback Transaction
	End Catch
End
go
Create Procedure SP_DeletemedicalConsultation(
	@ID int
)
As
Begin
	Begin Try
		Begin Transaction
			Update Medicos Set Activo = 0 Where NroMatricula = @ID
		Commit Transaction
	End Try
	Begin Catch
		RAISERROR('Error, no se pudo eliminar el medico', 16, 1)
		Rollback Transaction
	End Catch
End
go