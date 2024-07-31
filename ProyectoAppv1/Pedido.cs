using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppv1
{
    public class Pedido
    {
        // Propiedades
        public int PedidoID { get; set; }
        public int ClienteID { get; set; }
        public double Cantidad { get; set; }
        public string Detalle { get; set; }
        public double Total { get; set; }

        // Constructor sin parámetros
        public Pedido() { }

        // Constructor con parámetros
        public Pedido(int pedidoID, int clienteID, double cantidad, string detalle, double total)
        {
            PedidoID = pedidoID;
            ClienteID = clienteID;
            Cantidad = cantidad;
            Detalle = detalle;
            Total = total;
        }
    }
}
