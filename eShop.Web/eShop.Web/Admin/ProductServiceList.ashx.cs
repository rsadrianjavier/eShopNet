using System.Web;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;
using eShop.Application;
using eShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using eShop.Web.Models;

namespace eShop.Web.Admin
{
    /// <summary>
    /// Descripción breve de ProductServiceList
    /// </summary>
    public class ProductServiceList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
            var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
            var sSearch = context.Request["sSearch"];
            var iSortDir = context.Request["sSortDir_0"];
            var iSortCol = context.Request["iSortCol_0"];
            var sSortColum = context.Request.QueryString["mDataProp_" + iSortCol];

            ApplicationDbContext contextdb = new ApplicationDbContext();
            ProductManager productManager = new ProductManager(contextdb);
            #region select
            var allProducts = productManager.GetAll();
            var products = allProducts
                .Select(p => new AdminProductList
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Description = p.Description,
                    Stock = p.Stock
                });
            #endregion

            #region Filter
            if (!string.IsNullOrWhiteSpace(sSearch))
            {
                string where = @"ProductId.ToString().Contains(@0) ||
                                ProductName.ToString().Contains(@0) ||
                                Price.ToString().Contains(@0) ||
                                Description.ToString().Contains(@0) ||
                                Stock.ToString().Contains(@0)";
                products = products.Where(where, sSearch);
            }
            #endregion

            #region Paginate
            products = products
                        .OrderBy(sSortColum + " " + iSortDir)
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);
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