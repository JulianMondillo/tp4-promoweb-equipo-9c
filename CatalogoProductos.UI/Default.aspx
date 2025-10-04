<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogoProductos.UI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Banner principal -->
    <section class="banner my-4">
        <h1>🎁 ¡Participá en la Promo Ganá!</h1>
        <p>Ingresá tu código del voucher y elegí el premio que querés ganar.</p>

        <!-- SVGs decorativos -->
        <svg class="gift1" viewBox="0 0 100 100" fill="none">
            <rect x="15" y="40" width="70" height="50" fill="#FF6B9D" rx="3"/>
            <rect x="15" y="30" width="70" height="15" fill="#FF8FB3" rx="3"/>
        </svg>

        <svg class="gift2" viewBox="0 0 100 100" fill="none">
            <rect x="15" y="40" width="70" height="50" fill="#4ECDC4" rx="3"/>
            <rect x="15" y="30" width="70" height="15" fill="#6FE7DD" rx="3"/>
        </svg>
    </section>

    <!-- Sección de ingreso del código -->
    <section class="voucher-section d-flex align-items-center justify-content-center flex-grow-1">
        <div class="card voucher-card p-4 rounded-4 shadow-lg w-100">
            <div class="text-center mb-4">
                <h2 class="fw-bold text-gradient">Ingresá el código del voucher</h2>
            </div>

            <div class="d-flex flex-column gap-4">
                <asp:TextBox
                    ID="txbCodigo"
                    CssClass="form-control form-control-lg text-center"
                    MaxLength="50"
                    Placeholder="Ejemplo: ABCD1234"
                    runat="server" />

                <asp:Button
                    ID="btnValidarVoucher"
                    CssClass="btn btn-primary btn-lg w-100 rounded-pill"
                    OnClick="btnValidarVoucher_Click"
                    runat="server"
                    Text="Continuar" />

                <asp:Label
                    ID="lblErrorValidacion"
                    CssClass="text-danger fw-semibold mt-2 text-center d-none"
                    runat="server"
                    Text=""></asp:Label>
            </div>
        </div>
    </section>


</asp:Content>
