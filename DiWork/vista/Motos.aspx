<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Motos.aspx.cs" Inherits="vista.Motos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container">
          <div class="row">
                <div class="col">
                    <h1 class="text-center m-2">Generar moto</h1>
                </div>
           </div>
           <div class="row">
                <div class="col">
                    <asp:DropDownList class="form-control m-2" ID="ddlMarca" runat="server" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="col">
                    <asp:DropDownList class="form-control m-2" ID="ddlModelo" runat="server"></asp:DropDownList>
                </div>
                <div class="col">
                    <asp:TextBox class="form-control m-2" placeholder="Patente" ID="txtPatente" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:TextBox type="number" class="form-control m-2" placeholder="Cilindrada" ID="txtCilindrada" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Button class="btn btn-primary m-2" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                </div>

            </div>
         </div>


            <table class="table m-3">
              <thead>
                <tr>
                  <th scope="col">ID</th>
                  <th scope="col">Marca</th>
                  <th scope="col">Modelo</th>
                  <th scope="col">Patente</th>
                  <th scope="col">Cilindrada</th>
                  <th scope="col">Accion</th>
                </tr>
              </thead>
              <tbody>
                    <% foreach (controlador.Moto item in lMoto)
                       { %>
                        <tr>
                          <th><% = item.ID %></th>
                          <th><% = item.modelo.nombreMarca %></th>
                          <th><% = item.modelo.nombreModelo %></th>
                          <th><% = item.patente %></th>
                          <td><% = item.cilindrada %></td>
                          <td>
                              <a href="?IDMarca=<% = item.ID %>">
                                  <i class="fas fa-trash-alt"></i>
                              </a>
                          </td>
                        </tr>
                    <% } %>
              </tbody>
            </table>

</asp:Content>
