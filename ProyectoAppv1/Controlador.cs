using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppv1
{
    public class Controlador
    {
        private Modelo baseDatos;
        public Controlador() { 
            baseDatos= new Modelo();
        }
        public bool IniciarSesion (string name,string pass){ 
            bool autenticador=false;
            Usuario us = baseDatos.getUsuario(name);
            if (us!=null)
            {
                if (us.Contraseña==pass) { 
                    autenticador = true;
                }
            }
            return autenticador;
        }
    }
}
