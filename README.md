# 📒 Directorio de Contactos - Aplicación de Consola en C#

Aplicación de consola en C# que permite gestionar una lista de contactos. Incluye funcionalidades para agregar, listar, buscar por nombre y persistir los datos en un archivo JSON. Diseñada para practicar POO, listas, validaciones, manejo de archivos y buenas prácticas.

## 🚀 Características

- ✅ Agregar contactos con nombre, teléfono y correo electrónico.
- ✅ Validaciones robustas:
  - Nombre: solo letras y espacios, no vacío.
  - Teléfono: número positivo, no duplicado.
  - Correo: no vacío y debe contener "@".
- ✅ Listar todos los contactos almacenados.
- ✅ Buscar contacto por nombre (insensible a mayúsculas/minúsculas).
- ✅ Persistencia automática en archivo JSON (`directorio.json`).
- ✅ Menú interactivo con manejo de errores.
- ✅ Colores en consola para mejorar la experiencia visual.

## 🛠️ Tecnologías

- **Lenguaje:** C#
- **Plataforma:** .NET 6.0 o superior (compatible con .NET 8, 9, 10)
- **Compilador:** `dotnet`, Visual Studio, VS Code con extensión C#

## 📦 Requisitos previos

- [.NET SDK](https://dotnet.microsoft.com/download) (6.0 o superior)
- [Visual Studio Community](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/) con extensión C#

⁉️ ¿Cómo encontrar la carpeta donde se aloja el código?
- En carpeta llamada "Lista_Contactos" deslizas hacia abajo.
- El archivo llamado "Program.cs" das doble click y aparece el código.

## ▶️ Cómo ejecutar

### Opción 1: Con Visual Studio (recomendada)

1. Clona el repositorio o descarga el archivo `Program.cs`.
2. Crea un nuevo proyecto de **Aplicación de consola (.NET)**.
3. Reemplaza el contenido de `Program.cs` con el código proporcionado.
4. Presiona `F5` o haz clic en **Iniciar**.

### Opción 2: Con terminal / dotnet

```bash
Clona el repositorio (o descarga el archivo .cs):
git clone https://github.com/JuTevan25/Lista_Contactos.git

Autor: Juan Esteban Venegas Torres

Github: https://github.com/JuTevan25
git clone https://github.com/JuTevan25/DirectorioContactos.git
cd DirectorioContactos
dotnet run
