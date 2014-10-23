using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NinjaLaptops.Data;
using Microsoft.AspNet.Identity;
using Error_Handler_Control;

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
            else
            {
                ErrorSuccessNotifier.AddSuccessMessage("Product added to basket!!!");
          
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

        protected void LinkButtonOrderProduct_Command(object sender, CommandEventArgs e)
        {
            var data = new NinjaLaptopsData();
            var userId = HttpContext.Current.User.Identity.GetUserId();
            if (userId == null)
            {
                ErrorSuccessNotifier.AddWarningMessage("You are not logged in!");
                return;
            }
            try
            {
                int productId = Convert.ToInt32(e.CommandArgument);
               
                var currentUser = data.Users.GetById(userId);
                var product = data.Products.GetById(productId);
                foreach (var currentProduct in currentUser.Products)
                {
                    if (currentProduct.ProductId == productId) 
                    {
                        ErrorSuccessNotifier.AddWarningMessage("You already added this product");
                        return;
                    }
                }

                currentUser.Products.Add(product);
                
                data.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Product added to basket!!!");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }
    }
}