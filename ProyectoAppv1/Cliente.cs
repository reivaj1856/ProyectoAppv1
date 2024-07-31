using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppv1
{
    public class Cliente
    {
        // Propiedades
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double Ganancias { get; set; }  // Cambiado de float a double
        public int Pedidos { get; set; }
        public string Telefono { get; set; }

        // Constructor sin parámetros
        public Cliente() { }

        // Constructor con parámetros
        public Cliente(int clienteID, string nombre, string apellido, double ganancias, int pedidos, string telefono)
        {
            ClienteID = clienteID;
            Nombre = nombre;
            Apellido = apellido;
            Ganancias = ganancias;
            Pedidos = pedidos;
            Telefono = telefono;
        }
    }
}
