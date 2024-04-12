using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubIntBD
{
    public class ContabilidadDiferenciasBD
    {
        Conexion conn = new Conexion();
        SqlDataReader reader ;
        public virtual SqlDataReader BOLETASDIFIGV_BD(String FechIni, String FechFin)
        {

            SqlConnection SQLConnection = new SqlConnection(conn.ClaConexionlocal());
            SqlCommand SQLCommand = new SqlCommand("CONObtenerDiferenciasIGV", SQLConnection);
            if (SQLConnection.State == ConnectionState.Closed)
            {
                SQLConnection.Open();
                SQLCommand.CommandType = CommandType.StoredProcedure;
                SQLCommand.Parameters.AddWithValue("@FechaIni", FechIni);
                SQLCommand.Parameters.AddWithValue("@FechaFin", FechFin);
                SQLCommand.Parameters.Add("@Error", SqlDbType.VarChar, 256).Direction = ParameterDirection.Output;               
                reader = SQLCommand.ExecuteReader();
                String Error = SQLCommand.Parameters["@Error"].Value?.ToString() ?? String.Empty;
                //SQLConnection.Close();
                if (Error != "")
                {
                    MessageBox.Show(Error);
                    return reader;
                }
                else{ return reader;}
            }
            else
            {
                SQLConnection.Close();
                return reader;
            }
        }

        public virtual SqlDataReader OBTENERDETALLEBOLETA_BD(string DocCodigo, string DocSerie, Int64 DocNro)
        {
            SqlConnection SQLConnection = new SqlConnection(conn.ClaConexionlocal());
            SqlCommand SQLCommand = new SqlCommand("CONObtenerDetalleBoleta", SQLConnection);
            if (SQLConnection.State == ConnectionState.Closed)
            {
                SQLConnection.Open();
                SQLCommand.CommandType = CommandType.StoredProcedure;
                SQLCommand.Parameters.AddWithValue("@DocCodigo", DocCodigo);
                SQLCommand.Parameters.AddWithValue("@DocSerie", DocSerie);
                SQLCommand.Parameters.AddWithValue("@DocNro", DocNro);               
                return SQLCommand.ExecuteReader();
            }
            else
            {
                SQLConnection.Close();
                return reader;
            }
        }

        public virtual SqlDataReader GETSOCIOBYNACIONALIDADDOCUMENTO_BD(string Nacionalidad, string Documento)
        {

            SqlConnection SQLConnection = new SqlConnection(conn.ClaConexionlocal());
            SqlCommand SQLCommand = new SqlCommand("csGetSocioByNacionalidadDocumento", SQLConnection);
            if (SQLConnection.State == ConnectionState.Closed)
            {
                SQLConnection.Open();
                SQLCommand.CommandType = CommandType.StoredProcedure;
                SQLCommand.Parameters.AddWithValue("@Nacionalidad", Nacionalidad);
                SQLCommand.Parameters.AddWithValue("@Documento", Documento);
                return SQLCommand.ExecuteReader();
            }
            else
            {
                SQLConnection.Close();
                return reader;
            }
        }




    }
}
