<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCreate.aspx.cs" Inherits="eShop.Web.Admin.ProductCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h1>Crear producto</h1>
        <hr />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger"/>
        <div class="form-group">
            <asp:Label ID="LabelNombre" runat="server" Text="Nombre" CssClass="col-md-3" AssociatedControlID="txtNombre"></asp:Label>
            <div class="col-md9">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Introduzca un nombre, por favor" ControlToValidate="txtNombre" Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelPrecio" runat="server" Text="Precio del producto" CssClass="col-md-3" AssociatedControlID="txtPrecio"></asp:Label>
            <div class="col-md9">
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Introduzca el precio, por favor" ControlToValidate="txtPrecio" Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>


        <div class="form-group">
            <asp:Label ID="LabelDescripcion" runat="server" Text="Descripción" CssClass="col-md-3" AssociatedControlID="txtDescripcion"></asp:Label>
            <div class="col-md9">
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="10"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelStock" runat="server" Text="Stock del producto" CssClass="col-md-3" AssociatedControlID="TextBoxStock"></asp:Label>
            <div class="col-md9">
                <asp:TextBox ID="TextBoxStock" runat="server" CssClass="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Introduzca el stock, por favor" ControlToValidate="TextBoxStock" Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md1 col-md-offset-3">
                <asp:Button ID="btnSubmit" runat="server" Text="Crear" CssClass="btn btn-default" OnClick="btnSubmit_Click"/>

            </div>
        </div>
        
    </div>
</asp:Content>
