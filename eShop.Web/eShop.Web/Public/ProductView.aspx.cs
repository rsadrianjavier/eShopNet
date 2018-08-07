using eShop.Application;
using eShop.CORE;
using eShop.CORE.Contracts;
using eShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShop.Web.Public
{
    public partial class ProductView : System.Web.UI.Page
    {
        ApplicationDbContext context = null;
        IProductManager productManager = null;
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            context = new ApplicationDbContext();
            productManager = new ProductManager(context);

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    if (int.TryParse(Request.QueryString["id"], out id))
                    {
                        var product = productManager.GetById(id);
                        if (product != null)
                        {
                            LoadProduct(product);
                        }
                    }
                }
                else
                {
                    //TODO: Redirigir a listado
                }
            }
        }

        private void LoadProduct(Product product)
        {
            txtNombre.Text = product.ProductName;
            txtPrecio.Text = product.Price.ToString();
            txtDescripcion.Text = product.Description;

        }
    }
}
