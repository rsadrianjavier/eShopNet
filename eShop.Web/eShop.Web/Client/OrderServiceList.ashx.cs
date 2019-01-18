using eShop.Application;
using eShop.CORE.Contracts;
using eShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Linq.Dynamic;
using eShop.Web.Models;

namespace eShop.Web.Client
{
    /// <summary>
    /// Descripción breve de OrderServiceList
    /// </summary>
    public class OrderServiceList : IHttpHandler
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
            OrderManager orderManager = new OrderManager(contextdb);
            #region select
            var allOrders = orderManager.GetAll();
            var orders = allOrders
                .Select(p => new AdminOrderList
                {
                    OrderId = p.OrderId,
                    OrderDate = p.OrderDate.ToString(),
                    ClientId = p.ClientId,
                    Status = p.Status.ToString()
                });
            #endregion

            #region Filter
            if (!string.IsNullOrWhiteSpace(sSearch))
            {
                string where = @"OrderId.ToString().Contains(@0) ||
                                OrderDate.ToString().Contains(@0) ||
                                ClientId.ToString().Contains(@0) ||
                                Status.ToString().Contains(@0)";
                orders = orders.Where(where, sSearch);
            }
            #endregion

            #region Paginate
            if (!string.IsNullOrWhiteSpace(sSortColum))
            {
                orders = orders
                        .OrderBy(sSortColum + " " + iSortDir)
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);
            }
            #endregion
            var result = new
            {
                iTotalRecords = allOrders.Count(),
                iTotalDisplayRecords = allOrders.Count(),
                aaData = orders
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