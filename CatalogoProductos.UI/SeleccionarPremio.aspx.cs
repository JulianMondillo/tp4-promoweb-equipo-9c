using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CatalogoProductos.Dominio.Entidades;
using CatalogoProductos.Datos.Repositorios;

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
            RepositorioArticulo repo = new RepositorioArticulo();
            var lista = repo.Listar(); 
            rpArticulos.DataSource = lista;
            rpArticulos.DataBind();
        }

        protected void rpArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            Articulo art = (Articulo)e.Item.DataItem;

            string url = null;
            if (art.Imagenes != null && art.Imagenes.Count > 0 && !string.IsNullOrWhiteSpace(art.Imagenes[0].Url))
                url = art.Imagenes[0].Url;

            if (string.IsNullOrWhiteSpace(url))
                url = "https://via.placeholder.com/600x400?text=Sin+Imagen";

            Image img = (Image)e.Item.FindControl("imgArticulo");
            img.ImageUrl = url;
            img.AlternateText = art.Nombre;
        }

        protected void rpArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar Premio!")
            {
                string artId = e.CommandArgument.ToString();
                // Guardás y pasás al paso de registro/confirmación
                Response.Redirect("Registro.aspx?artId=" + artId, false);
            }
        }
    }
}