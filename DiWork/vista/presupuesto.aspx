<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="presupuesto.aspx.cs" Inherits="vista.presupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">
        <div class="row">
            <div class="col">
                <h1 class="text-center m-3">Generar Presupuesto Autos</h1>
            </div>
        </div>
        <asp:UpdatePanel ID="udp" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col">
                        <asp:DropDownList ID="ddlTipoVehiculo" runat="server" AutoPostBack="True" class="form-control m-3" OnSelectedIndexChanged="ddlTipoVehiculo_SelectedIndexChanged">
                            <asp:ListItem Text="Tipo de Vehiculo" Value="0" />
                            <asp:ListItem Text="Automovil" Value="1" />
                            <asp:ListItem Text="Moto" Value="2" />
                        </asp:DropDownList>
                    </div>
                    <div class="col">
                        <asp:DropDownList ID="ddlPatente" class="form-control m-3" runat="server">
                            <asp:ListItem Text="Patentes" Value="#" />
                        </asp:DropDownList>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row">
            <div class="col">
                <asp:TextBox ID="txtManoObra" type="number" class="form-control m-3" placeholder="Mano Obra" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:TextBox ID="txtTiempo" type="number" class="form-control m-3" placeholder="Tiempo" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <textarea id="txtDescripcion" placeholder="Descripcion" class="form-control m-3" rows="3"></textarea>
            </div>
        </div>

        <div class="row" id="tableRepuestos">
            <div class="col m-3">
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">ID</th>
                            <th scope="col">Repuesto</th>
                            <th scope="col">Precio</th>
                            <th scope="col">Accion</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% foreach (controlador.Repuesto item in LFRepuestos)
                            { %>
                        <tr>
                            <th><% = item.ID %></th>
                            <td><% = item.nombre %></td>
                            <td><% = item.precio %></td>
                            <td>
                                <a href="?IDRepuesto=<% = item.ID %>">
                                    <i class="fas fa-trash-alt"></i>
                                </a>
                            </td>
                        </tr>
                        <% } %>
                    </tbody>
                </table>
            </div>
        </div>

        <div class="row m-1">
            <div class="col d-flex justify-content-center">
                <a type="button" class="btn btn-primary m-2" data-bs-toggle="modal" data-bs-target="#Modal">Agregar repuesto</a>
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" class="btn btn-primary m-2" OnClick="btnEnviar_Click" />
            </div>
        </div>
    </div>


    <div class="modal fade" id="Modal" tabindex="-1" aria-labelledby="modalTitle" aria-hidden="true" data-bs-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalTitle">Repuestos</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <div class="modal-body">
                    <p>Elige el respuesto que quieres agregar</p>

                    <div class="form-group">
                        <label for="recipient-name" class="col-form-label">Repuestos:</label>
                        <asp:DropDownList ID="ddlRepuestos" class="form-control" runat="server"></asp:DropDownList>
                    </div>

                </div>
                <div class="modal-footer">
                    <asp:Button ID="bntRepuesto" class="btn btn-primary" data-bs-dismiss="modal" runat="server" Text="Agregar" OnClick="bntRepuesto_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
