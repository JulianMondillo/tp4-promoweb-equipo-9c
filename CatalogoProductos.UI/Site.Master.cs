using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoProductos.UI
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // siempre se ejecuta, como depende de la session no necesitamos saber si es postback o no.
            ConfigurarStepper();
        }


        private void ActivarPaso(HyperLink hl)
        {
            hl.Enabled = true;
            hl.CssClass = hl.CssClass.Replace("disabled", "").Replace("btn-dark", "btn-primary");
        }

        private void DesactivarPaso(HyperLink hl)
        {
            hl.Enabled = false;
            hl.CssClass = "btn btn-dark disabled d-flex align-items-center";
        }

        public void ConfigurarStepper()
        {
            var codigoVoucher = Session["codigoVoucher"];
            var premioSeleccionado = Session["premioSeleccionado"];
            // el paso 1 siempre estará activo.

            // el paso 2 solo se activará si hay un codigo en el objeto Session
            if (codigoVoucher != null)
            {
                ActivarPaso(hlSegundoPaso);
            }
            else
            {
                DesactivarPaso(hlSegundoPaso);
            }

            // el paso 3 se activará si hay un codigo y un premio seleccionado dentro de Session
            if (codigoVoucher != null && premioSeleccionado != null)
            {
                ActivarPaso(hlTercerPaso);
            }
            else
            {
                DesactivarPaso(hlTercerPaso);
            }
        }

    }
}