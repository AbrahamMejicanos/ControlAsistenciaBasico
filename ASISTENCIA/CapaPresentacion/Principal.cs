using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnTurno_Click(object sender, EventArgs e)
        {
            Form1 turno = new Form1();
            this.Hide();
            turno.ShowDialog();
            this.Show();
        }

        private void btnSucursal_Click(object sender, EventArgs e)
        {
            CRUD_Sucursal sucursal = new CRUD_Sucursal();
            this.Hide();
            sucursal.ShowDialog();
            this.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            CRUD_Empleado empleados = new CRUD_Empleado();
            this.Hide();
            empleados.ShowDialog();
            this.Show();
        }

        private void btnMarcaje_Click(object sender, EventArgs e)
        {
            Marcar marcar = new Marcar();
            this.Hide();
            marcar.ShowDialog();
            this.Show();
        }
    }
}
