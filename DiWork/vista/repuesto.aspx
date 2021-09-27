<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="repuesto.aspx.cs" Inherits="vista.repuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="container">
      <div class="row">
        <div class="col">
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" class="form-control m-2"></asp:TextBox>
        </div>
        <div class="col">
            <asp:TextBox type="number" ID="txtPrecio" runat="server" placeholder="Precio" class="form-control m-2"></asp:TextBox>
        </div>
        <div class="col">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="btn btn-primary m-2" OnClick="btnAgregar_Click"/>
        </div>
      </div>
    </div>

    <div class="container">
      <div class="row">
        <div class="col m-3">

            <table class="table">
              <thead>
                <tr>
                  <th scope="col">ID</th>
                  <th scope="col">Nombre</th>
                  <th scope="col">Precio</th>
                  <th scope="col">Accion</th>
                </tr>
              </thead>
              <tbody>
                    <% foreach (controlador.Repuesto item in lRepuesto)
                       { %>
                        <tr>
                          <th><% = item.ID %></th>
                          <td><% = item.nombre %></td>
                          <td><% = item.precio %></td>
                          <td>
                              <a href="?ID=<% = item.ID %>">
                                  <i class="fas fa-trash-alt"></i>
                              </a>
                          </td>
                        </tr>
                    <% } %>
              </tbody>
            </table>

        </div>
      </div>
    </div>


</asp:Content>
