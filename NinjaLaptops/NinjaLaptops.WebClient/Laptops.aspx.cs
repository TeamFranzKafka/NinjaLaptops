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
            if (!Page.IsPostBack)
            {
                var data = new NinjaLaptopsData();

                this.CheckBoxBrands.DataSource = data.Brands.All().ToList();
                this.ListViewLaptops.DataSource = data.Products.All().ToList();
                this.DataBind();
            }
        }

        protected void CheckBoxBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = new NinjaLaptopsData();

            List<int> selectedBrandIds = new List<int>();
            foreach (ListItem item in this.CheckBoxBrands.Items)
            {
                if (item.Selected)
                {
                    selectedBrandIds.Add(int.Parse(item.Value));
                }
            }

            if (selectedBrandIds.Count > 0)
            {
                this.ListViewLaptops.DataSource = data.Products.All().Where(p => selectedBrandIds.Contains<int>(p.BrandId)).ToList();
            }
            else
            {
                this.ListViewLaptops.DataSource = data.Products.All().ToList();
            }

            this.ListViewLaptops.DataBind();

        }
    }
}