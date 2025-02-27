Feature: LogIn

Login hacia el sistema de automation exercises Login

@tag1
Scenario: Usuario ingresa credenciales incorrectas
	Given que el usuario esta en la pagina del login
	When ingresa un correo "testuser@mail.com" y la contraseña "passw123"
	And hacer clic en el boton de inicio de sesión
	Then deveria ver un mensaje de error
