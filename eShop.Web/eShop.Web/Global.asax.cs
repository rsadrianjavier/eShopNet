using eShop.CORE;
using eShop.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace eShop.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Configurar la seguridad
            ApplicationDbContext context = new ApplicationDbContext();

            RoleManager<IdentityRole> roleManager = 
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));
            UserManager<ApplicationUser> userManager =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            if (!roleManager.RoleExists("Client"))
            {
                roleManager.Create(new IdentityRole("Client"));
            }

            ApplicationUser user = userManager.FindByName("admin@admin.es");
            if (user == null)
            {
                user = new ApplicationUser();
                user.UserName = "admin@admin.es";
                user.Email = "admin@admin.es" ;
                IdentityResult result = userManager.Create(user, "123456QWERty");

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id,"Admin");
                }
                else
                {
                    throw new Exception("Usuario no creado");
                }
            }
            else
            {
                //El usuario está creado, ¿Pero ya esta en el rol admin?
                if (!userManager.IsInRole(user.Id, "Admin"))
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            
        }
    }
}