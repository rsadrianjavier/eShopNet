<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="eShop.Web.Admin.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" rel="stylesheet" />
    <br />
    <table id="usersTable" class="display" style="width:100%">
        <thead>
            <tr>
                <th>Id</th>
                <th>Username</th>
                <th>Email</th>
            </tr>
        </thead>
    </table>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready( function () {
            $('#usersTable').DataTable({
                'bProcessing': true,
                'bServeSide': true,
                'sAjaxSource': '/Admin/UserServiceList.ashx',
                'language': {
                    'url': "//cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
                },
                'columns': [
                    { "data": "Id", "Name": "Id", "autoWidth": true },
                    { "data": "Email", "Name": "Email", "autoWidth": true },
                    { "data": "Username", "Name": "Username", "autoWidth": true },
                ],
                'columsDefs': [
                    {

                    }
                ]
            });
        } );
    </script>
</asp:Content>
