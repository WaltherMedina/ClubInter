using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterBD;

namespace MasterBUS
{
    public class ClaContabilidadDiferenciasBUS
    {
        ClaContabilidadDiferenciasBD BD = new ClaContabilidadDiferenciasBD();
        public SqlDataReader BOLETASDIFIGV_BUS( DateTime FechIni, DateTime FechFin)
        {
            try
            {
                return BD.BOLETASDIFIGV_BD(FechIni, FechFin);
            }catch (Exception ex)
            {
                throw;
            }
        }

    }
}
