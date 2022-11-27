using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class CRUD_Sucursal : Form
    {
        private CN_Sucursal objetoCN = new CN_Sucursal();
        private string idTurno = null;
        private bool editar = false;

        public CRUD_Sucursal()
        {
            InitializeComponent();
        }

        private void CRUD_Sucursal_Load(object sender, EventArgs e)
        {
            Mostrar();
            RellenoCbo();
        }

        private void Mostrar() {
            CN_Sucursal objeto = new CN_Sucursal();
            dataGridView2.DataSource = objeto.MostrarSucur();
        }

        private void RellenoCbo() {
            Limpiar();
            CN_Sucursal objeto = new CN_Sucursal();
            cboTurno.DataSource = objeto.MostrarCbo();
            cboTurno.DisplayMember = "NOMBRE";
            cboTurno.ValueMember = "ID";
        }

        private void insertar() {
            string valor = "";
            valor += cboTurno.SelectedValue;
            objetoCN.Insertar(txtNombre.Text, valor);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(editar == false) {
                insertar();
                Mostrar();
                RellenoCbo();
            }
            if (editar == true) {
                objetoCN.Update(txtNombre.Text, cboTurno.SelectedValue.ToString(), idTurno);
                MessageBox.Show("Se ha actualizado con exito");
                Mostrar();
                RellenoCbo();
            }
            editar = false;
            idTurno = null;
        }

        private void Limpiar() {
            txtNombre.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0) {
                editar = true;
                txtNombre.Text = dataGridView2.CurrentRow.Cells["NOMBRE"].Value.ToString();
                idTurno = dataGridView2.CurrentRow.Cells["ID"].Value.ToString();
            }else {
                MessageBox.Show("Selecciona una fila para poder editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0) {
                idTurno = dataGridView2.CurrentRow.Cells["ID"].Value.ToString();
                objetoCN.Delete(idTurno);
                MessageBox.Show("Se ha eliminado con exito");
                Mostrar();

            }
            else {
                MessageBox.Show("Selecciona una fila para poder eliminar");
            }
        }
    }
}
