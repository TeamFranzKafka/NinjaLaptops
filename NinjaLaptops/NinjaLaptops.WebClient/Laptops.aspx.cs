using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NinjaLaptops.Data;

namespace NinjaLaptops.WebClient
{
    public partial class Laptops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data = new NinjaLaptopsData();

            this.BulletedListBrands.DataSource = data.Brands.All().ToList();
            this.ListViewLaptops.DataSource = data.Products.All().ToList();

            this.DataBind();
        }

        protected void BulletedListBrands_Click(object sender, BulletedListEventArgs e)
        {
            var data = new NinjaLaptopsData();

            this.ListViewLaptops.DataSource = data.Products.All().Where(p => p.BrandId == e.Index).ToList();
            this.ListViewLaptops.DataBind();
        }
    }
}