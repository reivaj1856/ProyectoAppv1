using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuNombreDeProyecto
{
    public class Precio
    {
        // Propiedades
        public int PrecioID { get; set; }
        public double Costo { get; set; }
        public string TipoTrabajo { get; set; }
        public double DescuentoF { get; set; }
        public double DescuentoFrec { get; set; }

        // Constructor sin parámetros
        public Precio() { }

        // Constructor con parámetros
        public Precio(int precioID, double costo, string tipoTrabajo, double descuentoF, double descuentoFrec)
        {
            PrecioID = precioID;
            Costo = costo;
            TipoTrabajo = tipoTrabajo;
            DescuentoF = descuentoF;
            DescuentoFrec = descuentoFrec;
        }
    }
}

