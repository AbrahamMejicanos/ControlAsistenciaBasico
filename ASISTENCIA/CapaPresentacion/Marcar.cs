using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Marcar : Form
    {
        private CN_Marcar objetoCNM = new CN_Marcar();
        public Marcar()
        {
            InitializeComponent();
        }

        private void btnMarcar_Click(object sender, EventArgs e)
        {
            string entrada = txtEntrada.Text;
            string salida = txtSalida.Text;
            string codigo = txtCodigo.Text;
            objetoCNM.Marcar(entrada, salida, codigo);
            Limpiar();
        }

        private void Limpiar() {
            txtEntrada.Clear();
            txtSalida.Clear();
            txtCodigo.Clear();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Ver ver = new Ver();
            this.Hide();
            ver.ShowDialog();
            this.Show();
        }
    }
}
