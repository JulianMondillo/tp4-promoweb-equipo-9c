using Antlr.Runtime.Misc;
using CatalogoProductos.Datos.Repositorios;
using CatalogoProductos.Dominio.Entidades;
using CatalogoProductos.Negocio.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace CatalogoProductos.UI
{
    public partial class SeleccionarPremio : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarArticulos();
        }

        private void CargarArticulos()
        {

            NegocioArticulo negocioArticulo = new NegocioArticulo();
            var lista = negocioArticulo.Listar();
            rpArticulos.DataSource = lista;
            rpArticulos.DataBind();
        }

        protected void rpArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarPremio")
            {
                string artId = e.CommandArgument.ToString();
                // Guardás y pasás al paso de registro/confirmación
                Response.Redirect("~/RegistroCliente.aspx?artId=" + artId, false);
            }
        }

        protected string ObtenerImagenesCarrusel(object dataItem)
        {
            Articulo articulo = (Articulo)dataItem;

            // creo un string builder porque vamos a construir el html
            StringBuilder sb = new StringBuilder();

            if (articulo.Imagenes.Count > 0)
            {

                for (int i = 0; i < articulo.Imagenes.Count; i++)
                {
                    string active = i == 0 ? "active" : "";
                    sb.Append($@"
                        <div class='carousel-item {active}'>
                             <img src='{articulo.Imagenes[i].Url}' class='d-block w-100' style='height:250px; object-fit:contain; object-position:center;' />
                        </div>");
                }
            }
            else
            {
                sb.Append($@"
                    <div class='carousel-item'>
                        <img src='https://via.placeholder.com/600x400?text=Sin+Imagen' 
                            class='d-block w-100' 
                            style='height:250px; object-fit:contain; object-position:center; background-color:#f8f9fa;' />
                    </div>");
            }
            return sb.ToString();
        }
    }
}