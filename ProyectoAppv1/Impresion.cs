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
using TuNombreDeProyecto;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace ProyectoAppv1
{
    public partial class Impresion : Form
    {
        private Controlador seguridad;
        private Usuario usuario;
        public Impresion(Usuario usuarioPrincipal)
        {
            InitializeComponent();
            usuario = usuarioPrincipal;
            seguridad = new Controlador();
            llenarBox();
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void llenarBox()
        {
            //comboBox2.Items.Add("NoClient");
            ArrayList lista = seguridad.getListClientes();
            foreach (Cliente cliente in lista)
            {
                comboBox2.Items.Add(cliente.Nombre);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string nombre = comboBox2.Text;
                double cantidad = double.Parse(textBox1.Text);
                string detalle = "Servicio de impresion";
                double total = 0;
                double precio = 0;
                if (comboBox1.SelectedIndex==0) {
                    cantidad = cantidad / 1000;
                }
                else
                {
                    if (comboBox1.SelectedIndex == 1)
                    {
                        cantidad = cantidad / 100;
                    }
                    else
                    {
                        precio = seguridad.GetPrecio(1).DescuentoFrec;
                        cantidad = cantidad / 1;
                    }
                }
                if (comboBox3.SelectedIndex==0)
                {
                    precio=seguridad.GetPrecio(1).Costo;
                    total= cantidad*precio*1.11;
                }
                else
                {
                    if (comboBox3.SelectedIndex == 1)
                    {
                        precio = seguridad.GetPrecio(1).DescuentoF;
                        total = cantidad * precio;
                    }
                    else
                    {
                        precio = seguridad.GetPrecio(1).DescuentoFrec;
                        total = cantidad * precio;
                    }
                }
                Cliente cliente = seguridad.getCliente(nombre);
                MessageBox.Show("Total Costo: "+total);
                seguridad.AgregarPedido(cliente.ClienteID,cantidad,detalle,total);
                double ganancias = cliente.Ganancias + total;
                int pedidos = cliente.Pedidos + 1;
                seguridad.setCliente(cliente.Nombre, cliente.Apellido, cliente.Telefono, ganancias, pedidos, cliente.ClienteID);
                textBox1.Text = "";
            }
            else {
                MessageBox.Show("defina la cantidad impresa");
            }
        }

        public void maximizar()
        {
            label3.Font = new Font("Calibri", 58, FontStyle.Bold);

            pictureBox3.Size = new Size(773, 566);

            //primer boton
            label4.Location = new Point(850, 80); // y-20
            pictureBox7.Location = new Point(850, 140); // y-20
            pictureBox7.Size = new Size(456, 74);
            comboBox2.Location = new Point(915, 158); // y-20
            comboBox2.Size = new Size(356, 74);

            //segundo boton
            label5.Location = new Point(850, 240); // y-20
            pictureBox4.Location = new Point(850, 300); // y-20
            pictureBox4.Size = new Size(456, 74);
            textBox1.Location = new Point(915, 318); // y-20
            textBox1.Size = new Size(356, 74);

            //tercer boton
            label10.Location = new Point(850, 400); // y-20
            pictureBox10.Location = new Point(850, 460); // y-20
            pictureBox10.Size = new Size(456, 74);
            comboBox3.Location = new Point(915, 478); // y-20
            comboBox3.Size = new Size(356, 74);

            //cuarto boton
            label6.Location = new Point(850, 560); // y-20
            pictureBox5.Location = new Point(850, 620); // y-20
            pictureBox5.Size = new Size(456, 74);
            comboBox1.Location = new Point(915, 638); // y-20
            comboBox1.Size = new Size(356, 74);

            //boton guardar
            button12.Location = new Point(1055, 700); // y-20
            button12.Size = new Size(234, 69);
        }
        public void normal()
        {
            label3.Font = new Font("Calibri", 36, FontStyle.Bold);

            pictureBox3.Size = new Size(410, 300);
            //primer boton
            label4.Location = new Point(410, 80); // y-20
            pictureBox7.Location = new Point(410, 125); // y-20
            pictureBox7.Size = new Size(275, 50);
            comboBox2.Location = new Point(450, 135); // y-20
            comboBox2.Size = new Size(227, 26);

            //segundo boton
            label5.Location = new Point(410, 175); // y-20
            pictureBox4.Location = new Point(410, 220); // y-20
            pictureBox4.Size = new Size(275, 50);
            textBox1.Location = new Point(450, 230); // y-20
            textBox1.Size = new Size(227, 26);

            //tercer boton
            label10.Location = new Point(410, 270); // y-20
            pictureBox10.Location = new Point(410, 315); // y-20
            pictureBox10.Size = new Size(275, 50);
            comboBox3.Location = new Point(450, 325); // y-20
            comboBox3.Size = new Size(227, 26);

            //cuarto boton
            label6.Location = new Point(395, 365); // y-20
            pictureBox5.Location = new Point(410, 410); // y-20
            pictureBox5.Size = new Size(275, 50);
            comboBox1.Location = new Point(450, 420); // y-20
            comboBox1.Size = new Size(227, 26);

            //boton guardar
            button12.Location = new Point(585, 470); // y-20
            button12.Size = new Size(140, 40);
        }
    }
}
