using System;
using System.Security.Cryptography.X509Certificates;
using GestorContactos.Models;
/*
 * PRUEBA TECNICA DE DESARROLLADOR DE SOFTWARE JR - DIGITAL SOLUTIONS 
 * AUTOR: JUAN FELIPE GORDILLO ORTIZ
 * FECHA DE DESARROLLO: 17/06/2024
 * ULTIMA ACTUALIZACION: 17/06/2024 - 18:47
 * ENUNCIADO: 
    La prueba requiere crear una aplicación de consola en C# para gestionar contactos, permitiendo agregar, buscar (por nombre o teléfono), listar, eliminar, guardar y cargar contactos desde un archivo (Se opto por un archivo .Json).
 */



// Clase de interfaz de usuario
class Ui
{
    static void Main(string[] args)
    {
        // Creacion de un objeto de la clase GestorDeContactos
        GestorDeContactos gestor = new GestorDeContactos();
        // Creacion de un archivo de contactos.json
        string archivo = "C:\\Users\\ortiz\\source\\repos\\GestorContactos\\GestorContactos\\contactos.json"; //ruta del archivo de contactos en formato json
        // Carga los contactos del archivo al iniciar la aplicacion como se indico en el enunciado de la prueba
            gestor.CargarContactos(archivo);
        
            while (true)
            {   // Menu de de la interfaz de usuario
                Console.Clear();
                Console.WriteLine("Menú de Contactos:");
                
                Console.WriteLine("1. Agregar contacto");
                Console.WriteLine("2. Buscar contacto");
                Console.WriteLine("3. Listar contactos");
                Console.WriteLine("4. Eliminar contacto");
                Console.WriteLine("5. Guardar contactos");
                Console.WriteLine("6. Cargar contactos");
                Console.WriteLine("7. Salir");

                int opcion = LeerOpcionMenu();

                switch (opcion)
                {
                    case 1:
                        AgregarContacto(gestor);
                        break;
                    case 2:
                        BuscarContacto(gestor);
                        break;
                    case 3:
                        ListarContactos(gestor);
                        break;
                    case 4:
                        EliminarContacto(gestor);
                        break;
                    case 5:
                        gestor.GuardarContactos(archivo);
                        break;
                    case 6:
                        gestor.CargarContactos(archivo);
                        break;
                    case 7:
                        gestor.GuardarContactos(archivo);
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
    }
    // Metodo para leer la opcion del menu y validar que sea un numero entre 1 y 7
    static int LeerOpcionMenu()
    {
        while (true)
        {
            Console.Write("Seleccione una opción: ");
            string entrada = Console.ReadLine();
            // se pasa la entrada a un entero y su valor se pasa a la variable opcion y se valida que sea un numero entre 1 y 7
            if (int.TryParse(entrada, out int opcion) && opcion >= 1 && opcion <= 7)
            {
                return opcion;
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número entre 1 y 7.");
            }
        }
    }
    // Metodo para agregar un contacto
    static void AgregarContacto(GestorDeContactos gestor)
    {
       
        try
        {
            Console.Write("Id: ");
            int id = LeerEntero();

            Console.Write("Nombre: ");
            string nombre = LeerCadenaNoVacia();

            Console.Write("Telefono: ");
            string telefono = LeerCadenaNoVacia();

            Console.Write("Email: ");
            string email = LeerCadenaNoVacia();
            // se crea un objeto de la clase contacto con los datos ingresados
            Contacto contacto = new Contacto { Id = id, Nombre = nombre, Telefono = telefono, Email = email };
            // se valida que el id del contacto no exista en la lista de contactos
            if (gestor.contactos.Any(c => c.Id == contacto.Id))
                {
                    Console.WriteLine($"El id: {contacto.Id} de contacto ya existe, porfavor intente con otro.");
                }
            else
            {
                    // se agrega el contacto a la lista de contactos
                    gestor.AgregarContacto(contacto);
                    Console.WriteLine("Contacto agregado exitosamente.");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al agregar contacto: {ex.Message}");
        }
        Console.WriteLine("Presione alguna tecla para continuar.");
        Console.ReadKey();
    }
    // Metodo para buscar un contacto
    static void BuscarContacto(GestorDeContactos gestor)
    {
        try
        {
            Console.WriteLine("Buscar por: 1. Nombre 2. Telefono");
            int opcion = LeerOpcionBusqueda();

            Contacto contacto = null;
            if (opcion == 1)
            {
                Console.Write("Nombre: ");
                string nombre = LeerCadenaNoVacia();
                contacto = gestor.BuscarContactoPorNombre(nombre);
            }
            else if (opcion == 2)
            {
                Console.Write("Telefono: ");
                string telefono = LeerCadenaNoVacia();
                contacto = gestor.BuscarContactoPorTelefono(telefono);
            }

            if (contacto != null)
            {
                Console.WriteLine(contacto);
            }
            else
            {
                Console.WriteLine("Contacto no encontrado, intente nuevamente.");
               //intento de uso de recursividad BuscarContacto(gestor);
            }
           

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al buscar contacto: {ex.Message}");
        }
        Console.WriteLine("Presione alguna tecla para continuar.");
        Console.ReadKey();
    }
    // Metodo para listar los contactos
    static void ListarContactos(GestorDeContactos gestor)
    {
        try
        {
            var contactos = gestor.ListarContactos();
            // se recorre la lista de contactos y se imprime cada contacto
            Console.WriteLine("-----Lista de contactos-----");
            foreach (var contacto in contactos)
            {
                Console.WriteLine(contacto);
            }
            Console.WriteLine("Presione alguna tecla para continuar.");
            
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al listar contactos: {ex.Message}");
        }
        Console.ReadKey();
        
    }
    // Metodo para eliminar un contacto
    static void EliminarContacto(GestorDeContactos gestor)
    {
        try
        {
            Console.Write("Id del contacto a eliminar: ");
            int id = LeerEntero();
            // se elimina el contacto de la lista de contactos con el metodo EliminarContacto de la clase GestorDeContactos
            gestor.EliminarContacto(id);
            Console.WriteLine("Contacto eliminado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar contacto: {ex.Message}");
        }
        Console.WriteLine("Presione alguna tecla para continuar.");
        Console.ReadKey();
    }

    static int LeerOpcionBusqueda()
    {
        while (true)
        {
            string entrada = Console.ReadLine();
            // se pasa la entrada a un entero y su valor se pasa a la variable opcion y se valida que sea un numero entre 1 y 2
            if (int.TryParse(entrada, out int opcion) && (opcion == 1 || opcion == 2))
            {
                return opcion;
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese 1 o 2.");
            }
        }
    }

    static int LeerEntero()
    {
        while (true)
        {
            string entrada = Console.ReadLine();
            //la entrada se intenta pasar a un entero y si es correcto se pasa a la variable valor
            if (int.TryParse(entrada, out int valor))
            {
                // se retorna valor
                return valor;
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
            }
        }
    }
    // metodo para validar que la entrada no este vacia
    static string LeerCadenaNoVacia()
    {
        while (true)
        {
            string entrada = Console.ReadLine();
            // si la entrada no esta vacia o no tiene un valor nulo
            if (!string.IsNullOrWhiteSpace(entrada))
            {
                return entrada;
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese una cadena no vacía.");
            }
        }
    }
}
