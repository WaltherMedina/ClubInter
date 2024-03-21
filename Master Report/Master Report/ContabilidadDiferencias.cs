using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClubIntBUS;

namespace Master_Report
{
    public partial class ContabilidadDiferencias : Form
    {
        ContabilidadDiferenciasBUS BUS = new ContabilidadDiferenciasBUS();
        SociosBUS BUSSOCIO = new SociosBUS();
        public ContabilidadDiferencias()
        {
            InitializeComponent();
        }

        private void btnBuscarFechas_Click(object sender, EventArgs e)
        {
            CargarBoletasDifIGV();
        }

        public void CargarBoletasDifIGV()
        {
            SqlDataReader reader;
            dataGridDifIGV.Rows.Clear();
            reader = BUS.BOLETASDIFIGV_BUS(dateTimePickerFechIni.Text,dateTimePickerFechFin.Text);
           try
            {
                while (reader.Read())
                {
                    dataGridDifIGV.Rows.Add();
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[0].Value = reader.GetValue(0);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[1].Value = reader.GetValue(1);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[2].Value = reader.GetValue(2);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[3].Value = reader.GetValue(3);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[4].Value = reader.GetValue(4);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[5].Value = reader.GetValue(5);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[6].Value = reader.GetValue(6);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[7].Value = reader.GetValue(7);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[8].Value = reader.GetValue(8);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[9].Value = reader.GetValue(9);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[10].Value = reader.GetValue(10);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[11].Value = reader.GetValue(11);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[12].Value = reader.GetValue(12);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[13].Value = reader.GetValue(13);
                    dataGridDifIGV.Rows[dataGridDifIGV.Rows.Count - 1].Cells[14].Value = reader.GetValue(14);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("No se pueden mostrar los datos, error: " + ex.ToString());
            }
            
        }

        private void dataGridDifIGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)         
                return;
            DataGridViewRow row = dataGridDifIGV.Rows[e.RowIndex];
            SqlDataReader reader;
            dataGridDetalleBoleta.Rows.Clear();
            reader = BUS.OBTENERDETALLEBOLETA_BUS(row.Cells["coDocCodigo"].Value as string, row.Cells["coSerie"].Value as string, (Int64)row.Cells["coNumero"].Value );
            try
            {
                while (reader.Read())
                {
                    dataGridDetalleBoleta.Rows.Add();
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[0].Value = reader.GetValue(0);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[1].Value = reader.GetValue(1);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[2].Value = reader.GetValue(2);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[3].Value = reader.GetValue(3);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[4].Value = reader.GetValue(4);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[5].Value = reader.GetValue(5);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[6].Value = reader.GetValue(6);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[7].Value = reader.GetValue(7);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[8].Value = reader.GetValue(8);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[9].Value = reader.GetValue(9);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[10].Value = reader.GetValue(10);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[11].Value = reader.GetValue(11);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[12].Value = reader.GetValue(12);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[13].Value = reader.GetValue(13);
                    dataGridDetalleBoleta.Rows[dataGridDetalleBoleta.Rows.Count - 1].Cells[14].Value = reader.GetValue(14);
                }
                
                lblComprobante.Text = row.Cells["coComPago"].Value as string;
                lblNumDoc.Text = row.Cells["coSerie"].Value as string + " - " + row.Cells["coNumero"].Value as string;
                lblFechPago.Text = row.Cells["coComPago"].Value as string;
                lblFechPago.Text = row.Cells["coFechaPago"].Value as string;
                lblHora.Text = row.Cells["coHoraPago"].Value as string;
                lblTotal.Text = row.Cells["coMontTotal"].Value.ToString() as string;
                lblRedondeo.Text = row.Cells["coMontoRedondeado"].Value.ToString() as string;
            }
                      
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden mostrar los datos, error: " + ex.ToString());
            }
        }

        private void pictureVer_Click(object sender, EventArgs e)
        {
            if (PanelInformacion.Width == 284) { PanelInformacion.Width = 0; }
            pictureVer.Visible = false;
            pictureOcultar.Visible = true;
        }

        private void pictureOcultar_Click(object sender, EventArgs e)
        {
            if (PanelInformacion.Width == 0) { PanelInformacion.Width = 284;}
            pictureOcultar.Visible = false;
            pictureVer.Visible = true;
        }

        private void dataGridDetalleBoleta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dataGridDetalleBoleta.Rows[e.RowIndex];
            SqlDataReader reader,reader2;
            reader = BUS.GETSOCIOBYNACIONALIDADDOCUMENTO_BUS(row.Cells["coNacionalidad"].Value as string,row.Cells["coDocumento"].Value as string);
            try
            {
                reader.Read();
                lblNumSoc.Text = reader.GetString(3);
                lblFamiliar.Text = reader.GetString(11);
                lblTipoSocio.Text = reader.GetString(7);
                lblEstado.Text = reader.GetString(9);
                reader2 = BUSSOCIO.GETEDADANTIGUEDAD_BUS(row.Cells["coNacionalidad"].Value as string, row.Cells["coDocumento"].Value as string);
                reader2.Read();
                lblEdad.Text = reader2.GetValue(0).ToString();
                if(reader2.GetValue(2).ToString() != "") { txtUltFechPago.Text = reader2.GetString(2); } else { txtUltFechPago.Text = ""; }              
                txtNombres.Text = reader.GetString(25);
                txtDocumento.Text = reader.GetString(1);
                txtDireccion.Text = reader.GetString(26);
                txtCiudad.Text = reader.GetString(39);
                txtProvincia.Text = reader.GetString(41);
                txtPais.Text = reader.GetString(2);
                txtEstadoCivil.Text = reader.GetString(56);
                if (picSocio.Image != null)
                    picSocio.Image.Dispose();
                picSocio.Image = Image.FromStream(BUSSOCIO.GETIMAGE_BUS(row.Cells["coNacionalidad"].Value as string, row.Cells["coDocumento"].Value as string,"N"));
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pueden mostrar los datos, error: " + ex.ToString());
            }
        }
    }
}
