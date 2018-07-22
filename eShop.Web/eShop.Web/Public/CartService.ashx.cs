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
            context.Response.ContentType = "texto/normal";
            context.Response.Write("Hola a todos");
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