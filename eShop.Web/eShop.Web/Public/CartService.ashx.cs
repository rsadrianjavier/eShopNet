using eShop.Application;
using eShop.CORE;
using eShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eShop.Web.Public
{
    /// <summary>
    /// Descripción breve de CartService
    /// </summary>
    public class CartService : System.Web.UI.Page, IHttpHandler
    {
        ApplicationDbContext contextdb = new ApplicationDbContext();


        override public void ProcessRequest(HttpContext context)
        {
            CartManager cartManager = new CartManager(contextdb);
            ProductManager productManager = new ProductManager(contextdb);


            int productId = int.Parse(context.Request["productId"]);

            var count = AddProduct(productId);

            context.Response.ContentType = "texto/normal";
            context.Response.Write(count.ToString());
        }


        private int AddProduct(int productId, int quantity = 1)
        {
            CartManager cartManager = new CartManager(contextdb);
            ProductManager productManager = new ProductManager(contextdb);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>( new UserStore<ApplicationUser>(contextdb));
            ApplicationUser currentUser = userManager.FindByIdAsync(User.Identity.GetUserId()).Result;

            if (Context.User.Identity.IsAuthenticated)
            {
                //IQueryable<CORE.Cart> carritoPrevio = cartManager.GetCarritoByUsuarioId(Context.User.Identity.GetUserId());
                IQueryable<CORE.Cart> carritoPrevio = cartManager.GetCarritoByUsuarioId(currentUser.Id);

                List<CORE.Cart> cart;
                CORE.Cart producto = new CORE.Cart();

                if (carritoPrevio == null)
                {
                    cart = new List<CORE.Cart>();

                    producto.Client = currentUser;
                    producto.Product_Id = productId;
                    producto.Quantity = quantity;

                    cart.Add(producto);
                }
                else
                {
                    cart = carritoPrevio.ToList();

                    foreach (CORE.Cart item in cart)
                    {
                        if (item.Product_Id.Equals(productId))
                        {
                            producto.Client = currentUser;
                            producto.Product_Id = productId;
                            producto.Quantity = item.Quantity + quantity;

                            cart.Add(producto);
                        }
                    }
                }

                cartManager.Add(producto);
                cartManager.Context.SaveChanges();

                //CarritoUsuarioBBDD = cart;

                return cartManager.GetCarritoByUsuarioId(currentUser.Id).Count();

            }
            else
            {

                //if (!cartManager.GetCarritoBySesionId(Session["id"]))
                //{

                //    List<Cart> cart = new List<Cart>(SesionId);
                //}

                //if (carrito contiene CartLine de Producto){
                //    cantidadProducto = cantidadProducto + quantity;

                //} else {

                //    //Añadimos producto al carrito
                //}

                //Session["CartItem"] = cart;

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