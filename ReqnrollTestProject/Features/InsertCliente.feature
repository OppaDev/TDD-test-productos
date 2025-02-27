Feature: InsertCliente

Insertar un nuevo cliente al sistema

@tag1
Scenario: Usuario ingresa datos validos
	Given El usuario se necuentra en la pagina Cliente
	And El usuario da clic en el boton nuevo Cliente
	When El usuario ingresa los siguientes datos
		| Cedula     | Apellidos | Nombres | FechaNacimiento  | Mail                | Telefono  | Direccion | Estado |
		| 0402084040 | Muñoz     | Jose    | 1999-12-12T12:00 | juan_test@email.com | 098765432 | Sangolqui | 1      |
	And Hacer clic en el boton crear
	Then el usuario se queda en la pagina agregar cliente