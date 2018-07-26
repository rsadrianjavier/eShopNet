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
    /// Descripción breve de CatalogueService
    /// </summary>
    public class CatalogueService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
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
                    Stock = p.Stock,
                    Image = p.Image
                });
            #endregion



            IEnumerable<AdminProductList> result = products;
            var serializer = new JavaScriptSerializer();
            context.Response.ContentType = "application/json";
            context.Response.Write(serializer.Serialize(result));
            

            /*var result = new
            {
                iTotalRecords = allProducts.Count(),
                iTotalDisplayRecords = allProducts.Count(),
                aaData = products
            };

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(result);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);*/
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