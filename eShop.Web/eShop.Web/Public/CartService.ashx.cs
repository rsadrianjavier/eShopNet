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
using System.Web.UI;

namespace eShop.Web.Public
{
    /// <summary>
    /// Descripción breve de CartService
    /// </summary>
    public class CartService : System.Web.UI.Page, IHttpHandler
    {
        ApplicationDbContext contextdb = new ApplicationDbContext();
        string sessionId;

        override public void ProcessRequest(HttpContext context)
        {
            CartManager cartManager = new CartManager(contextdb);
            ProductManager productManager = new ProductManager(contextdb);


            int productId = int.Parse(context.Request["productId"]);
            sessionId = context.Request["sessionId"];

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

            IQueryable<CORE.Cart> carritoPrevio;

            if (Context.User.Identity.IsAuthenticated)
            {
                //IQueryable<CORE.Cart> carritoPrevio = cartManager.GetCarritoByUsuarioId(Context.User.Identity.GetUserId());
                carritoPrevio = cartManager.GetCarritoByUsuarioId(currentUser.Id);
            }
            else
            {
                carritoPrevio = cartManager.GetCarritoBySesionId(sessionId);
            }
                        

            List<CORE.Cart> cart = carritoPrevio.ToList();
            CORE.Cart producto = new CORE.Cart();

            if (carritoPrevio.Count() == 0)
            {
                producto.Client = new ApplicationUser();
                producto.Client = currentUser;

                producto.SessionId = sessionId;

                producto.Product = productManager.GetById(productId);
                producto.Product_Id = productId;
                producto.NetPrice = decimal.Parse(productManager.GetById(productId).Price.ToString());
                producto.Quantity = quantity;
                producto.Date = DateTime.Now;
                cartManager.Add(producto);
            }
            else
            {
                foreach (CORE.Cart item in cart)
                {
                    if (item.Product_Id.Equals(productId))
                    {
                        item.Client = new ApplicationUser();
                        item.Client = currentUser;

                        item.SessionId = sessionId;

                        item.Product = productManager.GetById(productId);
                        item.Product_Id = productId;
                        item.NetPrice = decimal.Parse(productManager.GetById(productId).Price.ToString());
                        item.Quantity = item.Quantity + quantity;
                        item.Date = DateTime.Now;

                        cartManager.Context.SaveChanges();
                        if (Context.User.Identity.IsAuthenticated)
                        {
                            return cartManager.GetCarritoByUsuarioId(currentUser.Id).Count();
                        }
                        else
                        {
                            return cartManager.GetCarritoBySesionId(sessionId).Count();
                        }
                    }
                }

                producto.Client = new ApplicationUser();
                producto.Client = currentUser;

                producto.SessionId = sessionId;

                producto.Product = productManager.GetById(productId);
                producto.Product_Id = productId;
                producto.NetPrice = decimal.Parse(productManager.GetById(productId).Price.ToString());
                producto.Quantity = quantity;
                producto.Date = DateTime.Now;
                cartManager.Add(producto);
            }
                
            cartManager.Context.SaveChanges();

            //carritoPrevio = cart;

            if (Context.User.Identity.IsAuthenticated)
            {
                return cartManager.GetCarritoByUsuarioId(currentUser.Id).Count();
            }
            else
            {
                return cartManager.GetCarritoBySesionId(sessionId).Count();
            }

        }


        //public decimal GetTotal()
        //{
        //    ShoppingCartId = GetCartId();
        //    // Multiply product price by quantity of that product to get        
        //    // the current price for each of those products in the cart.  
        //    // Sum all product price totals to get the cart total.   
        //    decimal? total = decimal.Zero;
        //    total = (decimal?)(from cartItems in _db.ShoppingCartItems
        //                       where cartItems.CartId == ShoppingCartId
        //                       select (int?)cartItems.Quantity *
        //                       cartItems.Product.UnitPrice).Sum();
        //    return total ?? decimal.Zero;
        //}

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}