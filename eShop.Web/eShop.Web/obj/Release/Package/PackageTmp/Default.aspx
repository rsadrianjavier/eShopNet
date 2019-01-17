<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eShop.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css" rel="stylesheet" />

    <div class="jumbotron">
        <h1>Trabajo obligatorio ASP.NET C#</h1>
        <p class="lead">GESTIÓN Y DESARROLLO DE APLICACIONES MULTIPLATAFORMA</p>
        <p><a href="/About.aspx" class='card-text text-center alert alert-danger'>Descripción del trabajo &raquo;</a></p>
    </div>

    <div class="jumbotron">
        <a class="btn btn-danger btn-lg" href="/Public/Catalogue.aspx" class="btn btn-danger btn-lg">Ir a la tienda &raquo;</a>
    </div>
</asp:Content>
