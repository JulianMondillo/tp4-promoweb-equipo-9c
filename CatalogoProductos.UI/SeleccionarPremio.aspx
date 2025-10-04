<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionarPremio.aspx.cs" Inherits="CatalogoProductos.UI.SeleccionarPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="premios-section container my-5">
        <div class="text-center mb-5">
            <h2 class="fw-bold text-gradient">Elegí tu premio favorito</h2>
            <p class="text-muted">Podés explorar las opciones disponibles antes de confirmar tu selección.</p>
        </div>

        <div class="row justify-content-center g-4">
            <asp:Repeater ID="rpArticulos" runat="server">
                <ItemTemplate>
                    <div class="col-12 col-sm-6 col-md-4 col-lg-3 d-flex justify-content-center">
                        <div class="card premio-card h-100 rounded-4 shadow-sm">
                            
                            <!-- Carrusel de imágenes -->
                            <div id="carousel<%# Eval("Id") %>" class="carousel slide card-img-top">
                                <div class="carousel-inner">
                                    <%# ObtenerImagenesCarrusel(Container.DataItem) %>
                                </div>

                                <asp:PlaceHolder ID="phCarouselControls" runat="server" Visible='<%# (int)Eval("Imagenes.Count") > 1 %>'>
                                    <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Eval("Id") %>" data-bs-slide="prev">
                                        <span class="carousel-control-prev-icon"></span>
                                    </button>
                                    <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Eval("Id") %>" data-bs-slide="next">
                                        <span class="carousel-control-next-icon"></span>
                                    </button>
                                </asp:PlaceHolder>
                            </div>

                            <!-- Contenido de la tarjeta -->
                            <div class="card-body text-center d-flex flex-column">
                                <h5 class="card-title fw-bold mb-2"><%# Eval("Nombre") %></h5>
                                <p class="card-text text-muted small flex-grow-1"><%# Eval("Descripcion") %></p>

                                <button
                                    type="button"
                                    class="btn btn-primary rounded-pill mt-auto"
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
    </section>

    <!-- Modal de confirmación -->
    <div class="modal fade" id="confirmModal" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content rounded-4 shadow-lg">
                <div class="modal-body p-4">
                    <h5 class="fw-bold mb-3 text-gradient">Confirmar selección</h5>
                    <div id="mNombre" class="fw-semibold"></div>
                    <div id="mDesc" class="text-muted small mb-3"></div>
                    <div class="d-flex justify-content-end gap-2 mt-3">
                        <button type="button" class="btn btn-outline-secondary rounded-pill" data-bs-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-primary rounded-pill" onclick="goToRegister()">Confirmar</button>
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
