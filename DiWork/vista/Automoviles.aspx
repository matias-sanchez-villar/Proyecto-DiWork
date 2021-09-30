<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Automoviles.aspx.cs" Inherits="vista.Automoviles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="container">
          <div class="row">
                <div class="col">
                    <h1 class="text-center m-2">Generar Auto</h1>
                </div>
           </div>
           <div class="row">
                <asp:UpdatePanel ID="udp" runat="server">
                   <ContentTemplate>
                        <div class="row">
                            <div class="col">
                                <asp:DropDownList class="form-control m-2" ID="ddlMarca" runat="server" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="Marcas" Value="#" />
                                </asp:DropDownList>
                            </div>
                            <div class="col">
                                <asp:DropDownList class="form-control m-2" ID="ddlModelo" runat="server">
                                    <asp:ListItem Text="Modelos" Value="#" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="col">
                    <asp:DropDownList class="form-control m-3" ID="ddlTipo" runat="server"></asp:DropDownList>
                </div>
                <div class="col">
                    <asp:DropDownList class="form-control m-3" ID="ddlPuerta" runat="server">
                        <asp:ListItem Text="Puertas" Value="#" />
                        <asp:ListItem Text="1" Value="1" />
                        <asp:ListItem Text="2" Value="2" />
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="4" Value="4" />
                        <asp:ListItem Text="5" Value="5" />
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <asp:TextBox class="form-control m-3" placeholder="Patente" ID="txtPatente" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Button class="btn btn-primary m-3" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                </div>

            </div>
         </div>



        <table class="table m-3">
            <thead>
                <tr>
                    <th scope="col">Marca</th>
                    <th scope="col">Modelo</th>
                    <th scope="col">Patente</th>
                    <th scope="col">Tipo</th>
                    <th scope="col">Puertas</th>
                    <th scope="col">Accion</th>
                </tr>
            </thead>
            <tbody>
                    <% foreach (controlador.Automovil item in LFAutomovil)
                       { %>
                        <tr>
                          <th><% = item.modelo.nombreMarca %></th>
                          <th><% = item.modelo.nombreModelo %></th>
                          <th><% = item.patente %></th>
                          <th><% = item.tipo.ToString() %></th>
                          <th><% = item.cantidadPuertas %></th>
                          <td>
                              <a href="?IDMarca=<% = item.patente %>">
                                  <i class="fas fa-trash-alt"></i>
                              </a>
                          </td>
                        </tr>
                    <% } %>
            </tbody>
        </table>


</asp:Content>
