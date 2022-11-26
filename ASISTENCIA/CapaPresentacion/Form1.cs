using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        private CN_Turnos objetoCN = new CN_Turnos();
        private string idTurno = null;
        private bool editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarTurnos();
        }

        private void MostrarTurnos() {
            Limpiar();
            CN_Turnos objeto = new CN_Turnos();
            dataGridView1.DataSource = objeto.MostrarTurn();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (editar == false){
                objetoCN.InsertarTurnos(txtNombre.Text, txtHEntrada.Text, txtHSalida.Text);
                MessageBox.Show("Se inserto correctamente");
                MostrarTurnos();
            }
            if (editar == true) {
                objetoCN.EditarTurno(txtNombre.Text, txtHEntrada.Text, txtHSalida.Text, idTurno);
                MessageBox.Show("Se edito correctamente");
                MostrarTurnos();
                editar = false;
            }
        }

        private void Limpiar() {
            txtHSalida.Clear();
            txtNombre.Clear();
            txtHEntrada.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtNombre.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtHEntrada.Text = dataGridView1.CurrentRow.Cells["H. ENTRADA"].Value.ToString();
                txtHSalida.Text = dataGridView1.CurrentRow.Cells["H. SALIDA"].Value.ToString();
                idTurno = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                editar = true;
            }
            else {
                MessageBox.Show("Selecciona una fila para Editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idTurno = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                objetoCN.EliminarTurno(idTurno);
                MessageBox.Show("Se ha eliminado con exito");
            }
            else {
                MessageBox.Show("Seleccione fila para eliminar");
            }
        }
    }
}