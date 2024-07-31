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

namespace ProyectoAppv1
{
    public partial class Historial : Form
    {
        private Controlador seguridad;
        public Historial(Usuario usuarioPrincipal)
        {
            InitializeComponent();
            seguridad = new Controlador();
            llenarGriv();
        }
        public void llenarGriv()
        {
            dataGridView1.Rows.Clear();
            ArrayList lista = seguridad.getListPedidos();

            

            foreach (Pedido pedido in lista)
            {
                int n = dataGridView1.Rows.Add();
                string nombre= seguridad.GetClienteID(pedido.ClienteID).Nombre;
                dataGridView1.Rows[n].Cells[0].Value = pedido.PedidoID;
                dataGridView1.Rows[n].Cells[1].Value = nombre;
                dataGridView1.Rows[n].Cells[2].Value = pedido.Cantidad;
                dataGridView1.Rows[n].Cells[3].Value = pedido.Detalle;
                dataGridView1.Rows[n].Cells[4].Value = pedido.Total;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string name= Convert.ToString(selectedRow.Cells[1].Value);
                int ClienteID = seguridad.getCliente(name).ClienteID;
                Detalles detalles = new Detalles(ClienteID);
                detalles.ShowDialog();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void maximizar()
        {
            label7.Font = new Font("Calibri", 48, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 24, FontStyle.Bold);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.Font = new Font("Calibri", 16, FontStyle.Regular);
            }
        }
        public void normal()
        {
            label7.Font = new Font("Calibri", 36, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 14, FontStyle.Bold);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Regular);
            }

        }
    }
}
