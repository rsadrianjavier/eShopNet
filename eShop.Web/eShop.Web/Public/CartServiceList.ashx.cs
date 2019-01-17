using eShop.Application;
using eShop.CORE;
using eShop.DAL;
using eShop.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Script.Serialization;

namespace eShop.Web.Public
{
    /// <summary>
    /// Descripción breve de CartServiceList
    /// </summary>
    public class CartServiceList : System.Web.UI.Page, IHttpHandler
    {
        override public void ProcessRequest(HttpContext context)
        {
            string sessionId = context.Request["sessionId"];

            var iDisplayLength = int.Parse(context.Request["length"]);
            var iDisplayStart = int.Parse(context.Request["start"]);
            var sSearch = context.Request["search[value]"];
            var iSortDir = context.Request["order[0][dir]"];
            var iSortCol = context.Request["order[0][column]"];
            var sSortColum = context.Request["columns[" + iSortCol + "][data]"];

            //var sSortColum = context.Request.QueryString["mDataProp_" + iSortCol];

            ApplicationDbContext contextdb = new ApplicationDbContext();
            CartManager cartManager = new CartManager(contextdb);
            ProductManager productManager = new ProductManager(contextdb);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contextdb));
            ApplicationUser currentUser = userManager.FindByIdAsync(User.Identity.GetUserId()).Result;
            #region select

            IQueryable<CORE.Cart> allProducts;

            if (Context.User.Identity.IsAuthenticated)
            {
                //IQueryable<CORE.Cart> carritoPrevio = cartManager.GetCarritoByUsuarioId(Context.User.Identity.GetUserId());
                allProducts = cartManager.GetCarritoByUsuarioId(currentUser.Id);
            }
            else
            {
                allProducts = cartManager.GetCarritoBySesionId(sessionId);
            }

            List<CORE.Cart> cart = allProducts.ToList();
            var products = cart
                .Select(p => new AdminCartList
                {
                    Id = p.Product_Id,
                    Product = productManager.GetById(p.Product_Id).ProductName,
                    NetPrice = p.NetPrice,
                    Quantity = p.Quantity,
                });
            #endregion
            
            #region Filter
            if (!string.IsNullOrWhiteSpace(sSearch))
            {
                string where = @"Id.ToString().Contains(@0) ||
                                Product.ToString().Contains(@0) ||
                                NetPrice.ToString().Contains(@0) ||
                                Quantity.ToString().Contains(@0)";
                products = products.Where(where, sSearch);
            }
            #endregion

            #region Paginate
            if (!string.IsNullOrWhiteSpace(sSortColum))
            {
                products = products
                        .OrderBy(sSortColum + " " + iSortDir)
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);
            }
            #endregion
            var result = new
            {
                iTotalRecords = allProducts.Count(),
                iTotalDisplayRecords = allProducts.Count(),
                aaData = products
            };

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(result);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
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