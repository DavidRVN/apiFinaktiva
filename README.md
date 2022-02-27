# apiFinaktiva

Hola
El proyecto actualmente tiene las siguientes capas

Data: Donde está contenido el context a la base de datos.
Models: Contiene las clases modelos del api
Helpers: Donde se crea y se valida el usuario y contraseña y se validan encriptan
Controllers: contiene todos los controladores del Api y el método para devolver y validar el token de inicio de sesión

Para ejecutar el api, se debe ejecutar también el siguiente script de base de dato y cambiar el string de conexión.

El script se encuentra en la raíz del respositorio

para cambiar de usuario o de rol se debe comentar la siguiente línea de código que se encuentra en el archivo LoginController línea 63 y 64 así se podrá validar los accesos.


