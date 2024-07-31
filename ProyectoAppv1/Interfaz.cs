using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace ProyectoAppv1
{
    public partial class Interfaz : Form
    {
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(63, 162, 246);
        private Controlador seguridad;
        Inicio inicio=new Inicio();
        Planchado planchado;
        Impresion impresion;
        CostoPoleras costos;
        Clientes clientes;
        Configuracion configuracion;
        Historial historial;
        private Usuario usuarioPrincipal;
        public Interfaz(Usuario usuarioPrincipal)
        {
            InitializeComponent();
            planchado = new Planchado(usuarioPrincipal);
            impresion = new Impresion(usuarioPrincipal);
            costos = new CostoPoleras(usuarioPrincipal);
            clientes = new Clientes(usuarioPrincipal);
            configuracion = new Configuracion(usuarioPrincipal);
            historial = new Historial(usuarioPrincipal);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            panel1.BorderStyle = BorderStyle.None;
            panel1.Padding = new Padding(borderSize);
            inicio.TopLevel = false;
            impresion.TopLevel = false;
            planchado.TopLevel = false;
            costos.TopLevel = false;
            clientes.TopLevel = false;
            configuracion.TopLevel = false;
            historial.TopLevel = false;
            this.usuarioPrincipal = usuarioPrincipal;
        }
        #region ImportacionParaRedondeado
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        private void Interfaz_Load(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(inicio);
            inicio.Dock = DockStyle.Fill;
            inicio.Show();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;   
        }
        public void hacermediano()
        {
            planchado.normal();
            impresion.normal();
            costos.normal();
            clientes.normal();
            historial.normal();
            configuracion.normal();
        }
        public void hacerGrande()
        {
            if (this.WindowState!=0)
            {
                planchado.maximizar();
                impresion.maximizar();
                costos.maximizar();
                clientes.maximizar();
                historial.maximizar();
                configuracion.maximizar();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            button5.Visible= false;
            button11.Visible= true;
            hacerGrande();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.WindowState = 0;
            button5.Visible = true;
            button11.Visible = false;
            hacermediano();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(configuracion);
            configuracion.Dock = DockStyle.Fill;
            if (this.WindowState == 0)
            {
                configuracion.normal();
            }
            else
            {
                configuracion.maximizar();
            }
            configuracion.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(impresion);
            impresion.Dock = DockStyle.Fill;
            if (this.WindowState==0)
            {
                impresion.normal();
            }
            else
            {
                impresion.maximizar();
            }
            impresion.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(inicio);
            inicio.Dock = DockStyle.Fill;
            inicio.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(planchado);
            planchado.Dock = DockStyle.Fill;
            if (this.WindowState == 0)
            {
                planchado.normal();
            }
            else
            {
                planchado.maximizar();
            }
            planchado.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(costos);
            costos.Dock = DockStyle.Fill;
            if (this.WindowState == 0)
            {
                costos.normal();
            }
            else
            {
                costos.maximizar();
            }
            planchado.Show();
            costos.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(clientes);
            clientes.Dock = DockStyle.Fill;
            clientes.llenarGriv();
            if (this.WindowState == 0)
            {
                clientes.normal();
            }
            else
            {
                clientes.maximizar();
            }
            clientes.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(historial);
            historial.Dock = DockStyle.Fill;
            historial.llenarGriv();
            if (this.WindowState == 0)
            {
                historial.normal();
            }
            else
            {
                historial.maximizar();
            }
            historial.Show();
        }
    }
}
