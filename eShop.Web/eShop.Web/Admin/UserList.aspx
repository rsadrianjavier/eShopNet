<%@ Page Title="Listado Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="eShop.Web.Admin.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" rel="stylesheet" />
    <br />
    <table id="productsTable" class="display" style="width:100%">
        <thead>
            <tr>
                <th>Id</th>
                <th>Usuario</th>
                <th>Email</th>
                <th>C.P.</th>

                <th>Rol</th>

                <th><asp:Button Text="Crear nuevo usuario" PostBackUrl="~/Admin/UserCreate.aspx" class="btn btn-primary" runat="server" /></th>
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
                    "url": '/Admin/UserServiceList.ashx',
                    "type": "POST",
                    "datatype": "json"
                },
                "language": {
                    'url': "//cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
                },
                'columns': [
                    { "data": "UserId", "Name": "UserId", "autoWidth": true },
                    { "data": "UserName", "Name": "UserName", "autoWidth": true },
                    { "data": "Email", "Name": "Email", "autoWidth": true },
                    { "data": "PostalCode", "Name": "PostalCode", "autoWidth": true },
                    { "data": "Role", "Name": "Role", "autoWidth": true },
                    {
                        "data": null,
                        "className": "button",
                        "defaultContent": "<a value='Id' class='btn btn-danger'>Eliminar usuario</button>",
                        "orderable": "false"
                    }
                ],
                'columnDefs': [
                    {
                        "render": function (data, type, row) {
                            return "<a href='/Admin/UserEdit?id=" + row.UserId + "'>" + data + "</a>";
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
