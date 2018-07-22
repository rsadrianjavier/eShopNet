using eShop.CORE.Contracts;
using eShop.DAL;
using eShop.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShop.Web.Admin
{
    public partial class UserEdit : System.Web.UI.Page
    {
        ApplicationDbContext context = null;
        //UserManager productManager = null;

        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new ApplicationDbContext();
            //productManager = new ProductManager(context);

            var idUsuario = (Request.QueryString["id"]);

            var users = (from user in context.Users
                         select new
                         {
                             UserId = user.Id,
                             UserName = user.UserName,
                             Email = user.Email,
                             PostalCode = user.PostalCode,
                             RoleNames = (from userRole in user.Roles
                                          join role in context.Roles on userRole.RoleId
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

            

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {

                    string where = @"UserId.ToString().Contains(@0)";
                    users = users.Where(where, idUsuario);

                    var user = users.First();
                        if (user != null)
                        {
                            LoadUser(user);
                        }
                    
                }
                else
                {
                    Response.Redirect("~/Admin/UserList.aspx");
                }
            }
        }

        private void LoadUser(AdminUserList user)
        {
            txtUserId.Text = user.UserId;
            txtUserName.Text = user.UserName;
            txtEmail.Text = user.Email;
            txtPostalCode.Text = user.PostalCode;
            txtRole.Text = user.Role;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
         
                if (Request.QueryString["id"] != null)
                {
                    var idUsuario = (Request.QueryString["id"]);

                    var users = (from userEdited in context.Users
                                 select new
                                 {
                                     UserId = userEdited.Id,
                                     UserName = userEdited.UserName,
                                     Email = userEdited.Email,
                                     PostalCode = userEdited.PostalCode,
                                     RoleNames = (from userRole in userEdited.Roles
                                                  join role in context.Roles on userRole.RoleId
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

                    string where = @"UserId.ToString().Contains(@0)";
                    users = users.Where(where, idUsuario);

                //var user = users.First();
                /*
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                IdentityResult result = manager.(User.Identity.GetUserId(), CurrentPassword.Text, NewPassword.Text);
                if (result.Succeeded)
                {
                    var user = manager.FindById(idUsuario);
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }

                if (user != null)
                    {
                        user.Id = txtUserId.Text;
                        user.UserName = txtUserName.Text;
                        user.Email = txtEmail.Text;
                        user.PostalCode = txtPostalCode.Text;

                        context.SaveChanges();

                        Response.Redirect("~/Admin/UserList.aspx");
                    }
                }
                else
                {
                  */  
                }
                Response.Redirect("~/Admin/UserList.aspx");
            

        }
    }
}