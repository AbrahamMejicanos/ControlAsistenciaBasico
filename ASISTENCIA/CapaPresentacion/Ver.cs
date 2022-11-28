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
    public partial class Ver : Form
    {
        public Ver()
        {
            InitializeComponent();
        }

        private void Ver_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void Mostrar() {
            CN_Marcar objeto = new CN_Marcar();
            DataTable tablaLogica = objeto.Mostrar();
            tablaLogica.Columns.Add("ESTADO MARCACION", typeof(string));
            tablaLogica = otorgarEstado(tablaLogica);
            dataGridView1.DataSource = tablaLogica;
        }

        private DataTable otorgarEstado(DataTable tablaLogica) {
            string h1 = "", h2 = "";
            string m1 = "", m2 = "";
            string e, s;
            int contador = 0;
            bool tarde;
            for(int i = 0; i < tablaLogica.Rows.Count; i++) {
                tarde = false;
                e = tablaLogica.Rows[i]["HORA ENTRADA"].ToString();
                s = tablaLogica.Rows[i]["HORA SALIDA"].ToString();
                foreach(char j in e) {
                    contador++;
                    if (!j.Equals(':') && contador < 3) {
                        h1 += j;
                    }
                    if (!j.Equals(':') && contador > 3)
                    {
                        m1 += j;
                    }
                }
                contador = 0;
                foreach (char j in s)
                {
                    contador++;
                    if (!j.Equals(':') && contador < 3)
                    {
                        h2 += j;
                    }
                    if (!j.Equals(':') && contador > 3)
                    {
                        m2 += j;
                    }
                }
                if (!m1.Equals(m2)) {
                    tarde = true;
                }
                else {
                    if ((Convert.ToInt32(h1) + 9) != Convert.ToInt32(h2)) {
                        tarde = true;
                    }
                }
                if (tarde == true) {
                    tablaLogica.Rows[i]["ESTADO MARCACION"] = "Llegada/Salida Tarde";
                }
                else {
                    tablaLogica.Rows[i]["ESTADO MARCACION"] = "Llegada/Salida A Tiempo";
                }
            }
            return tablaLogica;
        }
    }
}
