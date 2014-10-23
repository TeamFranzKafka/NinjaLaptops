using NinjaLaptops.Data;
using NinjaLaptops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinjaLaptops.WebClient.AdminControllers
{
    public partial class CreateBrand : System.Web.UI.Page
    {
        private NinjaLaptopsData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new NinjaLaptopsData();
        }

        protected void Create(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var brand = new Brand();
                brand.BrandName = this.Name.Text;
                this.data.Brands.Add(brand);
                this.data.SaveChanges();
                Response.Redirect("/");
            }
        }
    }
}