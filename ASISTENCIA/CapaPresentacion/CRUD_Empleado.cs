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
using Newtonsoft.Json;

namespace CapaPresentacion
{
    public partial class CRUD_Empleado : Form
    {
        private bool editar = false;
        private string idEmpleado = null;
        private CN_ConsumoAPI api = new CN_ConsumoAPI();
        private CN_Sucursal objetoCNS = null;
        private dynamic url = "https://avnc.net/modules/wpcf_avnc/services/countries";
        private CN_Empleado objetoCNE = new CN_Empleado();
        public CRUD_Empleado()
        {
            InitializeComponent();
        }

        private void CRUD_Empleado_Load(object sender, EventArgs e)
        {
            CrearJson();
            Mostrar();
            llenarCboS();
            llenarCbo();
            this.cboPais.DropDownHeight = 250;
            this.cboPais.DropDownWidth = 500;
        }

        private void CrearJson() {
            api.Get(url);
        }

        private void llenarCbo() {
            using (StreamReader archivo = File.OpenText(@"paises.json"))
            {
                string json = archivo.ReadToEnd();
                dynamic myArray = JsonConvert.DeserializeObject(json);
                foreach (var item in myArray)
                {
                    cboPais.Items.Add($"{item.name} | {item.phone} | {item.id}");
                }
            }
        }

        private void llenarCboS() {
            CN_Empleado objeto = new CN_Empleado();
            cboSucursal.DataSource = objeto.LlenarCbo();
            cboSucursal.DisplayMember = "NOMBRE";
            cboSucursal.ValueMember = "ID";
        }

        private void Mostrar() {
            CN_Empleado objeto = new CN_Empleado();
            dataGridView1.DataSource = objeto.Mostrar();
        }

        private void obtenerRecursos() {
            string id = "";
            string sucursal = cboSucursal.SelectedValue.ToString();
            string pais = cboPais.SelectedItem.ToString();
            string n1 = txtNombre1.Text;
            string n2 = txtNombre2.Text;
            string correo = txtCorreo.Text;
            string genero = "";
            if (rbMasculino.Checked == true) {
                genero = "Masculino";
            }
            else {
                genero = "Femenino";
            }
            string ciudad = txtCiudad.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string fecha = $"{cmFCumple.SelectionStart.Day}/{cmFCumple.SelectionStart.Month}/{cmFCumple.SelectionStart.Year}";
            if (editar == false)
            {
                enviarRecursos(fecha, sucursal, pais, n1, n2, correo, genero, ciudad, direccion, telefono, "");
            }
            else {
                id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                enviarRecursos(fecha, sucursal, pais, n1, n2, correo, genero, ciudad, direccion, telefono, id);
            }
        }

        private void enviarRecursos(string fecha, string sucursal, string pais, string n1, string n2, string correo, string genero, string ciudad, string direccion, string telefono, string id) {
            if (editar == false) {
                objetoCNE.Insert(sucursal, n1, n2, fecha, genero, correo, pais, ciudad, direccion, telefono);
            }
            else {
                objetoCNE.Update(sucursal, n1, n2, fecha, genero, correo, pais, ciudad, direccion, telefono, id);
            }
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (editar == false) {
                obtenerRecursos();
            }
            else {
                obtenerRecursos();
            }
        }

        private void Limpiar() {
            editar = false;
            txtNombre1.Clear();
            txtNombre2.Clear();
            txtCorreo.Clear();
            rbMasculino.Checked = true;
            txtCiudad.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            Mostrar();
            llenarCbo();
            llenarCboS();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string[] nombre = new string[2];
            string[] lugares = new string[3];
            if (dataGridView1.SelectedRows.Count > 0) {
                editar = true; 
                nombre = obtenerNombres();
                txtNombre1.Text = nombre[0];
                txtNombre2.Text = nombre[1];
                txtCorreo.Text = dataGridView1.CurrentRow.Cells["CORREO"].Value.ToString();
                lugares = obtenerLugares();
                txtCiudad.Text = lugares[1];
                txtDireccion.Text = lugares[2];
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["TELEFONO"].Value.ToString();
            }
            else {
                MessageBox.Show("Selecciona una fila para poder editar");
            }
        }

        private string[] obtenerNombres() {
            string[] nombre = new string[2];
            string nombres = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
            int contador = 0;
            foreach (char i in nombres) {
                if (!i.Equals(' ')) {
                    nombre[contador] += i;
                }else {
                    contador++;
                }
            }
            return nombre;
        }

        private string[] obtenerLugares() {
            string[] lugares = new string[3];
            int contador = 0;
            string lugar = dataGridView1.CurrentRow.Cells["RESIDENCIA"].Value.ToString();
            foreach (char i in lugar) {
                if (!i.Equals('|')) {
                    lugares[contador] += i;
                } else if(i.Equals('|')){
                    contador++;
                }
            }
            return lugares;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id;
            if (dataGridView1.SelectedRows.Count > 0) {
                id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                objetoCNE.Delete(id);
                Mostrar();
            }
            else {
                MessageBox.Show("Selecciona una fila para poder eliminar");
            }
        }
    }
}
