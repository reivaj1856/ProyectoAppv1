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
    public partial class Clientes : Form
    {
        private Controlador seguridad;
        Registro registro;
        public Clientes(Usuario usuarioPrincipal)
        {
            
            InitializeComponent();
            seguridad = new Controlador();
            llenarGriv();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }
        public void llenarGriv()
        {
            dataGridView1.Rows.Clear();
            ArrayList lista=seguridad.getListClientes();
            var listaUsuarios = new BindingList<Cliente>();
            foreach (Cliente cliente in lista)
            {
                listaUsuarios.Add(cliente);
            }
            dataGridView1.DataSource = listaUsuarios;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registro=new Registro(null);
            registro.mostrarAgregar();
            registro.ShowDialog();
            llenarGriv();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string name = Convert.ToString(selectedRow.Cells["Nombre"].Value);
                Cliente cliente = seguridad.getCliente(name);
                registro = new Registro(cliente);
                registro.mostrarEditar();
                registro.llenarDatos(cliente.Nombre,cliente.Apellido,cliente.Telefono);
                registro.ShowDialog();
                llenarGriv();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string name = Convert.ToString(selectedRow.Cells["Nombre"].Value);
                Cliente cliente = seguridad.getCliente(name);
                seguridad.eliminarCliente(cliente.ClienteID);
                llenarGriv();
            }
        }
        public void maximizar()
        {
            label7.Font = new Font("Calibri", 48, FontStyle.Bold);
            label1.Font = new Font("Calibri", 22, FontStyle.Bold);
            label2.Font = new Font("Calibri", 22, FontStyle.Bold);
            label5.Font = new Font("Calibri", 22, FontStyle.Bold);
            
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 24, FontStyle.Bold);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.Font = new Font("Calibri", 16, FontStyle.Regular);
            }
        }
        public void normal()
        {
            label7.Font = new Font("Calibri", 36, FontStyle.Bold);
            label1.Font = new Font("Calibri", 20, FontStyle.Bold);
            label2.Font = new Font("Calibri", 20, FontStyle.Bold);
            label5.Font = new Font("Calibri", 20, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 14, FontStyle.Bold);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Regular);
            }

        }
    }
}
