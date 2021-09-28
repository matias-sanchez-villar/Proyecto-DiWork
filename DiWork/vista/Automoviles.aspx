<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Automoviles.aspx.cs" Inherits="vista.Automoviles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class="container">
          <div class="row">
                <div class="col">
                    <h1 class="text-center m-2">Generar Auto</h1>
                </div>
           </div>
           <div class="row">
                <div class="col">
                    <asp:DropDownList class="form-control m-3" ID="ddlMarca" runat="server"></asp:DropDownList>
                </div>
                <div class="col">
                    <asp:DropDownList class="form-control m-3" ID="ddlModelo" runat="server"></asp:DropDownList>
                </div>
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


</asp:Content>
