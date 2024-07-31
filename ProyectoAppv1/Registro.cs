using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAppv1
{
    public partial class Registro : Form
    {
        private Controlador seguridad;
        private Cliente cliente;
        public Registro(Cliente cliente)
        {
            seguridad = new Controlador();
            this.cliente = cliente;
            InitializeComponent();
            cliente=new Cliente();
        }
        public void mostrarEditar()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
        }
        public void mostrarAgregar()
        {
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = false;
            textBox1.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
        }
        public void mostrarRegistro()
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" &&
                textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                string cuenta=textBox1.Text;
                string nombre=textBox2.Text;
                string apellido=textBox3.Text;
                string telefono=textBox4.Text;
                string email=textBox5.Text;
                string contraseña=textBox6.Text;
                string pregUnica=textBox7.Text;

                seguridad.AgregarUsuarios(cuenta,nombre,apellido,telefono,email,contraseña, pregUnica);
            }
        }
        public void llenarDatos(string nombre,string apellido,string telefono)
        {
            textBox2.Text= nombre;
            textBox3.Text= apellido;
            textBox4.Text= telefono;
            textBox1.Visible=false;
            textBox5.Visible=false;
            textBox6.Visible=false;
            textBox7.Visible=false;
            button1.Visible=false;
            button2.Visible=true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = textBox2.Text;
            string apellido = textBox3.Text;
            string telefono = textBox4.Text;
            seguridad.AgregarCliente(nombre, apellido, telefono);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nombre = textBox2.Text;
            string apellido = textBox3.Text;
            string telefono = textBox4.Text;
            seguridad.setCliente(nombre,apellido,telefono,cliente.Ganancias,cliente.Pedidos,cliente.ClienteID);
        }
    }
}
