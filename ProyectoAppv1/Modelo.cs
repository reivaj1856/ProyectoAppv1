
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAppv1
{
    public class Modelo
    {
        SqlConnection conex;
        string cadenaConexion;
        public Modelo() {
           conex = new SqlConnection();

            //cadenaConexion = "Data Source= DESKTOP-VSFDTI4\\SQLSERVEREXPRESS; Initial Catalog=Innovacion; Integrated Security = True";
            //cadenaConexion = "Data Source= DESKTOP-D46MFDH\\SQLEXPRESS; Initial Catalog=Innovacion; Integrated Security = True";
            cadenaConexion = "Data Source= CROMER; Initial Catalog=Innovacion; Integrated Security = True";
        }
        public Usuario getUsuario(string name)
        {
            Usuario us = null;
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "SELECT Id, Cuenta , Nombre, Apellido, Telefono, Email, Contraseña, PreguntaUnica FROM Usuarios";

                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string cuenta = reader.GetString(1);
                       
                        if (name == cuenta)
                        {
                            int usuarioID = reader.GetInt32(0);
                            string nombre = reader.GetString(2);
                            string apellido = reader.GetString(3);
                            string telefono = reader.GetString(4);
                            string email = reader.GetString(5);
                            string contraseña = reader.GetString(6);
                            string pUnica = reader.GetString(7);
                            us = new Usuario(usuarioID,cuenta, nombre, apellido,telefono, email, contraseña, pUnica);
                        }
                    }
                }
                conex.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

            return us;
        }
    }
}
