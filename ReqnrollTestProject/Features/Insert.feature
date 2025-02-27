Feature: Insert

Proceso de realizar Testing BDD en Insert

@tag1
Scenario: Insert Data
	Given Completar la informacion en el formulario
		| Cedula     | Apellidos | Nombres | FechaNacimiento  | Mail           | Telefono  | Direccion | Estado |
		| 0402084040 | Muñoz     | Jose    | 1999-12-12T12:00 | juan@gmail.com | 098765432 | Quito     | 1      |
	When Registro del Cliente en la BDD
		| Cedula     | Apellidos | Nombres | FechaNacimiento  | Mail           | Telefono  | Direccion | Estado |
		| 0402084040 | Muñoz     | Jose    | 1999-12-12T12:00 | juan@gmail.com | 098765432 | Quito     | 1      |
	Then El resultado del rgistro en la BDD
		| Cedula     | Apellidos | Nombres | FechaNacimiento  | Mail           | Telefono  | Direccion | Estado |
		| 0402084040 | Muñoz     | Jose    | 1999-12-12T12:00 | juan@gmail.com | 098765432 | Quito     | 1      |
