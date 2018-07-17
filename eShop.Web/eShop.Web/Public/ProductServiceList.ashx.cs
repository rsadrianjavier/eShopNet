using eShop.Application;
using eShop.DAL;
using eShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Script.Serialization;

namespace eShop.Web.Public
{
    /// <summary>
    /// Descripción breve de ProductServiceList
    /// </summary>
    public class ProductServiceList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var iDisplayLength = int.Parse(context.Request["length"]);
            var iDisplayStart = int.Parse(context.Request["start"]);
            var sSearch = context.Request["search[value]"];
            var iSortDir = context.Request["order[0][dir]"];
            var iSortCol = context.Request["order[0][column]"];
            var sSortColum = context.Request["columns[" + iSortCol + "][data]"];

            //var sSortColum = context.Request.QueryString["mDataProp_" + iSortCol];

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