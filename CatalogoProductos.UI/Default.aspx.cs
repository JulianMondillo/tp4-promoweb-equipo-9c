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
            if (!IsPostBack)
            {
                ObtenerCodigoSession();
            }
        }

        protected void btnValidarVoucher_Click(object sender, EventArgs e)
        {
            string codigo = txbCodigo.Text?.Trim();

            string codigoNormalizado = ValidadorCampos.NormalizarTexto(codigo);

            // comparamos si el codigo del textbox es igual al de la sesión, si cambió, entonces limpiamos la sesión
            CompararCodigoTextboxYSession(codigoNormalizado);

            ValidarCodigoVoucher(codigoNormalizado);

            // como master determina el layout y opciones comunes, aquí accedemos su método de configurar el stepper
            // de esta manera podemos mantener actualizado correctamente los pasos dependiendo de lo que exista en Session
            var master = (SiteMaster)this.Master;
            master.ConfigurarStepper();
        }


        private void ValidarCodigoVoucher(string codigo)
        {
            if (!EsFormatoValido(codigo))
            {
                return;
            }

            NegocioVoucher negocioVoucher = new NegocioVoucher();

            try
            {
                bool esValido = negocioVoucher.ValidarVoucher(codigo);

                if (esValido)
                {
                    Session.Add("codigoVoucher", codigo);
                    Response.Redirect("SeleccionarPremio.aspx", false);
                }
                else
                {
                    lblErrorValidacion.Text = "El código ingresado no es válido.";
                    lblErrorValidacion.CssClass = "text-danger fs-5";
                    ResetearSession();
                }
            }
            catch (ArgumentException ex)
            {
                lblErrorValidacion.Text = ex.Message;
                lblErrorValidacion.CssClass = "text-danger fs-5";
                ResetearSession();
            }
            catch (Exception)
            {
                lblErrorValidacion.Text = "Ocurrió un error al validar el voucher. Intente nuevamente más tarde.";
                lblErrorValidacion.CssClass = "text-danger fs-5";
                ResetearSession();
            }
        }


        private bool EsFormatoValido(string codigo)
        {
            if (!ValidadorCampos.EsTextoObligatorio(codigo))
            {
                lblErrorValidacion.Text = "El código no puede estar vacío.";
                lblErrorValidacion.CssClass = "text-danger fs-5";
                return false;
            }

            if (!ValidadorCampos.EsAlfanumerico(codigo))
            {
                lblErrorValidacion.Text = "El código sólo puede contener letras y números.";
                lblErrorValidacion.CssClass = "text-danger fs-5";
                return false;
            }
            if (!ValidadorCampos.TieneLongitudMinima(codigo, 3))
            {
                lblErrorValidacion.Text = "El código debe contener entre 3 y 50 carácteres.";
                lblErrorValidacion.CssClass = "text-danger fs-5";
                return false;
            }

            if (!lblErrorValidacion.CssClass.Contains("d-none"))
            {
                lblErrorValidacion.CssClass += " d-none";
            }

            return true;
        }

        private void ObtenerCodigoSession()
        {
            if (Session["codigoVoucher"] != null)
            {
                string codigoVoucher = Session["codigoVoucher"].ToString();
                txbCodigo.Text = codigoVoucher;
            }
        }


        private void ResetearSession()
        {
            Session.Clear();
        }

        private void CompararCodigoTextboxYSession(string codigoIngresado)
        {
            string codigoSession = Session["codigoVoucher"]?.ToString();
            if (codigoSession != null && codigoSession != codigoIngresado)
            {
                ResetearSession();
            }
        }


    }
}