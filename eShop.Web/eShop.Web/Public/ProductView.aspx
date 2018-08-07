<%@ Page Title="Detalle Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="eShop.Web.Public.ProductView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-top:50px">
        <div class="col-md-5">
            <div class="thumbnail">
                <img src="../Content/Images/.jpg"
            </div>
        </div>
        <div class="col-md-7">
            <asp:Label ID="txtNombre" Text="" CssClass="form-control" runat="server" />
            <asp:Label ID="txtDescripcion" Text="" CssClass="form-control" runat="server" />
            <asp:Label ID="txtPrecio" Text="" CssClass="form-control" runat="server" />
        </div>
        <div>
            <a href='#' data-id='" + productos[n].ProductId + "' class='btn btn-danger add-to-cart'>Al carrito</a>
        </div>
    </div>
</asp:Content>
