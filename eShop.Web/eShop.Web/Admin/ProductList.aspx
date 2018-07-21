<%@ Page Title="Listado Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="eShop.Web.Admin.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" rel="stylesheet" />
    <br />
    <table id="productsTable" class="display" style="width:100%">
        <thead>
            <tr>
                <th>Id</th>
                <th>Nombre</th>
                <th>Precio</th>
                <th>Descripción</th>
                <th>Stock</th>
                <th><asp:Button Text="Crear nuevo producto" PostBackUrl="~/Admin/ProductCreate.aspx" class="btn btn-primary" runat="server" /></th>
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
                    "url": '/Admin/ProductServiceList.ashx',
                    "type": "POST",
                    "datatype": "json"
                },
                "language": {
                    'url': "//cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
                },
                'columns': [
                    { "data": "ProductId", "Name": "ProductId", "autoWidth": true },
                    { "data": "ProductName", "Name": "ProductName", "autoWidth": true },
                    { "data": "Price", "Name": "Price", "autoWidth": true },
                    { "data": "Description", "Name": "Description", "autoWidth": true },
                    { "data": "Stock", "Name": "Stock", "autoWidth": true },
                    {
                        "data": null,
                        "className": "button",
                        "defaultContent": "<a value='ProductId' class='btn btn-danger'>Eliminar producto</button>",
                        "orderable": "false"
                    }
                ],
                'columnDefs': [
                    {
                        "render": function (data, type, row) {
                            return "<a href='/Admin/ProductEdit?id=" + row.ProductId + "'>" + data + "</a>";
                        },
                        "targets": 1
                    },
                    {

                        "orderable": false,
                        "targets": 5
                    }
                ]
            });
        } );
    </script>

</asp:Content>
