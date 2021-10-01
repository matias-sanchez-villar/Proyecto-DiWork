<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="presupuesto.aspx.cs" Inherits="vista.presupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
         <div class="row">
            <div class="col">
                <h1 class="text-center m-3">Generar Presupuesto Autos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:DropDownList ID="ddlPatenteAuto" class="form-control m-3" runat="server"></asp:DropDownList>
            </div>
            <div class="col">
                <asp:TextBox ID="txtManoObraAuto" class="form-control m-3" placeholder="Mano Obra" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:TextBox ID="txtTiempoAuto" class="form-control m-3" placeholder="Tiempo" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <textarea id="txtDescripcionAuto" placeholder="Descripcion" class="form-control m-3" rows="3"></textarea>
            </div>
        </div>
        <div class="row m-1">
            <div class="col d-flex justify-content-center">
                <a type="button" class="btn btn-primary m-2" data-bs-toggle="modal" data-bs-target="#Modal">Agregar repuesto</a>
                <asp:Button ID="btnAuto" runat="server" Text="Enviar" class="btn btn-primary m-2"/>
            </div>
        </div>
    </div>

    <hr/>

        <div class="container">
         <div class="row">
            <div class="col">
                <h1 class="text-center m-3">Generar Presupuesto Motos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:DropDownList ID="ddlPatenteMoto" class="form-control m-3" runat="server"></asp:DropDownList>
            </div>
            <div class="col">
                <asp:TextBox ID="txtManoObraMoto" class="form-control m-3" placeholder="Mano Obra" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:TextBox ID="txtTimpoMoto" class="form-control m-3" placeholder="Tiempo" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <textarea id="txtDescripcionMoto" placeholder="Descripcion" class="form-control m-3" rows="3"></textarea>
            </div>
        </div>
        <div class="row m-1">
            <div class="col d-flex justify-content-center">
                <a type="button" class="btn btn-primary m-2" data-bs-toggle="modal" data-bs-target="#Modal">Agregar repuesto</a>
                <asp:Button ID="btnMoto" runat="server" Text="Enviar" class="btn btn-primary m-2"/>
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
            <asp:Button ID="bntRepuesto" class="btn btn-primary" data-bs-dismiss="modal" runat="server" Text="Agregar" />
          </div>
        </div>
      </div>
    </div>

</asp:Content>
