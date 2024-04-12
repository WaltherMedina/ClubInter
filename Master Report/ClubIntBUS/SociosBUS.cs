using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubIntBD;

namespace ClubIntBUS
{
    public class SociosBUS
    {
        SociosBD BD = new SociosBD();

        public MemoryStream GETIMAGE_BUS(string Nacionalidad, string Documento, string Flag)
        {
            try
            { return BD.GETIMAGE_BD(Nacionalidad, Documento, Flag); }
            catch (Exception ex) { throw; }
        }

        public SqlDataReader GETEDADANTIGUEDAD_BUS(string Nacionalidad, string Documento)
        {
            try
            { return BD.GETEDADANTIGUEDAD_BD(Nacionalidad, Documento); }
            catch (Exception ex) { throw; }
        }
    }

}
