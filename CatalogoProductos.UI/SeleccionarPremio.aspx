<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionarPremio.aspx.cs" Inherits="CatalogoProductos.UI.SeleccionarPremio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container my-4">
  <div class="row justify-content-center g-4">
    <asp:Repeater ID="rpArticulos" runat="server" OnItemDataBound="rpArticulos_ItemDataBound">
      <ItemTemplate>
        <div class="col-12 col-sm-6 col-md-4 col-lg-3 d-flex justify-content-center">
          <div class="card h-100 shadow-sm border-0 rounded-4" style="width: 16rem;">
            <asp:Image ID="imgArticulo" runat="server"
                       CssClass="card-img-top rounded-top-4"
                       Style="object-fit:cover;height:180px;" />
            <div class="card-body text-center">
              <h5 class="card-title mb-2"><%# Eval("Nombre") %></h5>
              <p class="card-text text-muted small"><%# Eval("Descripcion") %></p>
              <asp:LinkButton ID="btnSeleccionar" runat="server"
                              CssClass="btn btn-primary w-100 rounded-pill"
                              CommandName="SeleccionarPremio"
                              CommandArgument='<%# Eval("Id") %>'
                              Text="Seleccionar Premio" />
            </div>
          </div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>

</asp:Content>
