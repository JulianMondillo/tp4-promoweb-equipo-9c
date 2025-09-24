<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogoProductos.UI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <section class="d-flex align-items-center justify-content-center flex-grow-1">
        <div class="card p-4 rounded-4 shadow w-100" style="max-width: 50rem;">
            <div class="d-flex justify-content-center mb-3">
                <h2>Ingresá el código del voucher</h2>
            </div>
            <div class="d-flex card-body flex-column flex-fill gap-4">
                <asp:TextBox
                    ID="txbCodigo"
                    CssClass="w-100 form-control form-control-lg text-center"
                    MaxLength="50"
                    Placeholder="Ejemplo: ABCD1234"
                    runat="server" />
                <div>
                    <asp:Button
                        ID="btnValidarVoucher"
                        CssClass="btn btn-primary w-100 rounded-3 btn-lg"
                        OnClick="btnValidarVoucher_Click"
                        runat="server"
                        Text="Continuar" />
                    
                    <asp:Label ID="lblErrorValidacion" CssClass="d-none" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </section>


</asp:Content>
