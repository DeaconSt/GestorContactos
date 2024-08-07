using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;

using GestorContactos.Models;
/* Prueba de la clase Contacto
var persona = new Contacto()
{
    Id = 1,
    Nombre = "Juan",
    Telefono = "123456789",
    Email = "ola@gmail.com"
};

Console.WriteLine(persona); */

//serializacion de la clase contacto
[Serializable]

//crecion de la clase contacto
public class Contacto
{
    //atributos de la clase contacto encapsulados
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    //metodo para mostrar los datos de la clase contacto
    public override string ToString()
    {
        return $"Id: {Id}, Nombre: {Nombre}, Telefono: {Telefono}, Email: {Email}";
    }
}

