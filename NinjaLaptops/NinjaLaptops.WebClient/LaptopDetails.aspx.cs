using Error_Handler_Control;
using NinjaLaptops.Data;
using NinjaLaptops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinjaLaptops.WebClient
{
    public partial class LaptopDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data = new NinjaLaptopsData();

            int selectedLaptopId = int.Parse(Request.Params["id"]);
            Product selectedLaptop = data.Products.All().FirstOrDefault(p => p.BrandId == selectedLaptopId);

            this.ProductViewLaptop.DataSource = new List<Product>() { selectedLaptop };
            this.ProductViewLaptop.DataBind();

            
        }

        protected void ButtonDeleteProduct_Click(object sender, EventArgs e)
        {
            int selectedLaptopId = int.Parse(Request.Params["id"]);
            var data = new NinjaLaptopsData();
            var product = data.Products.GetById(selectedLaptopId);
            if (product == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Product does not exists");
                return;
            }
            data.Products.Delete(product);
            data.SaveChanges();
            ErrorSuccessNotifier.AddSuccessMessage("Product successfully deleted.");
            Response.Redirect("/Laptops");
            this.DataBind();
        }

        protected void ButtonEditProduct_Click(object sender, EventArgs e)
        {
            int selectedLaptopId = int.Parse(Request.Params["id"]);
            Response.Redirect("/AdminControllers/EditProduct?productId=" + selectedLaptopId);
        } 
    }
}