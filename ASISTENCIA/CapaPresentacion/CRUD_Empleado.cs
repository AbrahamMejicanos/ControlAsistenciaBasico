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
                    cboPais.Items.Add($"{item.name}, {item.phone}, {item.id}");
                }
            }
        }

        private void llenarCboS() {
            cboSucursal.DataSource = objetoCNE.llenarCbo();
            cboSucursal.DisplayMember = "NOMBRE";
            cboSucursal.ValueMember = "ID";
        }
    }
}
