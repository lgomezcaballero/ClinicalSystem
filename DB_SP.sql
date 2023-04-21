Use ClinicalSystem
go
Create Procedure SP_PatientList
As
Begin
	Select pa.NroHistoriaClinica ID, pe.DNI, pe.Nombre
	From Pacientes pa Inner Join Personas pe on pa.DNI = pe.DNI
End
go
Create Procedure SP_AddPatient(
	@ID bigint,
	@DNI int,
	@nombre varchar(200)
)
As
Begin
	Begin Try
		Begin Transaction
			Insert into Personas(DNI, Nombre) values (@DNI, @nombre)
			Insert into Pacientes(NroHistoriaClinica, DNI) values (@ID, @DNI)
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