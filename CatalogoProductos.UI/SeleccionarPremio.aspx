<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionarPremio.aspx.cs" Inherits="CatalogoProductos.UI.SeleccionarPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-4">
        <div class="row justify-content-center g-4">

            <asp:Repeater ID="rpArticulos" runat="server">
                <ItemTemplate>
                    <div class="col-12 col-sm-6 col-md-4 col-lg-3 d-flex justify-content-center">

                        <%--card--%>
                        <div class="card h-100 shadow-sm border-0 rounded-4" style="width: 16rem;">

                            <%--Carrusel--%>
                            <div id="carousel<%# Eval("Id") %>" class="carousel slide card-img-top">
                                <div class="carousel-inner">
                                    <%# ObtenerImagenesCarrusel(Container.DataItem) %>
                                </div>


                                <asp:PlaceHolder ID="phCarouselControls" runat="server" Visible='<%# (int)Eval("Imagenes.Count") > 1 %>'>
                                    <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Eval("Id") %>" data-bs-slide="prev">
                                        <span class="carousel-control-prev-icon bg-dark"></span>
                                    </button>
                                    <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Eval("Id") %>" data-bs-slide="next">
                                        <span class="carousel-control-next-icon bg-dark"></span>
                                    </button>
                                </asp:PlaceHolder>
                            </div>

                            <div class="card-body text-center d-flex flex-column">
                                <h5 class="card-title mb-2"><%# Eval("Nombre") %></h5>
                                <p class="card-text text-muted small flex-grow-1"><%# Eval("Descripcion") %></p>

                                <button type="button"
                                    class="btn btn-primary w-100 rounded-pill mt-auto"
                                    data-id='<%# Eval("Id") %>'
                                    data-nombre='<%# Eval("Nombre") %>'
                                    data-desc='<%# Eval("Descripcion") %>'
                                    onclick="openConfirmModal(this)">
                                    Seleccionar Premio
                                </button>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <div class="modal fade" id="confirmModal" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content rounded-4">
                <div class="modal-body p-4">
                    <h5 class="mb-3">Confirmar selección</h5>
                    <div class="fw-semibold" id="mNombre"></div>
                    <div class="text-muted small" id="mDesc"></div>
                    <div class="d-flex justify-content-end gap-2 mt-4">
                        <button type="button" class="btn btn-dark" data-bs-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-primary" onclick="goToRegister()">Confirmar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        let selectedId = null;

        function openConfirmModal(btn) {
            selectedId = btn.getAttribute('data-id');
            document.getElementById('mNombre').textContent = btn.getAttribute('data-nombre') || '';
            document.getElementById('mDesc').textContent = btn.getAttribute('data-desc') || '';

            const modal = new bootstrap.Modal(document.getElementById('confirmModal'));
            modal.show();
        }

        function goToRegister() {
            window.location.href = '<%= ResolveUrl("~/RegistroCliente.aspx") %>?artId=' + encodeURIComponent(selectedId);
        }
    </script>
</asp:Content>
