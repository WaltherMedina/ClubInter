using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubIntBD
{
    public class SociosBD
    {
        Conexion conn = new Conexion();
        SqlDataReader reader;

        public  MemoryStream GETIMAGE_BD(string Nacionalidad, string Documento, string Flag)
        {
            try
            {
                if (!EXISTIMAGE_BD(Nacionalidad, Documento, Flag))
                {
                    Nacionalidad = "PE";
                    Documento = "00000000";
                }
                SqlConnection SQLConnection = new SqlConnection(conn.ClaConexionlocal());
                SqlCommand SQLCommand = new SqlCommand("csGetImage", SQLConnection);
                
                if (SQLConnection.State == ConnectionState.Closed)
                {
                    SQLConnection.Open();
                    SQLCommand.CommandType = CommandType.StoredProcedure;
                    SQLCommand.Parameters.AddWithValue("@Nacionalidad", Nacionalidad);
                    SQLCommand.Parameters.AddWithValue("@Documento", Documento);
                    reader = SQLCommand.ExecuteReader();
                    reader.Read();
                    byte[] content = (byte[])reader.GetValue(0);
                    MemoryStream ms = new MemoryStream(content, 0, content.Length);
                    return ms;
                }
                else
                {
                    SQLConnection.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public bool EXISTIMAGE_BD(string Nacionalidad, string Documento, string Flag)
        {
            try
            {
                bool returnValue = true;
                SqlConnection SQLConnection = new SqlConnection(conn.ClaConexionlocal());
                SqlCommand SQLCommand = new SqlCommand("csExistImage", SQLConnection);

                if (SQLConnection.State == ConnectionState.Closed)
                {
                    SQLConnection.Open();
                    SQLCommand.CommandType = CommandType.StoredProcedure;
                    SQLCommand.Parameters.AddWithValue("@Nacionalidad", Nacionalidad);
                    SQLCommand.Parameters.AddWithValue("@Documento", Documento);
                    SQLCommand.Parameters.AddWithValue("@Flag", Flag);
                    SQLCommand.Parameters.Add("@Exist", SqlDbType.VarChar, 256).Direction = ParameterDirection.Output;
                    reader = SQLCommand.ExecuteReader();
                    int exist = Convert.ToInt32(SQLCommand.Parameters["@Exist"].Value.ToString());
                    if (exist == 0)
                    {
                        returnValue = false;
                    }
                    return returnValue;
                }
                else
                {
                    SQLConnection.Close();
                    return returnValue;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual SqlDataReader GETEDADANTIGUEDAD_BD(string Nacionalidad, string Documento)
        {

            SqlConnection SQLConnection = new SqlConnection(conn.ClaConexionlocal());
            SqlCommand SQLCommand = new SqlCommand("csGetEdadAntiguedad", SQLConnection);
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
