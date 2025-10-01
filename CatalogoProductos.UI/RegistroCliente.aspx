<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="CatalogoProductos.UI.RegistroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <div class="card mx-auto shadow-sm rounded-4">
            <div class="card-header">
                <h3>Completa tu registro</h3>
            </div>

            <asp:Panel ID="pnlError" runat="server" CssClass="alert alert-danger" Visible="false">
                <asp:Label ID="lblErrorFormulario" runat="server" Text=""></asp:Label>
            </asp:Panel>


            <div class="card-body">

                <div class="mb-3">
                    <div class="input-group ">
                        <span class="input-group-text" id="addonDni">
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-person-vcard" viewBox="0 0 16 16">
                                <path d="M5 8a2 2 0 1 0 0-4 2 2 0 0 0 0 4m4-2.5a.5.5 0 0 1 .5-.5h4a.5.5 0 0 1 0 1h-4a.5.5 0 0 1-.5-.5M9 8a.5.5 0 0 1 .5-.5h4a.5.5 0 0 1 0 1h-4A.5.5 0 0 1 9 8m1 2.5a.5.5 0 0 1 .5-.5h3a.5.5 0 0 1 0 1h-3a.5.5 0 0 1-.5-.5" />
                                <path d="M2 2a2 2 0 0 0-2 2v8a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V4a2 2 0 0 0-2-2zM1 4a1 1 0 0 1 1-1h12a1 1 0 0 1 1 1v8a1 1 0 0 1-1 1H8.96q.04-.245.04-.5C9 10.567 7.21 9 5 9c-2.086 0-3.8 1.398-3.984 3.181A1 1 0 0 1 1 12z" />
                            </svg>
                        </span>
                        <asp:TextBox ID="txtDni" CssClass="form-control" TextMode="Number" autocomplete="off" oninput="if(this.value<0){this.value='';}"  MaxLength="50" runat="server"></asp:TextBox>
                        <asp:Button ID="btnConsultarDni"
                            CssClass="btn btn-primary"
                            runat="server"
                            Text="Verificar DNI"
                            OnClick="btnConsultarDni_Click" />
                    </div>
                    <asp:Label ID="lblErrorDocumento" CssClass="text-danger fs-5" runat="server" Text=""></asp:Label>
                </div>

                <div class="mb-3">
                    <label class="form-label" for="txtNombre">Nombre</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtNombre" CssClass="form-control" Enabled="false" MaxLength="50" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblErrorNombre" CssClass="text-danger fs-5" runat="server" Text=""></asp:Label>
                </div>

                <div class="mb-3">
                    <label class="form-label" for="txtApellido">Apellido</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtApellido" CssClass="form-control" Enabled="false" MaxLength="50" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblErrorApellido" CssClass="text-danger fs-5" runat="server" Text=""></asp:Label>
                </div>

                <div class="mb-3">
                    <label class="form-label" for="txtEmail">Email</label>
                    <div class="input-group">
                        <span class="input-group-text" cssclass="form-control" id="addonEmail">@</span>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" Enabled="false" MaxLength="50" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblErrorEmail" CssClass="text-danger fs-5" runat="server" Text=""></asp:Label>
                </div>

                <div class="mb-3">
                    <label class="form-label" for="txtDireccion">Dirección</label>
                    <div class="input-group">
                        <span class="input-group-text" cssclass="form-control" id="addonDireccion">
                            <svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" fill="currentColor" class="bi bi-geo-alt" viewBox="0 0 16 16">
                                <path d="M12.166 8.94c-.524 1.062-1.234 2.12-1.96 3.07A32 32 0 0 1 8 14.58a32 32 0 0 1-2.206-2.57c-.726-.95-1.436-2.008-1.96-3.07C3.304 7.867 3 6.862 3 6a5 5 0 0 1 10 0c0 .862-.305 1.867-.834 2.94M8 16s6-5.686 6-10A6 6 0 0 0 2 6c0 4.314 6 10 6 10" />
                                <path d="M8 8a2 2 0 1 1 0-4 2 2 0 0 1 0 4m0 1a3 3 0 1 0 0-6 3 3 0 0 0 0 6" />
                            </svg>
                        </span>
                        <asp:TextBox ID="txtDireccion" CssClass="form-control" Enabled="false" MaxLength="50" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblErrorDireccion" CssClass="text-danger fs-5" runat="server" Text=""></asp:Label>
                </div>

                <div class="mb-3">
                    <label class="form-label" for="txtCiudad">Ciudad</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtCiudad" CssClass="form-control" Enabled="false" MaxLength="50" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblErrorCiudad" CssClass="text-danger fs-5" runat="server" Text=""></asp:Label>
                </div>

                <div class="mb-3">
                    <label class="form-label" for="txtCodigoPostal">Código Postal</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtCodigoPostal" CssClass="form-control" Enabled="false" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblErrorCodigoPostal" CssClass="text-danger fs-5" runat="server" Text=""></asp:Label>
                </div>

                <div class="mb-3">
                    <asp:CheckBox ID="cbxTerminos" CssClass="d-flex gap-2"
                        runat="server"
                        OnCheckedChanged="cbxTerminos_CheckedChanged"
                        AutoPostBack="true"
                        Text="Acepto los términos y condiciones" />
                </div>

                <div class="d-flex justify-content-end">
                    <asp:Button ID="btnRegistro"
                        CssClass="btn btn-lg btn-primary"
                        Enabled="false"
                        runat="server"
                        Text="¡Participar!"
                        OnClick="btnRegistro_Click" />
                </div>
            </div>
        </div>
    </div>



</asp:Content>
