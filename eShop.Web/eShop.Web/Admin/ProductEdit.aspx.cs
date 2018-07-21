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

namespace eShop.Web.Admin
{
    public partial class ProductEdit : System.Web.UI.Page
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

        private void LoadProduct (Product product)
        {
            txtNombre.Text = product.ProductName;
            txtPrecio.Text = product.Price.ToString();
            txtDescripcion.Text = product.Description;
            txtStock.Text = product.Stock.ToString();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    if (int.TryParse(Request.QueryString["id"], out id))
                    {
                        var product = productManager.GetById(id);
                        if (product != null)
                        {
                            product.ProductName = txtNombre.Text;
                            product.Price = int.Parse(txtPrecio.Text);
                            product.Description = txtDescripcion.Text;
                            product.Stock = int.Parse(txtStock.Text);

                            context.SaveChanges();

                            Response.Redirect("~/Admin/ProductList.aspx");
                        }
                    }
                }
                else
                {
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