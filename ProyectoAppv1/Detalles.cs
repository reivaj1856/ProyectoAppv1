using System;
using System.Collections;
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
    public partial class Detalles : Form
    {
        private Controlador seguridad;
        private int id;
        public Detalles(int id)
        {
            this.id = id;
            seguridad = new Controlador();
            InitializeComponent();
            llenarGriv();
        }
        private void llenarGriv()
        {
            ArrayList lista = seguridad.getListPedidos(id);
            var listaUsuarios = new BindingList<Pedido>();
            label2.Text = seguridad.GetClienteID(id).Nombre;
            foreach (Pedido pedido in lista)
            {
                int n = dataGridView1.Rows.Add();
                string nombre = seguridad.GetClienteID(pedido.ClienteID).Nombre;
                dataGridView1.Rows[n].Cells[0].Value = pedido.PedidoID;
                dataGridView1.Rows[n].Cells[1].Value = nombre;
                dataGridView1.Rows[n].Cells[2].Value = pedido.Cantidad;
                dataGridView1.Rows[n].Cells[3].Value = pedido.Detalle;
                dataGridView1.Rows[n].Cells[4].Value = pedido.Total;
            }
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

        private void Detalles_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == 0)
            {
                normal();
            }
            else
            {
                maximizar();
            }
        }
    }
}
