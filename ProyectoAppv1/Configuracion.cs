using System;
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

namespace ProyectoAppv1
{
    public partial class Configuracion : Form
    {
        private Usuario usuarioPrincipal;
        private Controlador seguridad;
        public Configuracion(Usuario usuarioPrincipal)
        {
            InitializeComponent();
            seguridad=new Controlador();
            this.usuarioPrincipal = usuarioPrincipal;
            textBox2.Text = ""+seguridad.GetPrecio(1).Costo;
            textBox7.Text = "" + seguridad.GetPrecio(1).DescuentoF;
            textBox6.Text = "" + seguridad.GetPrecio(1).DescuentoFrec;
            textBox1.Text = "" + seguridad.GetPrecio(2).DescuentoF;
            textBox5.Text = "" + seguridad.GetPrecio(2).DescuentoFrec;
            textBox3.Text = "" + seguridad.GetPrecio(2).Costo;
            textBox4.Text = "" + seguridad.GetPrecio(3).Costo;
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            double costo1 = double.Parse(textBox2.Text);
            double descuentoF = double.Parse(textBox7.Text);
            double descuentoFrec = double.Parse(textBox6.Text);
            double costo2 = double.Parse(textBox3.Text);
            double descuentoF2 = double.Parse(textBox1.Text);
            double descuentoFrec2 = double.Parse(textBox5.Text);
            double costo3 = double.Parse(textBox4.Text);
            double descuentoF3 = seguridad.GetPrecio(3).DescuentoF;
            double descuentoFrec3 = seguridad.GetPrecio(3).DescuentoFrec;
            seguridad.ActualizarDatos(1,costo1,descuentoF,descuentoFrec);
            seguridad.ActualizarDatos(1, costo2, descuentoF2, descuentoFrec2);
            seguridad.ActualizarDatos(1, costo3, descuentoF3, descuentoFrec3);
        }
        public void maximizar()
        {
            label7.Font = new Font("Calibri", 48, FontStyle.Bold);

            pictureBox6.Size = new Size(470, 260);

            //primer boton
            label8.Location = new Point(750, 35); // y-45 (y-20 - 25)
            pictureBox8.Location = new Point(750, 95); // y-45 (y-20 - 25)
            pictureBox8.Size = new Size(456, 74);
            textBox2.Location = new Point(815, 113); // y-45 (y-20 - 25)
            textBox2.Size = new Size(356, 74);

            //segundo boton
            label5.Location = new Point(750, 195); // y-45 (y-20 - 25)
            pictureBox5.Location = new Point(750, 255); // y-45 (y-20 - 25)
            pictureBox5.Size = new Size(456, 74);
            textBox7.Location = new Point(815, 273); // y-45 (y-20 - 25)
            textBox7.Size = new Size(356, 74);

            //tercer boton
            label4.Location = new Point(750, 355); // y-45 (y-20 - 25)
            pictureBox4.Location = new Point(750, 415); // y-45 (y-20 - 25)
            pictureBox4.Size = new Size(456, 74);
            textBox6.Location = new Point(815, 433); // y-45 (y-20 - 25)
            textBox6.Size = new Size(356, 74);

            //cuarto boton
            label10.Location = new Point(750, 515); // y-45 (y-20 - 25)
            pictureBox10.Location = new Point(750, 575); // y-45 (y-20 - 25)
            pictureBox10.Size = new Size(456, 74);
            textBox1.Location = new Point(815, 593); // y-45 (y-20 - 25)
            textBox1.Size = new Size(356, 74);

            //quinto boton
            label1.Location = new Point(750, 675); // y-45 (y-20 - 25)
            pictureBox1.Location = new Point(750, 735); // y-45 (y-20 - 25)
            pictureBox1.Size = new Size(456, 74);
            textBox5.Location = new Point(815, 753); // y-45 (y-20 - 25)
            textBox5.Size = new Size(356, 74);

            //sexto boton
            label2.Location = new Point(250, 355); // y-45 (y-20 - 25)
            pictureBox2.Location = new Point(250, 415); // y-45 (y-20 - 25)
            pictureBox2.Size = new Size(456, 74);
            textBox3.Location = new Point(315, 433); // y-45 (y-20 - 25)
            textBox3.Size = new Size(356, 74);

            //septimo boton
            label3.Location = new Point(250, 515); // y-45 (y-20 - 25)
            pictureBox3.Location = new Point(250, 575); // y-45 (y-20 - 25)
            pictureBox3.Size = new Size(456, 74);
            textBox4.Location = new Point(315, 593); // y-45 (y-20 - 25)
            textBox4.Size = new Size(356, 74);



            //boton guardar
            button13.Location = new Point(250, 700); // y-20
            button13.Size = new Size(234, 69);
        }
        public void normal()
        {
            label7.Font = new Font("Calibri", 36, FontStyle.Bold);

            pictureBox6.Size = new Size(210, 130);

            // primer boton
            label8.Location = new Point(360, 30); // x-50
            pictureBox8.Location = new Point(360, 70); // x-50
            pictureBox8.Size = new Size(275, 50);
            textBox2.Location = new Point(400, 80); // x-50
            textBox2.Size = new Size(227, 26);

            // segundo boton
            label5.Location = new Point(360, 120); // x-50
            pictureBox5.Location = new Point(360, 160); // x-50
            pictureBox5.Size = new Size(275, 50);
            textBox7.Location = new Point(400, 170); // x-50
            textBox7.Size = new Size(227, 26);

            // tercer boton
            label4.Location = new Point(360, 210); // x-50
            pictureBox4.Location = new Point(360, 250); // x-50
            pictureBox4.Size = new Size(275, 50);
            textBox6.Location = new Point(400, 260); // x-50
            textBox6.Size = new Size(227, 26);

            // cuarto boton
            label10.Location = new Point(345, 300); // x-50
            pictureBox10.Location = new Point(360, 340); // x-50
            pictureBox10.Size = new Size(275, 50);
            textBox1.Location = new Point(400, 350); // x-50
            textBox1.Size = new Size(227, 26);

            // quinto boton
            label1.Location = new Point(345, 390); // x-50
            pictureBox1.Location = new Point(360, 430); // x-50
            pictureBox1.Size = new Size(275, 50);
            textBox5.Location = new Point(400, 440); // x-50
            textBox5.Size = new Size(227, 26);

            // sexto boton
            label2.Location = new Point(25, 300); // y-20
            pictureBox2.Location = new Point(30, 340); // y-20
            pictureBox2.Size = new Size(275, 50);
            textBox3.Location = new Point(70, 350); // y-20
            textBox3.Size = new Size(227, 26);

            // septimo boton
            label3.Location = new Point(30, 390); // y-20
            pictureBox3.Location = new Point(30, 430); // y-20
            pictureBox3.Size = new Size(275, 50);
            textBox4.Location = new Point(70, 440); // y-20
            textBox4.Size = new Size(227, 26);

            // boton guardar
            button13.Location = new Point(585, 475); // y-20
            button13.Size = new Size(140, 40);

            //label7.Font = new Font("Calibri", 36, FontStyle.Bold);

            //pictureBox6.Size = new Size(410, 300);
            ////primer boton
            //label8.Location = new Point(410, 80); // y-20
            //pictureBox8.Location = new Point(410, 125); // y-20
            //pictureBox8.Size = new Size(275, 50);
            //comboBox4.Location = new Point(450, 135); // y-20
            //comboBox4.Size = new Size(227, 26);

            ////segundo boton
            //label9.Location = new Point(410, 175); // y-20
            //pictureBox9.Location = new Point(410, 220); // y-20
            //pictureBox9.Size = new Size(275, 50);
            //textBox2.Location = new Point(450, 230); // y-20
            //textBox2.Size = new Size(227, 26);

            ////tercer boton
            //label10.Location = new Point(410, 270); // y-20
            //pictureBox10.Location = new Point(410, 315); // y-20
            //pictureBox10.Size = new Size(275, 50);
            //comboBox3.Location = new Point(450, 325); // y-20
            //comboBox3.Size = new Size(227, 26);

            ////cuarto boton
            //label11.Location = new Point(395, 365); // y-20
            //pictureBox11.Location = new Point(410, 410); // y-20
            //pictureBox11.Size = new Size(275, 50);
            //textBox3.Location = new Point(450, 420); // y-20
            //textBox3.Size = new Size(227, 26);

            ////quinto boton
            //label11.Location = new Point(395, 365); // y-20
            //pictureBox11.Location = new Point(410, 410); // y-20
            //pictureBox11.Size = new Size(275, 50);
            //textBox3.Location = new Point(450, 420); // y-20
            //textBox3.Size = new Size(227, 26);

            ////sexto boton
            //label11.Location = new Point(395, 365); // y-20
            //pictureBox11.Location = new Point(410, 410); // y-20
            //pictureBox11.Size = new Size(275, 50);
            //textBox3.Location = new Point(450, 420); // y-20
            //textBox3.Size = new Size(227, 26);

            ////septimo boton
            //label11.Location = new Point(395, 365); // y-20
            //pictureBox11.Location = new Point(410, 410); // y-20
            //pictureBox11.Size = new Size(275, 50);
            //textBox3.Location = new Point(450, 420); // y-20
            //textBox3.Size = new Size(227, 26);

            ////boton guardar
            //button13.Location = new Point(585, 470); // y-20
            //button13.Size = new Size(140, 40);
        }
    }
}
