using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubIntBD;

namespace ClubIntBUS
{
    public class ContabilidadDiferenciasBUS
    {
        ContabilidadDiferenciasBD BD = new ContabilidadDiferenciasBD();
        public SqlDataReader BOLETASDIFIGV_BUS(String FechIni, String FechFin)
        {
            try
            { return BD.BOLETASDIFIGV_BD(FechIni, FechFin); }
            catch (Exception ex){ throw; }
        }

        public SqlDataReader OBTENERDETALLEBOLETA_BUS(string DocCodigo, string DocSerie, Int64 DocNro)
        {
            try
            { return BD.OBTENERDETALLEBOLETA_BD(DocCodigo, DocSerie, DocNro); }
            catch (Exception ex) { throw; }
        }

        public SqlDataReader GETSOCIOBYNACIONALIDADDOCUMENTO_BUS(string Nacionalidad, string Documento)
        {
            try
            { return BD.GETSOCIOBYNACIONALIDADDOCUMENTO_BD(Nacionalidad, Documento); }
            catch (Exception ex) { throw; }
        }
    }
}
