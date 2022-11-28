using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class CN_Marcar
    {
        private CD_Marcar objetoCDM = new CD_Marcar();
        private DataTable tabla = null;
        public void Marcar(string entrada, string salida, string codigo) {
            objetoCDM.Marcar(entrada, salida, codigo);
        }

        public DataTable Mostrar() {
            tabla = new DataTable();
            tabla = objetoCDM.Mostrar();
            return tabla;
        }
    }
}
