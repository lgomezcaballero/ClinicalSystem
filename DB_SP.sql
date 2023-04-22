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
			Update Personas Set Activo = 0 Where DNI = @DNI
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