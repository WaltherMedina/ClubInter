using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClubIntBD
{
    class Conexion
    {
        String cadena = "data source = 192.168.1.9, 49228; initial catalog = ClubInter; User ID = sa; password = 31Gr@nQu3s0t3; Integrated Security = True";
        SqlConnection conn = new SqlConnection();

        public string ClaConexionlocal()
        {
            return cadena;
        }

        public void open()
        {
            try
            {
                conn.Open();
            }
            catch
            {
                Console.WriteLine("Error de Conexión con la Base de Datos");
                
                MessageBox.Show("Error en la Conexión con la Base de Datos, contáctate con el administrador del Sistema");
            }
        }

        public void close() { conn.Close(); }
    }
}
