<%@ Page Title="Editar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="eShop.Web.Admin.UserEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="form-horizontal">
        <h2 class='card-text text-center alert alert-danger'><%: Title %></h2>
            <br />
        <asp:ValidationSummary runat="server" id="ValidationSummary1" CssClass="alert alert-danger"/>
        <div class="form-group">
            <asp:Label Text="Id Usuario:" runat="server" AssociatedControlID="txtUserId" CssClass="col-md-3"/>
            <div class="col-md-9">
                <asp:Label ID="txtUserId" Text="" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Nombre de usuario:" runat="server" AssociatedControlID="txtUserName" CssClass="col-md-3"/>
            <div class="col-md-9">
                <asp:TextBox ID="txtUserName" Text="" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Email:" runat="server" AssociatedControlID="txtEmail" CssClass="col-md-3" />
            <div class="col-md-9">
                <asp:TextBox ID="txtEmail" Text="" CssClass="form-control" runat="server"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Código Postal:" runat="server" AssociatedControlID="txtPostalCode" CssClass="col-md-3"/>
            <div class="col-md-9">
                <asp:TextBox ID="txtPostalCode" Text="" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label Text="Rol de usuario:" runat="server" AssociatedControlID="txtRole" CssClass="col-md-3"/>
            <div class="col-md-9">
                <asp:Label ID="txtRole" Text="" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-1 col-md-offset-3">
                <asp:Button ID="btnSubmit" Text="Actualizar" runat="server" CssClass="btn btn-danger" OnClick="btnSubmit_Click" />
            </div>
        </div>

    </div>     
</asp:Content>
