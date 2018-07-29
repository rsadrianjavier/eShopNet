using eShop.Application;
using eShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShop.Web.Public
{
    /// <summary>
    /// Descripción breve de CartService
    /// </summary>
    public class CartService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ApplicationDbContext contextdb = new ApplicationDbContext();
            ProductManager productManager = new ProductManager(contextdb);


/*
            var count = AddProduct(productId);
            return Content(count.ToString());
  */      


            context.Response.ContentType = "texto/normal";
            context.Response.Write("Hola a todos");
        }


        /*private int AddProduct(int productId, int quantity = 1)
        {

            //Dictionary<int, int> cart = Session["CartItem"] as Dictionary<int, int>;
            if (cart == null)
                cart = new Dictionary<int, int>();
            if (cart.ContainsKey(productId))
                cart[productId] = cart[productId] + quantity;
            else
                cart.Add(productId, 1);

            //Session["CartItem"] = cart;

            return cart.Sum(e => e.Value);
        }*/

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}