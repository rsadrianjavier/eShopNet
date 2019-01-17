<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="eShop.Web.Public.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css" rel="stylesheet" />
    <br />
    <table id="productsTable" class="display" style="width:100%">
        <thead>
            <tr>
                <th>Id</th>
                <th>Nombre</th>
                <th>Precio</th>
                <th>Descripción</th>
                <th>Stock</th>
            </tr>
        </thead>
    </table>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready( function () {
            $('#productsTable').DataTable({                                                
                "processing": true, // for show progress bar
                "serverSide": true, // for process server side
                "filter": true, // this is for disable filter (search box)
                "orderMulti": false, // for disable multiple column at once
                "ajax": {
                    "url": '/Public/ProductServiceList.ashx',
                    "type": "POST",
                    "datatype": "json"
                },
                "language": {
                    'url': "//cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
                },
                "columns": [
                    { "data": "ProductId", "Name": "ProductId", "autoWidth": true },
                    { "data": "ProductName", "Name": "ProductName", "autoWidth": true },
                    { "data": "Price", "Name": "Price", "autoWidth": true },
                    { "data": "Description", "Name": "Description", "autoWidth": true },
                    { "data": "Stock", "Name": "Stock", "autoWidth": true },
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
