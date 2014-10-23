using Error_Handler_Control;
using NinjaLaptops.Data;
using NinjaLaptops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace NinjaLaptops.WebClient
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        private decimal TotalSales = (decimal)0.0;
        protected NinjaLaptopsData data = new NinjaLaptopsData();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridViewOrderedProducts_GetData();
            this.DataBind();
        }


        public IQueryable<Product> GridViewOrderedProducts_GetData()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            if (userId != null)
            {
                var currentUser = data.Users.GetById(userId);

                var orders = currentUser.Products.AsQueryable();
                return orders;
            }
            else
            {
                return null;
            }
            
        }

        public void LinkButtonDeleteOrder_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                var userId = HttpContext.Current.User.Identity.GetUserId();
                var currentUser = data.Users.GetById(userId);

                var product = data.Products.GetById(productId);
                currentUser.Products.Remove(product);
                data.SaveChanges();
                ErrorSuccessNotifier.AddWarningMessage("Product successfully deleted from basket.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
            //Response.Redirect("/OrderDetails");
        }

        protected void GridViewOrderedProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TotalSales += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Price"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = String.Format("{0:c}", TotalSales);
            }
        }

        protected void ButtonBuyOrder_Click(object sender, EventArgs e)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
           
            var currentUser = data.Users.GetById(userId);
            if (currentUser.Products.Count > 0)
            {
                currentUser.Products = new HashSet<Product>();
                data.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("You spend your money successfully!!! Congrats");
                Response.Redirect("/");
            }
            else
            {
                ErrorSuccessNotifier.AddWarningMessage("Your basket is empty!");
                Response.Redirect("/OrderDetails");
            }
        }
    }
}