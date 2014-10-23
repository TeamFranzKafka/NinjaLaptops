using Error_Handler_Control;
using NinjaLaptops.Data;
using NinjaLaptops.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinjaLaptops.WebClient.AdminControllers
{
    public partial class EditProduct : System.Web.UI.Page
    {
        private NinjaLaptopsData data;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new NinjaLaptopsData();

            if (!Page.IsPostBack)
            {
                var brands = data.Brands.All().ToList();
                this.DropDownListBrands.DataSource = brands;
                this.DropDownListBrands.DataBind();
            }
        }

        protected void Updade_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int selectedLaptopId = int.Parse(Request.Params["productId"]);
                var product = data.Products.GetById(selectedLaptopId);

                if (this.UploadImage.HasFile)
                {
                    if (this.UploadImage.PostedFile.ContentType == "image/jpeg" ||
                       this.UploadImage.PostedFile.ContentType == "image/gif" ||
                       this.UploadImage.PostedFile.ContentType == "image/png")
                    {             
                        var filename = product.Model + Path.GetExtension(this.UploadImage.FileName);
                        this.UploadImage.SaveAs(this.Server.MapPath("~/Uploads/Images/") + filename);
                        product.PictureLink = "Uploads/Images/" + filename;
                    }
                }
                var bratndId = int.Parse(this.DropDownListBrands.SelectedValue);
                var newBrand = data.Brands.GetById(bratndId);
                product.Brand = newBrand;
                product.BrandId = bratndId;
              
                if (this.Model.Text != "")
                {
                    product.Model = this.Model.Text;
                }
               
                if (this.Price.Text != "")
                {
                    var price = decimal.Parse(this.Price.Text);
                    if (price < 0)
                    {
                        ErrorSuccessNotifier.AddErrorMessage("Product price cannot be negative!");
                        return;
                    }
                    
                    product.Price = decimal.Parse(this.Price.Text);
                }
                this.data.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Product updated successfully!");
                Response.Redirect("/LaptopDetails?id=" + selectedLaptopId);
            }
        }
    }
}