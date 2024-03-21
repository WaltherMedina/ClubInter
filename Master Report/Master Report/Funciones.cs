using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Master_Report
{
    internal class Funciones
    {
        public void AbrirFormHijo(Panel paPrincipal,object formhijo)
        {
            if (paPrincipal.Controls.Count > 0)
            {
                paPrincipal.Controls.RemoveAt(0);
            }

            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            paPrincipal.Controls.Add(fh);
            paPrincipal.Tag = fh;
            fh.Show();

        }

        private void hideSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == true)
            {
                subMenu.Visible = true;
            }
        }

        public void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu(subMenu);
                subMenu.Visible = true;
            }
        }

        /*private void hideMenuUno()
        {
            if (panelMenuConta.Visible == true)
            {
                panelMenuConta.Visible = false;
            }
        }*/
    }
}
