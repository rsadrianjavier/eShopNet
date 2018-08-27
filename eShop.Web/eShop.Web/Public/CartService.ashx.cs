using eShop.Application;
using eShop.CORE;
using eShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;

namespace eShop.Web.Public
{
    /// <summary>
    /// Descripción breve de CartService
    /// </summary>
    public class CartService : IHttpHandler
    {
        ApplicationDbContext contextdb = new ApplicationDbContext();


        public void ProcessRequest(HttpContext context)
        {
            CartManager cartManager = new CartManager(contextdb);
            ProductManager productManager = new ProductManager(contextdb);

            var productId = context.Request["productId"];

            var count = AddProduct(Int32.Parse(productId));

            context.Response.ContentType = "texto/normal";
            context.Response.Write(count.ToString());
        }


        private int AddProduct(int productId, int quantity = 1)
        {
            CartManager cartManager = new CartManager(contextdb);
            ProductManager productManager = new ProductManager(contextdb);

            if ( User.Identity.IsAuthenticated){

                if(!cartManager.getCarritoByUsuarioId(Context.User.Identity.GetUserId())){

                    Cart cart = new Cart(UsuarioId);

                } else {
                    Cart cart = cartManager.getCarritoByUsuarioId(UsuarioId);
                }

                if (carrito cotiene producto) {

                    cantidadProducto = cantidadProducto + quantity;

                } else { 

                    OrderLine cartLine = new CartLine
                        {
                            ProductId = productId,
                            Price = int.Parse(txtPrecio.Text),
                            Description = txtDescripcion.Text,
                            Stock = int.Parse(TextBoxStock.Text)
                        };

                    cartManager.Add(cartLine);

                    productManager.Context.SaveChanges();
                }

                CarritoUsuarioBBDD = cart;

                return 1;

            } else {

                if(!cartManager.getCarritoBySesionID(Session["id"])) {

                    Cart cart = new Cart(SesionId);
                }

                if (carrito contiene CartLine de Producto){
                    cantidadProducto = cantidadProducto + quantity;

                } else {

                    //Añadimos producto al carrito
                }

                Session["CartItem"] = cart;

                return 1;
            }
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}