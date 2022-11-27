using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Empleado
    {
        private readonly CD_Sucursal objetoCDS = new CD_Sucursal();
        private readonly CD_Empleado objetoCDE = new CD_Empleado();
        private DataTable tabla = null;
        public DataTable LlenarCbo() {
            tabla = new DataTable();
            tabla = objetoCDS.mostrarCbo();
            return tabla;
        }

        public DataTable Mostrar() {
            tabla = new DataTable();
            tabla = objetoCDE.Mostrar();
            return tabla;
        }

        public void Insert(string idSucursal, string n1, string n2, string fechaC, string genero, string correo, string idPais, string ciudad, string direccion, string telefono) {
            try {
                string codigo = CodigoCliente(n1, n2);
                string correcionPais = Pais(idPais);
                objetoCDE.Insert(Convert.ToInt32(idSucursal), codigo, n1, n2, fechaC, genero, correo, Convert.ToInt32(correcionPais), ciudad, direccion, telefono);
            } catch (Exception ex) { throw ex; }
        }

        private static string CodigoCliente(string n1, string n2) {
            string codigo = "";
            foreach(char i in n1) {
                if (!i.Equals(' ')) {
                    codigo += i;
                    break;
                }
            }
            codigo += n2;
            return codigo.ToUpper();
        }

        private static string Pais(string idPais) {
            int contador = 0;
            string aux = "";
            foreach (char i in idPais) {
                if (i.Equals('|')) {
                    contador++;
                }
                else {
                    if (contador >= 2 && !i.Equals(' ')) {
                        aux += i;
                    }
                }
            }
            return aux;
        }
    }
}
