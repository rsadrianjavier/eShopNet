<%@ Page Title="Editar Pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderEdit.aspx.cs" Inherits="eShop.Web.Admin.OrderEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="form-horizontal">
        <h2><%: Title %></h2>
        <br />
        <asp:ValidationSummary runat="server" id="ValidationSummary1" CssClass="alert alert-danger"/>
        <div class="form-group">
            <asp:Label Text="Id Pedido:" runat="server" AssociatedControlID="txtId" CssClass="col-md-3"/>
            <div class="col-md-9">
                <asp:Label ID="txtId" Text="" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Id Cliente:" runat="server" AssociatedControlID="txtIdCliente" CssClass="col-md-3"/>
            <div class="col-md-9">
                <asp:Label ID="txtIdCliente" Text="" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Fecha:" runat="server" AssociatedControlID="txtFecha" CssClass="col-md-3"/>
            <div class="col-md-9">
                <asp:Label ID="txtFecha" Text="" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Estado:" runat="server" AssociatedControlID="txtStatus" CssClass="col-md-3" />
            <div class="col-md-9">
                <asp:TextBox ID="txtStatus" TextMode="MultiLine" Rows="5" CssClass="form-control" runat="server"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Localidad:" runat="server" AssociatedControlID="txtLocation" CssClass="col-md-3"/>
            <div class="col-md-9">
                <asp:Label ID="txtLocation" Text="" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Imágenes:" runat="server" AssociatedControlID="imgImagenes" CssClass="col-md-3"/>
            <div class="col-md-9">
                <asp:Label ID="imgImagenes" Text="" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-1 col-md-offset-3">
                <asp:Button ID="btnSubmit" Text="Actualizar" runat="server" CssClass="btn btn-danger" OnClick="btnSubmit_Click" />
            </div>
        </div>

    </div>        
</asp:Content>
