using eShop.CORE;
using eShop.DAL;
using eShop.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.Script.Serialization;

namespace eShop.Web.Admin
{
    /// <summary>
    /// Descripción breve de UserServiceList
    /// </summary>
    public class UserServiceList : IHttpHandler
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

            ApplicationDbContext UsersContext = new ApplicationDbContext();
            var allRoles = UsersContext.Roles.ToList();

            #region select
            var allUsers = UsersContext.Users.ToList();
            /*var users = allUsers
                .Select(p => new ApplicationUser
                {
                    Id = p.Id,
                    UserName = p.UserName,
                    Email = p.Email,
                    PostalCode = p.PostalCode,
                    PhoneNumber = (allRoles.Select(r => new RoleEntity()).Where(RoleId = p.Roles.First().RoleId))

                });*/

            var users = (from user in UsersContext.Users
                         select new
                         {
                             UserId = user.Id,
                             UserName = user.UserName,
                             Email = user.Email,
                             PostalCode = user.PostalCode,
                             RoleNames = (from userRole in user.Roles
                                          join role in UsersContext.Roles on userRole.RoleId
                                          equals role.Id
                                          select role.Name).ToList()
                         }).ToList().Select(p => new AdminUserList()

                         {
                             UserId = p.UserId,
                             UserName = p.UserName,
                             Email = p.Email,
                             PostalCode = p.PostalCode,
                             Role = string.Join(",", p.RoleNames)
                         });
            #endregion

            #region Filter
            if (!string.IsNullOrWhiteSpace(sSearch))
            {
                string where = @"UserId.ToString().Contains(@0) ||
                                UserName.ToString().Contains(@0) ||
                                Email.ToString().Contains(@0) ||
                                PostalCode.ToString().Contains(@0) ||
                                Role.ToString().Contains(@0)";
                users = users.Where(where, sSearch);
            }
            #endregion

            #region Paginate
            if (!string.IsNullOrWhiteSpace(sSortColum))
            {
                users = users
                        .OrderBy(sSortColum + " " + iSortDir)
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);
            }
            #endregion
            var result = new
            {
                iTotalRecords = allUsers.Count(),
                iTotalDisplayRecords = allUsers.Count(),
                aaData = users
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