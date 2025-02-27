Feature: Edit

Proceso de Realizar Testing BDD en Edit

@tag1
Scenario: Edit Data
	Given Mostrar la informacion a editar en el formulario
		| Cedula     | Apellidos | Nombres | FechaNacimiento  | Mail             | Telefono | Direccion | Estado |
		| 0402084040 | Muñoz     | Jose    | 1999-12-12T12:00 | ejemplo@mail.com | 09876543 | Quito     | 1      |
	When Edicion de los datos del cliente en la BDD
		| Cedula     | Apellidos | Nombres | FechaNacimiento  | Mail            | Telefono   | Direccion | Estado |
		| 0402084040 | Muñoz     | Jose    | 1999-12-12T12:00 | cambio@mail.com | 0987451236 | Sangolqui | 1      |
	Then Resultado de la edicion en la BDD
		| Cedula     | Apellidos | Nombres | FechaNacimiento  | Mail            | Telefono   | Direccion | Estado |
		| 0402084040 | Muñoz     | Jose    | 1999-12-12T12:00 | cambio@mail.com | 0987451236 | Sangolqui | 1      |
