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
    }
}