using CatalogoProductos.Comun;
using CatalogoProductos.Dominio.Entidades;
using CatalogoProductos.Negocio;
using CatalogoProductos.Negocio.Clientes;
using CatalogoProductos.Negocio.Participacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoProductos.UI
{
    public partial class RegistroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // si falta el id de articulo o el codigo no se debe permitir estar en la vista
                ValidarParametrosRequeridos();
            }
        }


        private bool EsDocumentoValido(string documento)
        {
            if (!ValidadorCampos.EsTextoObligatorio(documento))
            {
                lblErrorDocumento.Text = "El campo documento no puede estar vacío";
                return false;
            }

            if (!ValidadorCampos.EsNumerico(documento))
            {
                lblErrorDocumento.Text = "El documento debe contener solo dígitos numéricos.";
                return false;
            }

            return true;
        }


        private Cliente BuscarCliente(string documento)
        {
            NegocioCliente negocioCliente = new NegocioCliente();

            try
            {
                return negocioCliente.ObtenerPorDocumento(documento);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void HabilitarFormularioRegistro()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtEmail.Enabled = true;
            txtDireccion.Enabled = true;
            txtCiudad.Enabled = true;
            txtCodigoPostal.Enabled = true;
        }


        private void ActualizarEstadoBotonRegistro()
        {
            if (cbxTerminos.Checked)
            {
                btnRegistro.Enabled = true;
            }
            else
            {
                btnRegistro.Enabled = false;
            }
        }


        private bool EsFormularioRegistroValido()
        {
            ReiniciarValidaciones();
            bool esValido = true;
            if (!ValidadorCampos.EsTextoObligatorio(txtNombre.Text?.Trim()) ||
                !ValidadorCampos.EsTextoValido(txtNombre.Text?.Trim(), 2, 50))
            {
                MostrarErrorCampo(lblErrorNombre, txtNombre, "El nombre es obligatorio y debe tener entre 2 y 50 caracteres.");
                esValido = false;
            }
            if (!ValidadorCampos.EsTextoObligatorio(txtApellido.Text?.Trim()) ||
                !ValidadorCampos.EsTextoValido(txtApellido.Text?.Trim(), 2, 50))
            {
                MostrarErrorCampo(lblErrorApellido, txtApellido, "El apellido es obligatorio y debe tener entre 2 y 50 caracteres.");
                esValido = false;
            }
            if (!ValidadorCampos.EsTextoObligatorio(txtEmail.Text?.Trim()) ||
                !ValidadorCampos.EsEmailValido(txtEmail.Text?.Trim()))
            {
                MostrarErrorCampo(lblErrorEmail, txtEmail, "El email es obligatorio y debe tener un formato válido.");
                esValido = false;
            }
            if (!ValidadorCampos.EsTextoObligatorio(txtDireccion.Text?.Trim()) ||
                !ValidadorCampos.EsTextoValido(txtDireccion.Text?.Trim(), 2, 50))
            {
                MostrarErrorCampo(lblErrorDireccion, txtDireccion, "La dirección es obligatoria y debe tener entre 2 y 50 caracteres.");
                esValido = false;
            }
            if (!ValidadorCampos.EsTextoObligatorio(txtCiudad.Text?.Trim()) ||
                !ValidadorCampos.EsTextoValido(txtCiudad.Text?.Trim(), 2, 50))
            {
                MostrarErrorCampo(lblErrorCiudad, txtCiudad, "La ciudad es obligatoria y debe tener entre 2 y 50 caracteres.");
                esValido = false;
            }
            if (!ValidadorCampos.EsTextoObligatorio(txtCodigoPostal.Text?.Trim()) ||
                !ValidadorCampos.EsNumerico(txtCodigoPostal.Text?.Trim()))
            {
                MostrarErrorCampo(lblErrorCodigoPostal, txtCodigoPostal, "El código postal es obligatorio y debe ser numérico.");
                esValido = false;
            }

            return esValido;
        }

        private void RegistrarCliente()
        {
            // método para crear el objeto del nuevo cliente y guardarlo
            NegocioCliente negocioCliente = new NegocioCliente();
            try
            {

                Cliente cliente = new Cliente
                {
                    Dni = txtDni.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Ciudad = txtCiudad.Text.Trim(),
                    CodigoPostal = int.Parse(txtCodigoPostal.Text.Trim())
                };

                if (Session["IdCliente"] != null)
                {
                    cliente.Id = int.Parse(Session["IdCliente"].ToString());
                }

                string idArticulo = Request.QueryString["artId"];
                var codigo = Session["codigoVoucher"] as string;

                Voucher voucher = new Voucher
                {
                    Codigo = codigo,
                    Cliente = cliente,
                    FechaCanje = DateTime.Now,
                    Articulo = new Articulo
                    {
                        Id = int.Parse(idArticulo),
                    }
                };

                NegocioParticipacion negocioParticipacion = new NegocioParticipacion();
                negocioParticipacion.RegistrarParticipacion(cliente, voucher);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void MostrarAlertaErrorInesperado(string mensajeError)
        {
            // muestra el alert de error
            pnlError.Visible = true;
            lblErrorFormulario.Text = mensajeError;
        }

        private void MostrarErrorCampo(Label lblError, TextBox txtCampo, string mensaje)
        {
            // método para mpstrar los errores en cada campo
            lblError.Text = mensaje;
            lblError.Visible = true;
            txtCampo.CssClass += " is-invalid";
        }

        private void ReiniciarValidaciones()
        {
            // método para limpiar los errores de los campos

            lblErrorNombre.Text = lblErrorApellido.Text = lblErrorEmail.Text =
            lblErrorDireccion.Text = lblErrorCiudad.Text = lblErrorCodigoPostal.Text = "";

            lblErrorNombre.Visible = lblErrorApellido.Visible = lblErrorEmail.Visible =
            lblErrorDireccion.Visible = lblErrorCiudad.Visible = lblErrorCodigoPostal.Visible = false;


            txtNombre.CssClass = txtNombre.CssClass.Replace(" is-invalid", "");
            txtApellido.CssClass = txtApellido.CssClass.Replace(" is-invalid", "");
            txtEmail.CssClass = txtEmail.CssClass.Replace(" is-invalid", "");
            txtDireccion.CssClass = txtDireccion.CssClass.Replace(" is-invalid", "");
            txtCiudad.CssClass = txtCiudad.CssClass.Replace(" is-invalid", "");
            txtCodigoPostal.CssClass = txtCodigoPostal.CssClass.Replace(" is-invalid", "");
        }


        private void OcultarErrorInseperado()
        {
            // Oculta el alert de error
            pnlError.Visible = false;
            lblErrorFormulario.Text = "";
        }

        private void PrecargarFormulario(Cliente cliente)
        {
            // método para precargar los datos del cliente en el formulario.
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtEmail.Text = cliente.Email;
            txtDireccion.Text = cliente.Direccion;
            txtCiudad.Text = cliente.Ciudad;
            txtCodigoPostal.Text = cliente.CodigoPostal.ToString();
        }

        protected void btnConsultarDni_Click(object sender, EventArgs e)
        {
            string documento = txtDni.Text?.Trim();
            if (!EsDocumentoValido(documento))
            {
                return;
            }
            lblErrorDocumento.Text = "";

            try
            {
                OcultarErrorInseperado(); // limpiamos el error del alert si es que existía uno.
                Cliente cliente = BuscarCliente(documento);

                if (cliente != null)
                {
                    // habilitar formulario y precargar los datos en el formulario de registro
                    HabilitarFormularioRegistro();
                    PrecargarFormulario(cliente);

                    // guardar el id en la Session para su posterior uso en el registro (actualizar datos)
                    Session["IdCliente"] = cliente.Id;
                }
                else
                {
                    // habilitar el formulario
                    HabilitarFormularioRegistro();
                }
            }
            catch (Exception)
            {
                MostrarAlertaErrorInesperado("Ocurrió un error inesperado. Por favor, inténtalo nuevamente.");
            }
        }

        protected void cbxTerminos_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoBotonRegistro();
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsFormularioRegistroValido())
                {
                    return;
                }
                else
                {
                    RegistrarCliente();

                    Session.Remove("codigoVoucher");
                    Session.Remove("premioSeleccionado");

                    Response.Redirect("~/Exito.aspx", true);
                }
            }
            catch (Exception)
            {
                MostrarAlertaErrorInesperado("Ocurrió un error inesperado. Por favor, inténtalo nuevamente.");
            }
        }
        private void ValidarParametrosRequeridos()
        {
            string idArticulo = Request.QueryString["artId"];
            string codigo = Session["codigoVoucher"] as string;

            if (string.IsNullOrEmpty(idArticulo) && string.IsNullOrEmpty(codigo))
            {
                Response.Redirect("Default.aspx", true);
            }
            else if (string.IsNullOrEmpty(idArticulo) && !string.IsNullOrEmpty(codigo))
            {
                Response.Redirect("SeleccionarPremio.aspx", true);
            }
        }
    }
}