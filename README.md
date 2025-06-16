# Ape6 (ADONET)# Ape6 (ADONET)

## 📘 Descripción
Este proyecto muestra una implementación práctica de ADO.NET en C#, junto con una interfaz de usuario simple desarrollada en HTML, CSS y JavaScript. Permite conectarse a una base de datos SQL Server, realizar operaciones CRUD (crear, leer, actualizar, eliminar) y reflejar los resultados en el frontend.

---

## 🛠️ Características
- Conexión a base de datos SQL Server utilizando ADO.NET.
- Operaciones CRUD básicas con ejemplos didácticos.
- Interfaz web básica (HTML/JS/CSS) para interactuar con el backend.
- Código fuente organizado y comentado para un mejor aprendizaje.

---

## 🧩 Estructura del proyecto

Ape6/


├── ADONET.sln # Solución principal en Visual Studio


├── ADONET/ # Proyecto C# con lógica ADO.NET


│ ├── bin/


│ └── obj/


├── index.html # Interfaz web principal


├── script.js # Lógica de interacción de frontend


└── estilos.css # Estilos de la interfaz  


---

## 🚀 Requisitos previos
- Windows o sistema compatible con .NET Framework / .NET Core.
- Visual Studio (o equivalente) para compilar el proyecto C#.
- SQL Server (local o remoto) con una base de datos configurada.
- Navegador web moderno para visualizar la UI.

---

## 🔧 Instalación y uso

1. Clona el repositorio:
   ```bash
   git clone https://github.com/Ismael283-A/Ape6.git

Abre ADONET.slncon Visual Studio.

Ajusta la cadena de conexión en el código C# ( SqlConnection) con tus credenciales y nombre de base de datos.

Compila y ejecuta el servicio o aplicación (por ejemplo, una API o aplicación de consola que exponga endpoints HTTP).

Abra index.htmlen su navegador (idealmente ejecutado desde un servidor local, ej. Live Server de VSCode).

Interactúa con la interfaz para realizar operaciones contra la base de datos.

##🎯 Uso del frontend

index.html : Página principal.

script.js :

Envía peticiones al backend para obtener o modificar datos.

Inserta dinámicamente resultados en la página.

estilos.css : Mejora visual básica, personalízala según tus necesidades.



