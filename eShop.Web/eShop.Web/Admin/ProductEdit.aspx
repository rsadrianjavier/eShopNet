<%@ Page Title="Editar Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="eShop.Web.Admin.ProductEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4>Editar producto</h4>
        <asp:ValidationSummary runat="server" id="ValidationSummary1" CssClass="alert alert-danger"/>
        <div class="form-group">
            <asp:Label Text="Nombre:" runat="server" AssociatedControlID="txtNombre" CssClass="col-md-3"/>
            <div class="col-md-9">
                <asp:Label ID="txtNombre" Text="" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Precio:" runat="server" AssociatedControlID="txtPrecio" CssClass="col-md-3"/>
            <div class="col-md-9">
                <asp:Label ID="txtPrecio" Text="" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Descripcion:" runat="server" AssociatedControlID="txtDescripcion" CssClass="col-md-3" />
            <div class="col-md-9">
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" Rows="5" CssClass="form-control" runat="server"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Stock:" runat="server" AssociatedControlID="txtStock" CssClass="col-md-3"/>
            <div class="col-md-9">
                <asp:Label ID="txtStock" Text="" CssClass="form-control" runat="server" />
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
