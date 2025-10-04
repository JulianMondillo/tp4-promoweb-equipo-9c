<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="CatalogoProductos.UI.RegistroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="upFormularioRegistro" runat="server" UpdateMode="Always">
        <ContentTemplate>

            <section class="container my-4 d-flex justify-content-center">
                <div class="card shadow-sm rounded-4 w-100" style="max-width: 40rem;">

                    <div class="card-header text-center">
                        <h3>Completa tu registro</h3>
                    </div>

                    <asp:Panel ID="pnlError" runat="server" CssClass="alert alert-danger rounded-4 mx-3 mt-3" Visible="false">
                        <asp:Label ID="lblErrorFormulario" runat="server" Text=""></asp:Label>
                    </asp:Panel>

                    <div class="card-body d-flex flex-column gap-3">


                        <div class="mb-3">
                            <label class="form-label" for="txtDni">Documento de Identidad</label>
                            <div class="input-group">
                                <span class="input-group-text" id="addonDni">
                                    <i class="bi bi-person-vcard"></i>
                                </span>
                                <asp:TextBox ID="txtDni" CssClass="form-control" TextMode="Number" MaxLength="8" autocomplete="off" runat="server" />
                                <asp:Button ID="btnConsultarDni" CssClass="btn btn-primary rounded-pill mx-1" runat="server" Text="Verificar DNI" OnClick="btnConsultarDni_Click" />
                            </div>
                            <asp:Label ID="lblErrorDocumento" CssClass="text-danger fs-6" runat="server" Text=""></asp:Label>
                        </div>


                        <div class="mb-3">
                            <label class="form-label" for="txtNombre">Nombre</label>
                            <asp:TextBox ID="txtNombre" CssClass="form-control" Enabled="false" MaxLength="50" runat="server"></asp:TextBox>
                            <asp:Label ID="lblErrorNombre" CssClass="text-danger fs-6" runat="server" Text=""></asp:Label>
                        </div>


                        <div class="mb-3">
                            <label class="form-label" for="txtApellido">Apellido</label>
                            <asp:TextBox ID="txtApellido" CssClass="form-control" Enabled="false" MaxLength="50" runat="server"></asp:TextBox>
                            <asp:Label ID="lblErrorApellido" CssClass="text-danger fs-6" runat="server" Text=""></asp:Label>
                        </div>


                        <div class="mb-3">
                            <label class="form-label" for="txtEmail">Email</label>
                            <div class="input-group">
                                <span class="input-group-text">@</span>
                                <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" Enabled="false" MaxLength="50" runat="server"></asp:TextBox>
                            </div>
                            <asp:Label ID="lblErrorEmail" CssClass="text-danger fs-6" runat="server" Text=""></asp:Label>
                        </div>


                        <div class="mb-3">
                            <label class="form-label" for="txtDireccion">Dirección</label>
                            <div class="input-group">
                                <span class="input-group-text"><i class="bi bi-geo-alt"></i></span>
                                <asp:TextBox ID="txtDireccion" CssClass="form-control" Enabled="false" MaxLength="50" runat="server"></asp:TextBox>
                            </div>
                            <asp:Label ID="lblErrorDireccion" CssClass="text-danger fs-6" runat="server" Text=""></asp:Label>
                        </div>


                        <div class="mb-3">
                            <label class="form-label" for="txtCiudad">Ciudad</label>
                            <asp:TextBox ID="txtCiudad" CssClass="form-control" Enabled="false" MaxLength="50" runat="server"></asp:TextBox>
                            <asp:Label ID="lblErrorCiudad" CssClass="text-danger fs-6" runat="server" Text=""></asp:Label>
                        </div>


                        <div class="mb-3">
                            <label class="form-label" for="txtCodigoPostal">Código Postal</label>
                            <asp:TextBox ID="txtCodigoPostal" CssClass="form-control" Enabled="false" TextMode="Number" runat="server"></asp:TextBox>
                            <asp:Label ID="lblErrorCodigoPostal" CssClass="text-danger fs-6" runat="server" Text=""></asp:Label>
                        </div>


                        <div class="mb-3">
                            <asp:CheckBox ID="cbxTerminos" CssClass="d-flex gap-2" runat="server" OnCheckedChanged="cbxTerminos_CheckedChanged" AutoPostBack="true" Text="Acepto los términos y condiciones" />
                        </div>


                        <div class="d-flex justify-content-end">
                            <asp:Button ID="btnRegistro" CssClass="btn btn-primary btn-lg rounded-pill" Enabled="false" runat="server" Text="¡Participar!" OnClick="btnRegistro_Click" />
                        </div>

                    </div>
                </div>
            </section>

        </ContentTemplate>
    </asp:UpdatePanel>


    <script>
        function OcultarErrorAlEscribir(campoId, labelId) {
            const campo = document.getElementById(campoId);
            const label = document.getElementById(labelId);

            campo.addEventListener('input', function () {
                if (campo.value.trim() !== "") {
                    label.style.display = 'none'; 
                    campo.classList.remove('is-invalid'); 
                }
            });
        }

    </script>

</asp:Content>
