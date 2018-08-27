<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="eShop.Web.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class='card-text text-center alert alert-danger'>Acerca de</h2>
    <hr />
    <h3>Trabajo Obligatorio</h3>
    <p>Tienda Online simple que como mínimo debe tener lo siguiente:</p><p> 
        Casos de uso desde los siguientes roles:</p><p>
-	Usuario sin registrar, podrá ver los productos pero no podrá comprar, si que los podrá añadir al carrito, pero no podrá hacer un checkout.</p><p>
-	Usuario registrado y logueado, podrá hacer el checkout del carrito, es decir podrá comprar los productos.</p><p>
-	Administrador, podrá gestionar los productos.</p><p>
De los productos se pide tener la siguiente información:</p><p>
-	Una o varia imágenes, Nombre, Descripción, PVP y stock actual</p><p>
-	La cantidad de stock (el número de unidades solo lo podrá ver/modificar el administrador)</p><p>
-	Pero si un producto está sin stock, los usuarios en la parte pública no podrán comprar ese artículo, aparecerá el artículo pero indicando que está sin stock.</p><p>
Al realizar un pedido, se enviará un correo tanto al comprador como al vendedor de la compra y se restarán las cantidades compradas del artículo comprado.</p><p>
De los pedidos se pide tener una gestión (el administrador podrá ver los pedidos y cambiar su estado, cada vez que se cambie el estado se enviará un correo al comprador informando el cambio de estado de su pedido), los usuarios tendrán un histórico de pedidos que podrán entrar a ver lo que contenían y el estado en el que se encuentran.</p><p>
El pago se realizará con un tpv virtual simulado, es decir, llamaremos a un página interna nuestra donde pediremos los datos de pago, tendremos varias tarjetas válidas y varias incorrectas, para poder hacer el caso de pago correcto e incorrecto.
.</p>
</asp:Content>
