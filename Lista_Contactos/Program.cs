using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Lista_Contactos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contacto> contactos = new List<Contacto>();
            int opcion = 0;


            if (File.Exists("directorio.json"))
            {
                string json = File.ReadAllText("directorio.json");
                Contacto[] guardados = JsonSerializer.Deserialize<Contacto[]>(json);
                if (guardados != null)
                {
                    contactos.AddRange(guardados);
                }

            }

            Console.WriteLine("Bienvenido al directorio de contactos");
            Console.WriteLine("A continuación observe el menú de opciones: ");
            Console.WriteLine("");
            do
            {
                Console.WriteLine("==== MENÚ DE OPCIONES ====");
                Console.WriteLine("1.Añadir contacto");
                Console.WriteLine("2.Ver contactos");
                Console.WriteLine("3.Buscar por nombre");
                Console.WriteLine("4. Eliminar contacto");
                Console.WriteLine("5.Salir");
                Console.WriteLine("");
                Console.Write("Opción:");

                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("La opción ingresada no es válida. Por favor, ingresa un número del 1 al 4.");
                    Console.ResetColor();
                    Console.WriteLine("");
                }
                Console.WriteLine("");

                switch (opcion)
                {
                    case 1:
                        long telefono = 0;
                        string nombre = "", email = "";
                        bool verificarTelefono = true;

                        Console.WriteLine("===== AÑADIR CONTACTO =====");
                        Console.WriteLine("Por favor, ingresa el nombre del contacto: ");

                        nombre = Console.ReadLine();

                        while (string.IsNullOrWhiteSpace(nombre) || !nombre.All(c => char.IsLetter(c) || c == ' '))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Ingrese un nombre válido (solo letras y espacios, no vacío).");
                            Console.ResetColor();
                            nombre = Console.ReadLine();
                            Console.ResetColor();
                        }

                        Console.WriteLine("");
                        Console.WriteLine("===== NÚMERO DE TELÉFONO =====");
                        Console.WriteLine("Por favor, ingresa el número de teléfono del contacto: ");

                        while (true)
                        {
                            if (!long.TryParse(Console.ReadLine(), out telefono) || telefono <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Valor inválido. Ingrese un número positivo: ");
                                Console.ResetColor();
                                continue;

                            }


                            if (contactos.Exists(c => c.telefono == telefono))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El número de teléfono ya existe. Ingrese un número diferente: ");
                                Console.ResetColor();
                                continue;


                            }

                            break;
                        }
                        Console.WriteLine("");


                        Console.WriteLine("===== CORREO ELECTRÓNICO =====");
                        Console.WriteLine("Por favor, ingresa el correo electrónico del contacto: ");

                        email = Console.ReadLine();


                        while (string.IsNullOrEmpty(email) || !email.Contains("@"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El correo electrónico no es válido.");
                            email = Console.ReadLine();
                            Console.ResetColor();
                            Console.WriteLine("");
                        }

                        contactos.Add(new Contacto(nombre, telefono, email));

                        string json = JsonSerializer.Serialize(contactos);
                        File.WriteAllText("directorio.json", json);

                        Console.WriteLine("");
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Contacto añadido correctamente.");
                        Console.WriteLine("");
                        Console.ResetColor();

                        break;

                    case 2:


                        Console.WriteLine("======================");
                        Console.WriteLine("LISTA DE CONTACTOS");
                        if (contactos.Count > 0)
                        {
                            foreach (Contacto c in contactos)
                            {
                                c.MostrarContacto();
                                Console.WriteLine("");
                                Console.WriteLine("=========================");
                                Console.WriteLine("");
                                Console.Clear();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("No hay contactos en la lista.");
                            Console.ResetColor();
                            Console.WriteLine("");
                        }

                        break;

                    case 3:
                        Console.WriteLine("Búsqueda por nombre: ");
                        string nombreBusqueda = Console.ReadLine();

                        var contactoEncontrado = contactos.Find(c => c.nombre.Equals(nombreBusqueda, StringComparison.OrdinalIgnoreCase));

                        if (contactoEncontrado != null)
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.White;
                            contactoEncontrado.MostrarContacto();
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Contacto no encontrado.");
                            Console.ResetColor();
                            Console.Clear();
                            Console.WriteLine("");
                        }
                        break;

                    case 4:
                        {
                            Console.WriteLine("===== ELIMINAR CONTACTO =====");
                            Console.WriteLine("Escribe el nombre del contacto a eliminar.");
                            nombre = Console.ReadLine();

                            while (string.IsNullOrWhiteSpace(nombre) || !nombre.All(c => char.IsLetter(c) || c == ' '))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Ingrese un nombre válido (solo letras y espacios, no vacío).");
                                Console.ResetColor();
                                nombre = Console.ReadLine();
                                Console.ResetColor();
                            }

                            if (contactos.Exists(n => n.nombre == nombre))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                contactos.RemoveAll(c => string.Equals(c.nombre?.Trim(), nombre.Trim(), StringComparison.OrdinalIgnoreCase));
                                Console.WriteLine("Contacto eliminado correctamente.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Contacto no encontrado.");
                                Console.ResetColor();
                                Console.Clear();
                            }
                        }
                        break;

                    default:

                        Console.WriteLine("Opción no válida. Por favor, ingresa un número del 1 al 5.");
                        break;

                }

            } while (opcion != 5);


            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Muchas gracias por usar el directorio telefónico.");
            Console.WriteLine("Hasta la próxima.");
        }


    }


    class Contacto
    {
        public string nombre { get; set; }
        public long telefono { get; set; }

        public string email { get; set; }

        public Contacto(string nombre, long telefono, string email)
        {
            this.nombre = nombre;
            this.telefono = telefono >= 0 ? telefono : 0;
            this.email = email;
        }

        public void MostrarContacto()
        {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Teléfono: " + telefono);
            Console.WriteLine("Correo electrónico: " + email);

        }


    }
}
