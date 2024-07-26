using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppv1
{
    using System;

    public class Usuario
    {
        // Atributos de la clase
        public int UsuarioID { get; private set; }
        public string Cuenta { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Telefono { get; private set; }
        public string Email { get; private set; }
        public string PUni { get; private set; }
        public string Contraseña { get; private set; }

        // Constructor
        public Usuario(int usuarioID,string cuenta, string nombre, string apellido,string telefono, string email, string contraseña, string pUni)
        {
            UsuarioID = usuarioID;
            Cuenta = cuenta;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Contraseña = contraseña;
            PUni = pUni;
        }

        // Métodos para cambiar el estado de los atributos
        public void CambiarNombre(string nuevoNombre)
        {
            if (!string.IsNullOrEmpty(nuevoNombre))
            {
                Nombre = nuevoNombre;
            }
            else
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
        }

        public void CambiarApellido(string nuevoApellido)
        {
            if (!string.IsNullOrEmpty(nuevoApellido))
            {
                Apellido = nuevoApellido;
            }
            else
            {
                throw new ArgumentException("El apellido no puede estar vacío.");
            }
        }

        public void CambiarEmail(string nuevoEmail)
        {
            if (!string.IsNullOrEmpty(nuevoEmail))
            {
                Email = nuevoEmail;
            }
            else
            {
                throw new ArgumentException("El email no puede estar vacío.");
            }
        }
        public void CambiarContraseña(string nuevoContraseña)
        {
            if (!string.IsNullOrEmpty(nuevoContraseña))
            {
                Email = nuevoContraseña;
            }
            else
            {
                throw new ArgumentException("La contraseña no puede estar vacío.");
            }
        }
    }

}
