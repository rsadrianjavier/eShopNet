<%@ Page Title="Listado Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="eShop.Web.Admin.OrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" rel="stylesheet" />
    <h2 class='card-text text-center alert alert-danger'><%: Title %></h2>
    <br />
    <table id="productsTable" class="display" style="width:100%">
        <thead>
            <tr>
                <th>Id</th>
                <th>Fecha</th>
                <th>Cliente</th>
                <th>Estado</th>
            </tr>
        </thead>
    </table>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready( function () {
            $('#productsTable').DataTable({
                "processing": true, // for show progress bar
                "serverSide": true, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": false, // for disable multiple column at once
                "ajax": {
                    "url": '/Admin/OrderServiceList.ashx',
                    "type": "POST",
                    "datatype": "json"
                },
                "language": {
                    'url': "//cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
                },
                'columns': [
                    { "data": "OrderId", "Name": "OrderId", "autoWidth": true },
                    { "data": "OrderDate", "Name": "OrderDate", "autoWidth": true },
                    { "data": "ClientId", "Name": "ClientId", "autoWidth": true },
                    { "data": "Status", "Name": "Status", "autoWidth": true }
                ],
                'columnDefs': [
                    {
                        "render": function (data, type, row) {
                            return "<a href='/Admin/OrderEdit?id=" + row.OrderId + "'>" + data + "</a>";
                        },
                        "targets": 0
                    }
                ]
            });
        } );
    </script>

</asp:Content>
