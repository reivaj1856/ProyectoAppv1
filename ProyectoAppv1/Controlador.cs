using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuNombreDeProyecto;

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
        public Precio GetPrecio(int id)
        {
            return baseDatos.getPrecio(id);
        }
        public Usuario getUsuario(string name)
        {
            return baseDatos.getUsuario(name);
        }
        public ArrayList getListClientes()
        {
            return baseDatos.getListClientes();
        }
        public void AgregarPedido(int clienteID, double cantidad, string detalle, double total) {
            baseDatos.AgregarPedido(clienteID,cantidad,detalle, total);
        }
        public Cliente getCliente(string nombre) {
            return baseDatos.getCliente(nombre);
        }
        public ArrayList getListPedidos()
        {
            return baseDatos.getListPedido();
        }
        public ArrayList getListPedidos(int id)
        {
            return baseDatos.getListPedido(id);
        }
        public void ActualizarDatos(int precioID, double costo, double descuentoF, double descuentoFrec)
        {
            baseDatos.ActualizarDatos(precioID,costo,descuentoF,descuentoFrec);
        }
        public void AgregarUsuarios(string cuenta, string nombre, string apellido, string telefono, string email, string contraseña, string pregunUnica)
        {
            baseDatos.AgregarUsuario(cuenta,nombre,apellido,telefono,email,contraseña,pregunUnica);
        }
        public void setCliente(string nombre, string apellido, string telefono, double ganancias, int pedidos, int clienteID)
        {
            baseDatos.setCliente(nombre, apellido, telefono,ganancias,pedidos,clienteID);
        }
        public void AgregarCliente(string nombre, string apellido, string telefono)
        {
            baseDatos.AgregarCliente(nombre,apellido,telefono);
        }
        public void eliminarCliente(int id)
        {
            baseDatos.eliminarCliente(id);
        }
        public Cliente GetClienteID(int id)
        {
            return baseDatos.getClienteID(id);
        }
        public Usuario GetUsuarioPre(string pregunta, string name)
        {
            return baseDatos.getUsuarioPreg(pregunta, name);
        }
    }
}
