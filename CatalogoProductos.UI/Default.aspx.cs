using CatalogoProductos.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CatalogoProductos.Negocio;

namespace CatalogoProductos.UI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnValidarVoucher_Click(object sender, EventArgs e)
        {
            string codigo = txbCodigo.Text?.Trim();

            ValidarCodigoVoucher(codigo);

        }


        private void ValidarCodigoVoucher(string codigo)
        {
            if (!ValidadorCampos.EsTextoObligatorio(codigo))
            {
                lblErrorValidacion.Text = "El código no puede estar vacío.";
                lblErrorValidacion.CssClass = "text-danger fs-5";
                return;
            }

            if (!ValidadorCampos.EsAlfanumerico(codigo))
            {
                lblErrorValidacion.Text = "El código sólo puede contener letras y números.";
                lblErrorValidacion.CssClass = "text-danger fs-5";
                return;
            }
            if (!ValidadorCampos.TieneLongitudMinima(codigo, 3))
            {
                lblErrorValidacion.Text = "El código debe contener entre 3 y 50 carácteres.";
                lblErrorValidacion.CssClass = "text-danger fs-5";
                return;
            }

            if (!lblErrorValidacion.CssClass.Contains("d-none"))
            {
                lblErrorValidacion.CssClass += " d-none";
            }

            NegocioVoucher negocioVoucher = new NegocioVoucher();
            string codigoNormalizado = ValidadorCampos.NormalizarTexto(codigo);
            try
            {
                bool esValido = negocioVoucher.ValidarVoucher(codigoNormalizado);

                if (esValido)
                {
                    Response.Redirect("SeleccionarPremio.aspx");
                }
                else
                {
                    lblErrorValidacion.Text = "El código ingresado no es válido.";
                    lblErrorValidacion.CssClass = "text-danger fs-5";
                }
            }
            catch (ArgumentException ex)
            {
                lblErrorValidacion.Text = ex.Message;
                lblErrorValidacion.CssClass = "text-danger fs-5";
            }
            catch (Exception)
            {
                lblErrorValidacion.Text = "Ocurrió un error al validar el voucher. Intente nuevamente más tarde.";
                lblErrorValidacion.CssClass = "text-danger fs-5";
            }
        }


    }
}