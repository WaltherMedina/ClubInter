using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MasterReportBD
{
    class ClaConexiónLocal
    {
        String cadena = "data source = 192.168.1.9, 49228; initial catalog = ClubInter; User ID = sa; password = 31Gr@nQu3s0t3; Integrated Security = True";
        SqlConnection conn = new SqlConnection();

        public string ClaConexionlocal()
        {
            //conn.ConnectionString = cadena;
            return cadena;
        }

        public void abrir()
        {
            try
            {
                conn.Open();
                //Console.WriteLine("Conexion abierta");
                //MessageBox.Show("Conectado");
            }
            catch
            {
                Console.WriteLine("Error al abrir la BD");
                //MessageBox.Show("Error en la conexion");
            }
        }
        public void cerrar()
        {
            conn.Close();
        }
    }
}
