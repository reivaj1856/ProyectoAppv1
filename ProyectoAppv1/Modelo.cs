
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuNombreDeProyecto;

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
        public Usuario getUsuarioPreg(string pregunta,string name)
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
                        string pUnica = reader.GetString(7);
                        if (cuenta == name)
                        {
                            int usuarioID = reader.GetInt32(0);
                            string nombre = reader.GetString(2);
                            string apellido = reader.GetString(3);
                            string telefono = reader.GetString(4);
                            string email = reader.GetString(5);
                            string contraseña = reader.GetString(6);

                            if (pUnica==pregunta)
                            {
                                us = new Usuario(usuarioID, cuenta, nombre, apellido, telefono, email, contraseña, pUnica);
                            }
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
        public void AgregarUsuario(string cuenta, string nombre, string apellido,string telefono, string email, string contraseña, string pregunUnica)
        {
            using (SqlConnection conex = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conex.Open();
                    string query = "INSERT INTO Usuarios (Cuenta, Nombre, Apellido, Telefono, Email, Contraseña, preguntaUnica) " +
                                   "VALUES ( @Cuenta, @Nombre, @Apellido, @Telefono, @Email, @Contraseña, @preguntaUnica)";

                    using (SqlCommand command = new SqlCommand(query, conex))
                    {
                        // Agregar parámetros para evitar inyecciones SQL
                        command.Parameters.AddWithValue("@Cuenta", cuenta);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Apellido", apellido);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.Parameters.AddWithValue("@Email", email); 
                        command.Parameters.AddWithValue("@Contraseña", contraseña);
                        command.Parameters.AddWithValue("@preguntaUnica", pregunUnica);
                        

                        // Ejecutar la consulta de inserción
                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Usuario agregado exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se agregó ningún usuario.");
                        }
                    }
                    conex.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + e.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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
        public Precio getPrecio(int id)
        {
            Precio precio = null;
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "SELECT PrecioID, Costo , TipoTrabajo, DescuentoF, DescuentoFrec FROM Precio";
                //INSERT INTO Precio (Costo, TipoTrabajo, DescuentoF,DescuentoFrec)
                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int precioID = reader.GetInt32(0);

                        if (id == precioID)
                        {
                            double costo=reader.GetDouble(1);
                            string tipoTrabajo=reader.GetString(2);
                            double descuentoF =reader.GetDouble(3);
                            double descuentoFrec =reader.GetDouble(4);
                            precio = new Precio(precioID,costo,tipoTrabajo,descuentoF,descuentoFrec);    
                        }
                    }
                }
                conex.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

            return precio;
        }
        public void AgregarCliente(string nombre, string apellido, string telefono)
        {
            using (SqlConnection conex = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conex.Open();
                    string query = "INSERT INTO Cliente (Nombre, apellido,Ganancias,Pedidos, telefono) " +
                                   "VALUES ( @Nombre, @Apellido,@Ganancias,@Pedidos, @telefono)";

                    using (SqlCommand command = new SqlCommand(query, conex))
                    {
                        // Agregar parámetros para evitar inyecciones SQL
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@apellido", apellido);
                        command.Parameters.AddWithValue("@Ganancias", 0);
                        command.Parameters.AddWithValue("@Pedidos", 0);
                        command.Parameters.AddWithValue("@telefono", telefono);


                        // Ejecutar la consulta de inserción
                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Usuario agregado exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se agregó ningún usuario.");
                        }
                    }
                    conex.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + e.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        public Cliente getCliente(string name) {
            Cliente cliente = null;
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "SELECT ClienteID, Nombre, apellido, Ganancias, Pedidos, telefono FROM Cliente";
                //INSERT INTO Precio (Costo, TipoTrabajo, DescuentoF,DescuentoFrec)
                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string nombre = reader.GetString(1);
                        if (name == nombre)
                        {
                            int clienteID = reader.GetInt32(0);
                            string apellido = reader.GetString(2);
                            double ganancias = reader.GetDouble(3);
                            int pedidos = reader.GetInt32(4);
                            string telefono = reader.GetString(5);
                            cliente = new Cliente(clienteID,nombre,apellido,ganancias,pedidos,telefono);
                        }
                    }
                }
                conex.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

            return cliente;
        }
        public Cliente getClienteID(int id)
        {
            Cliente cliente = null;
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "SELECT ClienteID, Nombre, apellido, Ganancias, Pedidos, telefono FROM Cliente";
                //INSERT INTO Precio (Costo, TipoTrabajo, DescuentoF,DescuentoFrec)
                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int clienteID = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        if (id == clienteID)
                        {
                          
                            string apellido = reader.GetString(2);
                            double ganancias = reader.GetDouble(3);
                            int pedidos = reader.GetInt32(4);
                            string telefono = reader.GetString(5);
                            cliente = new Cliente(clienteID, nombre, apellido, ganancias, pedidos, telefono);
                        }
                    }
                }
                conex.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

            return cliente;
        }
        public Cliente setCliente(string nombre,string apellido,string telefono,double ganancias,int pedidos,int clienteID){
            Cliente cliente = null;
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "UPDATE Cliente SET Nombre = @Nombre, apellido = @apellido, telefono = @telefono, pedidos = @pedidos, Ganancias = @Ganancias WHERE ClienteID = @ClienteID";

                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    // Agregar parámetros para evitar inyecciones SQL
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.Parameters.AddWithValue("@Ganancias", ganancias); 
                    command.Parameters.AddWithValue("@ClienteID", clienteID);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.Parameters.AddWithValue("@Pedidos", pedidos);

                    // Ejecutar la consulta de actualización
                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Todos los usuarios actualizados exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se actualizaron usuarios.");
                    }
                }
                conex.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

            return cliente;
        }
        public ArrayList getListPedido()
        {
            ArrayList lista = new ArrayList();
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "SELECT PedidoID, ClienteID , Cantidad, Detalle, Total FROM Pedido";

                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    { 
                        int pedidoID = reader.GetInt32(0);
                        int clienteID = reader.GetInt32(1);
                        double cantidad = reader.GetDouble(2);
                        string detalle = reader.GetString(3);
                        double total = reader.GetDouble(4);      
                        Pedido pedido = new Pedido(pedidoID, clienteID, cantidad,detalle,total);
                        lista.Add(pedido);
                    }
                }
                conex.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

            return lista;
        }
        public void eliminarCliente(int clienteID)
        {
         
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "DELETE FROM Cliente WHERE ClienteId = @ClienteId";

                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    // Agregar parámetro para evitar inyecciones SQL
                    command.Parameters.AddWithValue("@ClienteId", clienteID);

                    // Ejecutar la consulta de eliminación
                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Cliente eliminado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún cliente con el ID proporcionado.");
                    }
                }
                conex.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

        }
        public ArrayList getListClientes()
        {
            ArrayList lista = new ArrayList();
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "SELECT ClienteID, Nombre , apellido, Ganancias, Pedidos, telefono FROM Cliente";

                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int clienteID = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        double ganancias = reader.GetDouble(3);
                        int pedidos = reader.GetInt32(4);
                        string telefono = reader.GetString(5);
                        Cliente us = new Cliente(clienteID, nombre, apellido, ganancias, pedidos, telefono);
                        lista.Add(us);
                    }
                }
                conex.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

            return lista;
        }
        public ArrayList AgregarPedido(int clienteID,double cantidad,string detalle,double total)
        {
            ArrayList lista = new ArrayList();
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();

                string query = "INSERT INTO Pedido (ClienteID, Cantidad, Detalle, Total) VALUES (@ClienteID, @Cantidad, @Detalle, @Total)";

                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    // Parámetros
                    command.Parameters.AddWithValue("@ClienteID", clienteID);
                    command.Parameters.AddWithValue("@Cantidad", cantidad);
                    command.Parameters.AddWithValue("@Detalle",detalle);
                    command.Parameters.AddWithValue("@Total", total);

                    int result = command.ExecuteNonQuery();

                    // Comprueba si se insertó correctamente
                    if (result > 0)
                    {
                        MessageBox.Show("Pedido insertado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el pedido.");
                    }
                }
                conex.Close ();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

            return lista;
        }
        public ArrayList getListPedido(int id)
        {
            ArrayList lista = new ArrayList();
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "SELECT PedidoID, ClienteID , Cantidad, Detalle, Total FROM Pedido";

                using (SqlCommand command = new SqlCommand(query, conex))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int clienteID = reader.GetInt32(1);
                        if (clienteID==id)
                        {
                            int pedidoID = reader.GetInt32(0);
                            
                            double cantidad = reader.GetDouble(2);
                            string detalle = reader.GetString(3);
                            double total = reader.GetDouble(4);
                            Pedido pedido = new Pedido(pedidoID, clienteID, cantidad, detalle, total);
                            lista.Add(pedido);
                        }
                    }
                }
                conex.Close();
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }

            return lista;
        }
        public void ActualizarDatos(int precioID, double costo, double descuentoF, double descuentoFrec)
        {
            using (SqlConnection conex = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conex.Open();
                    string query = "UPDATE Precio SET costo = @costo, descuentoF = @descuentoF, descuentoFrec = @descuentoFrec WHERE precioID = @PrecioID";

                    using (SqlCommand command = new SqlCommand(query, conex))
                    {
                        // Agregar parámetros para evitar inyecciones SQL
                        command.Parameters.AddWithValue("@costo", costo);
                        command.Parameters.AddWithValue("@descuentoF", descuentoF);
                        command.Parameters.AddWithValue("@descuentoFrec", descuentoFrec); // Considera usar un hash para la contraseña
                        command.Parameters.AddWithValue("@precioID", precioID);

                        // Ejecutar la consulta de actualización
                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Todos los usuarios actualizados exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se actualizaron usuarios.");
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + e.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
