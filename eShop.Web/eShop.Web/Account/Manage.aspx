<%@ Page Title="Administrar cuenta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="eShop.Web.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Cambiar la configuración de la cuenta</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Contraseña:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Modificar]" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Crear]" Visible="false" ID="CreatePassword" runat="server" />
                    </dd>
                </dl>
                <dl class="dl-horizontal">
                    <dt><asp:Label AssociatedControlID="txtNombre" Text="Nombre:" runat="server" /></dt>
                    <dd><asp:TextBox id="txtNombre" runat="server"/></dd>
                </dl>
                <dl class="dl-horizontal">
                    <dt><asp:Label AssociatedControlID="txtDNI" Text="DNI:" runat="server" /></dt>
                    <dd><asp:TextBox id="txtDNI" runat="server"/></dd>
                </dl>

            </div>
        </div>
    </div>

</asp:Content>
