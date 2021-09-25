﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="marcaModelo.aspx.cs" Inherits="vista.marcaModelo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
      <div class="row">
        <div class="col">
            <h1 class="text-center m-2">Generar Marca</h1>

            <asp:TextBox ID="txtMarca" runat="server" class="form-control m-2" placeholder="Marca"></asp:TextBox>
            <asp:Button ID="btnEnviarMarca" runat="server" Text="Agregar"  class="btn btn-primary m-2"/>

        </div>

        <div class="col">

            <h1 class="text-center m-2">Generar Modelo</h1>
            <asp:DropDownList class="form-control m-2" ID="ddlMarca" runat="server"></asp:DropDownList>
            <asp:TextBox ID="txtModelo" runat="server" class="form-control m-2" placeholder="Modelo"></asp:TextBox>
            <asp:Button ID="btnEnviarModelo" runat="server" Text="Agregar"  class="btn btn-primary m-2"/>

        </div>
      </div>
    </div>

</asp:Content>