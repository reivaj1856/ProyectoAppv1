using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoAppv1
{
    public partial class Planchado : Form
    {
        private Controlador seguridad;
        public Planchado(Usuario usuarioPrincipal)
        {
            seguridad = new Controlador();
            InitializeComponent();
            llenarBox();
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void llenarBox()
        {
            //comboBox4.Items.Add("NoClient");
            ArrayList lista = seguridad.getListClientes();
            foreach (Cliente cliente in lista)
            {
                comboBox4.Items.Add(cliente.Nombre);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" || textBox3.Text != "")
            {
                string nombre = comboBox4.Text;
                double cantidad = 0;
                if (textBox2.Text != "") {
                    cantidad = double.Parse(textBox2.Text)+ cantidad;
                }
                if (textBox3.Text != "")
                {
                    cantidad = double.Parse(textBox3.Text)+ cantidad;
                }
                string detalle = "Servicio de Planchado";
                double total = 0;
                double precio = 0;
               
                if (comboBox4.SelectedIndex == 0)
                {
                    precio = seguridad.GetPrecio(2).Costo;
                    total = cantidad * precio ;
                }
                else
                {
                    if (comboBox4.SelectedIndex == 1)
                    {
                        precio = seguridad.GetPrecio(2).DescuentoF;
                        total = cantidad * precio;
                    }
                    else
                    {
                        precio = seguridad.GetPrecio(2).DescuentoFrec;
                        total = cantidad * precio;
                    }
                }
                Cliente cliente = seguridad.getCliente(nombre);
                MessageBox.Show("Total Costo: " + total);
                seguridad.AgregarPedido(cliente.ClienteID, cantidad, detalle, total);
                double ganancias = cliente.Ganancias+total;
                int pedidos= cliente.Pedidos+1;
                seguridad.setCliente(cliente.Nombre,cliente.Apellido,cliente.Telefono,ganancias,pedidos,cliente.ClienteID);
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("defina la cantidad impresa");
            }
        }
        public void maximizar()
        {
            label7.Font = new Font("Calibri", 58, FontStyle.Bold);

            pictureBox6.Size = new Size(773, 566);

            //primer boton
            label8.Location = new Point(850, 80); // y-20
            pictureBox8.Location = new Point(850, 140); // y-20
            pictureBox8.Size = new Size(456, 74);
            comboBox4.Location = new Point(915, 158); // y-20
            comboBox4.Size = new Size(356, 74);

            //segundo boton
            label9.Location = new Point(850, 240); // y-20
            pictureBox9.Location = new Point(850, 300); // y-20
            pictureBox9.Size = new Size(456, 74);
            textBox2.Location = new Point(915, 318); // y-20
            textBox2.Size = new Size(356, 74);

            //tercer boton
            label10.Location = new Point(850, 400); // y-20
            pictureBox10.Location = new Point(850, 460); // y-20
            pictureBox10.Size = new Size(456, 74);
            comboBox3.Location = new Point(915, 478); // y-20
            comboBox3.Size = new Size(356, 74);

            //cuarto boton
            label11.Location = new Point(850, 560); // y-20
            pictureBox11.Location = new Point(850, 620); // y-20
            pictureBox11.Size = new Size(456, 74);
            textBox3.Location = new Point(915, 638); // y-20
            textBox3.Size = new Size(356, 74);

            //boton guardar
            button13.Location = new Point(1055, 700); // y-20
            button13.Size = new Size(234, 69);
        }       
        public void normal()
        {
            label7.Font = new Font("Calibri", 36, FontStyle.Bold);

            pictureBox6.Size = new Size(410, 300);
            //primer boton
            label8.Location = new Point(410, 80); // y-20
            pictureBox8.Location = new Point(410, 125); // y-20
            pictureBox8.Size = new Size(275, 50);
            comboBox4.Location = new Point(450, 135); // y-20
            comboBox4.Size = new Size(227, 26);

            //segundo boton
            label9.Location = new Point(410, 175); // y-20
            pictureBox9.Location = new Point(410, 220); // y-20
            pictureBox9.Size = new Size(275, 50);
            textBox2.Location = new Point(450, 230); // y-20
            textBox2.Size = new Size(227, 26);

            //tercer boton
            label10.Location = new Point(410, 270); // y-20
            pictureBox10.Location = new Point(410, 315); // y-20
            pictureBox10.Size = new Size(275, 50);
            comboBox3.Location = new Point(450, 325); // y-20
            comboBox3.Size = new Size(227, 26);

            //cuarto boton
            label11.Location = new Point(395, 365); // y-20
            pictureBox11.Location = new Point(410, 410); // y-20
            pictureBox11.Size = new Size(275, 50);
            textBox3.Location = new Point(450, 420); // y-20
            textBox3.Size = new Size(227, 26);

            //boton guardar
            button13.Location = new Point(585, 470); // y-20
            button13.Size = new Size(140, 40);
        }
    }
}
