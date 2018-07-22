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
    public partial class OrderEdit : System.Web.UI.Page
    {
        ApplicationDbContext context = null;
        IOrderManager orderManager = null;

        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new ApplicationDbContext();
            orderManager = new OrderManager(context);

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    if (int.TryParse(Request.QueryString["id"], out id))
                    {
                        var order = orderManager.GetById(id);
                        if (order != null)
                        {
                            LoadProduct(order);
                        }
                    }
                }
                else
                {
                    //TODO: Redirigir a listado
                }
            }
        }

        private void LoadProduct(Order order)
        {
            txtId.Text = order.OrderId.ToString();
            txtIdCliente.Text = order.ClientId.ToString();
            txtFecha.Text = order.OrderDate.ToShortTimeString();
            txtStatus.Text = order.Status.ToString();
            txtLocation.Text = order.ShippingAddress_Id.ToString();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    if (int.TryParse(Request.QueryString["id"], out id))
                    {
                        var order = orderManager.GetById(id);
                        if (order != null)
                        {

                            switch (txtStatus.Text)
                            {
                                case "Delivered":
                                    order.Status = OrderStatus.Delivered;
                                    break;
                                case "InProccess":
                                    order.Status = OrderStatus.InProccess;
                                    break;
                                case "Paid":
                                    order.Status = OrderStatus.Paid;
                                    break;
                                case "Pending":
                                    order.Status = OrderStatus.Pending;
                                    break;
                                case "Sent":
                                    order.Status = OrderStatus.Sent;
                                    break;
                                default:
                                    
                                    break;
                            }

                            context.SaveChanges();

                            Response.Redirect("~/Admin/OrderList.aspx");
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Admin/OrderList.aspx");
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
