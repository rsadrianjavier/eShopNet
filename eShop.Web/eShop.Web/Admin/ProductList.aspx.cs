using eShop.Application;
using eShop.CORE.Contracts;
using eShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShop.Web.Admin
{
    public partial class ProductList : System.Web.UI.Page
    {
        ApplicationDbContext context = null;
        IProductManager productManager = null;

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            context = new ApplicationDbContext();
            productManager = new ProductManager(context);
        }

        protected void btnEliminar_Click(int id)
        {
            try
            {

                var product = productManager.GetById(id);
                if (product != null)
                {
                    productManager.Remove(product);

                    context.SaveChanges();

                    Response.Redirect("~/Admin/ProductList.aspx");
                }
                
            }
            catch (Exception ex)
            {
                //TODO: Escribir el error en un log
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al modificar",
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }
    }
}