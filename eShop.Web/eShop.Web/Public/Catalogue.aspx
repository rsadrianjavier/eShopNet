<%@ Page Title="Catálogo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogue.aspx.cs" Inherits="eShop.Web.Public.Catalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div id="listadoProductos" class="col-md-12">
            
        </div>
    </div>
    

    <script type="text/javascript">
        $(document).ready(function () {

    		let container = document.querySelector("#listadoProductos");
    	    container.innerHTML = "";
            var productos = new Array();
            productos = $.ajax({
                type: "POST",
                url: "CatalogueService.ashx",
                success: function (productos) { 
                    var n = 0;
                    $.each(productos, function() {
                        var producto = document.createElement("div");
                        producto.setAttribute("class", "col-12 col-sm-6 col-md-4");
                        producto.innerHTML = 
                                                "<div class='card' style='width: 18rem;margin-top:50px'>" +
                                                    "<img class='card-img-top Image_@Model.Id' src='~/Content/Images/@Model.Image' alt='Card image cap'>" +
                                                    "<div class='card-body'>" +
                                                        " <h5 class='card-title text-center'><b>" + productos[n].ProductName + "</b></h5>     " +   
                                                        "<p class='card-text text-center alert alert-success'>" + productos[n].Price + " €</p>" +
                                                        "<div class='text-center'>" +
                                                            "<a href='#' data-id='" + productos[n].ProductId + "' class='btn btn-primary add-to-cart'>Al carrito</a>" +
                                                            "<a href='/ProductView.aspx' class='btn btn-default'>+ Info</a>" +
                                                        "</div>" +
                                                    "</div>" +
                                                "</div>"
                                            ;
                        container.appendChild(producto);
                        n++;
                    });  
	            }
            });
         } );
    </script>
</asp:Content>
