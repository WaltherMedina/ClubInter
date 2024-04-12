using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Master_Report
{
    public partial class Principal : Form
    {
        Funciones funciones = new Funciones();
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
           
        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            LimpiarBotonesPrincipales();
            LimpiarBotonesSecundarios();
            PintarBoton(btnContabilidad);
            funciones.showSubMenu(panelMenuConta);
        }

        private void PintarBoton(Button btn) { btn.BackColor = Color.FromArgb(255, 128, 128); }
        private void LimpiarBotonesPrincipales()
        {
            btnContabilidad.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void LimpiarBotonesSecundarios()
        {
            btnDifIGV.BackColor = Color.FromArgb(50, 50, 50);
        }

        private void btnDifIGV_Click(object sender, EventArgs e)
        {
            LimpiarBotonesPrincipales();
            LimpiarBotonesSecundarios();
            PintarBoton(btnContabilidad);
            PintarBoton(btnDifIGV);
            ContabilidadDiferencias contabilidadDiferencias = new ContabilidadDiferencias();
            funciones.AbrirFormHijo(PanelPrincipal,contabilidadDiferencias);
        }
    }
}
