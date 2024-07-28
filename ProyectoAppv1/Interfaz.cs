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
        public Interfaz()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            panel1.BorderStyle = BorderStyle.None;
            panel1.Padding = new Padding(borderSize);
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

        }
        private void VaciarPanel()
        {
            panel5.Visible = false;
        }
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            button5.Visible= false;
            button11.Visible= true;
            pictureBox3.Size = new Size(561, 414);
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
            // Obtener la URL desde el cuadro de texto
            string url = "https://www.dafont.com/es/";

            // Validar la URL antes de abrirla
            if (!string.IsNullOrWhiteSpace(url))
            {
                try
                {
                    // Abrir la URL en el navegador predeterminado
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo abrir el enlace. Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una URL.");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            button5.Visible = true;
            button11.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!panel5.Visible)
            {
                panel5.Visible = true;
            }
            else
            {
                panel5.Visible = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

            if (!panel4.Visible)
            {
                panel4.Visible = true;
                panel5.Visible=false;
            }
        }
    }
}
