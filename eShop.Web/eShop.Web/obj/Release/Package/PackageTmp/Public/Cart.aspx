<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="eShop.Web.Public.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2 class='card-text text-center alert alert-danger'><%: Title %>.</h2>

        <link href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css" rel="stylesheet" />
    <br />
    <table id="productsTable" class="display" style="width:100%">
        <thead>
            <tr>
                <th>Id</th>
                <th>Nombre</th>
                <th>Precio</th>
                <th>Cantidad</th>
            </tr>
        </thead>
    </table>

<%--    <asp:ImageButton ID="CheckoutImageBtn" runat="server" 
                      ImageUrl="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" 
                      Width="145" AlternateText="Check out with PayPal" 
                      OnClick="CheckoutBtn_Click" 
                      BackColor="Transparent" BorderWidth="0" />--%>

    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var sessionId = "<%= Session.SessionID %>";
            $('#productsTable').DataTable({                                                
                "processing": true, // for show progress bar
                "serverSide": true, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": false, // for disable multiple column at once
                "ajax": {
                    "url": '/Public/CartServiceList.ashx',
                    "data": { "sessionId": sessionId },
                    "type": "POST",
                    "datatype": "json"
                },
                "language": {
                    'url': "//cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
                },
                "sessionId": "<%= Session.SessionID %>",
                "columns": [
                    { "data": "Id", "Name": "ProductId", "autoWidth": true },
                    { "data": "Product", "Name": "Product", "autoWidth": true },
                    { "data": "NetPrice", "Name": "NetPrice", "autoWidth": true },
                    { "data": "Quantity", "Name": "Quantity", "autoWidth": true },
                ],
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            return "<a href='/Public/ProductView?id=" + row.Id + "' class='btn btn-pink'>" + data + "</a>";
                        },
                        "targets": 1
                    }
                ]
            });
        } );
    </script>

</asp:Content>
