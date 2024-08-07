using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GestorContactos.Models;
using System.Text.Json;

namespace GestorContactos.Models
{
    // Clase gestor de contactos
    public class GestorDeContactos
    {
        // Lista de contactos privada
        public List<Contacto> contactos;

        // Constructor de la clase GestorDeContactos
        public GestorDeContactos()
        { 
            // Inicializa la lista de contactos en la variable contactos
            contactos = new List<Contacto>();
        }

        // Metodo para agregar un contacto a la lista de contactos
        public void AgregarContacto(Contacto contacto)
        {
            // Agrega el contacto a la lista de contactos
            contactos.Add(contacto);
            
        }

        // Metodo para buscar un contacto por nombre (es el parametro que recibe)
        public Contacto BuscarContactoPorNombre(string nombre)
        {
            // Busca el contacto en la lista de contactos por nombre
            return contactos.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        }

        // Metodo para buscar un contacto por telefono (es el parametro que recibe)
        public Contacto BuscarContactoPorTelefono(string telefono)
        {
            // Busca el contacto en la lista de contactos por telefono
            return contactos.Find(c => c.Telefono.Equals(telefono));
        }

        // Metodo para listar los contactos
        public List<Contacto> ListarContactos()
        {
            // Retorna la lista de contactos
            return contactos;
        }

        // Metodo para eliminar un contacto por id (es el parametro que recibe)
        public void EliminarContacto(int id)
        {
            // Elimina el contacto de la lista de contactos por id
            contactos.RemoveAll(c => c.Id == id);
        }   

        // Metodo para guardar los contactos en un archivo
        public void GuardarContactos(string archivo)
        {   
            // se crea un objeto de la clase JsonSerializerOptions con la propiedad WriteIndented en true para que el JSON se guarde con formato indentado
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            // Serializa la lista de contactos en formato JSON con formato indentado
            string json = JsonSerializer.Serialize(contactos, opciones); 
            // Escribe el JSON en el archivo
            File.WriteAllText(archivo, json);
        }

        // Metodo para cargar los contactos de un archivo
        public void CargarContactos(string archivo)
        {
            // Si el archivo existe
            if (File.Exists(archivo))
            {
                // Lee el JSON del archivo
                string json = File.ReadAllText(archivo);
                // Deserializa el JSON en la lista de contactos
                contactos = JsonSerializer.Deserialize<List<Contacto>>(json);
            }
        }
    }
}

