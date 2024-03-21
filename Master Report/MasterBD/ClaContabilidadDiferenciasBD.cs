using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterBD
{
    public class ClaContabilidadDiferenciasBD
    {
        ClaConexion conn = new ClaConexion();
        public virtual SqlDataReader BOLETASDIFIGV_BD(DateTime FechIni, DateTime FechFin)
        {
            
            SqlConnection SQLConnection = new SqlConnection(conn.ClaConexionlocal());
            SqlCommand SQLCommand = new SqlCommand("CONObtenerDiferenciasIGV", SQLConnection);
            if (SQLConnection.State == ConnectionState.Closed)
            {
                SQLConnection.Open();
                SQLCommand.CommandType = CommandType.StoredProcedure;
                SQLCommand.Parameters.AddWithValue("@FechaIni", FechIni);
                SQLCommand.Parameters.AddWithValue("@FechaFin", FechFin);
                return SQLCommand.ExecuteReader();
            }
            else
            {
                SQLConnection.Close();
                return null;
            }
        }
    }
}
