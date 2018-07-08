using System;
using eShop.CORE;
using eShop.Application;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eShop.DAL;

namespace eShop.Web.Admin
{
    public partial class ProductCreate : System.Web.UI.Page
    {

        ProductManager productManager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            productManager = new ProductManager(context);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Product producto = new Product
                {
                    ProductName = txtNombre.Text,
                    Price = int.Parse(txtPrecio.Text),
                    Description = txtDescripcion.Text,
                    Stock = int.Parse(TextBoxStock.Text)
                };
                productManager.Add(producto);
                productManager.Context.SaveChanges();
                Response.Redirect("ProductsView"); 
                // TODO: Pagina sin crear
            }
            catch(Exception ex)
            {
                //TODO: Escribir el error en un log
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al guardar",
                    IsValid = false
                };
            }
            
        }
    }
}