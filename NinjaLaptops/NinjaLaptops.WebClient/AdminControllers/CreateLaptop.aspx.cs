using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using Owin;
using NinjaLaptops.Data;
using NinjaLaptops.Models;
using System.IO;
namespace NinjaLaptops.WebClient.AdminControllers
{
    public partial class CreateLaptop : System.Web.UI.Page
    {
        private NinjaLaptopsData data;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new NinjaLaptopsData();

            var brands = data.Brands.All().ToList();
            this.DropDownListBrands.DataSource = brands;
            this.DropDownListBrands.DataBind();
        }


        protected void Create(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //TODO: add file upload
             

                if (this.UploadImage.HasFile)
                {
                    if (this.UploadImage.PostedFile.ContentType == "image/jpeg" ||
                       this.UploadImage.PostedFile.ContentType == "image/gif" ||
                       this.UploadImage.PostedFile.ContentType == "image/png")
                    {
                        var product = new Product();
                        product.BrandId = int.Parse(this.DropDownListBrands.SelectedValue);
                        product.Model = this.Model.Text;
                        product.Price = decimal.Parse(this.Price.Text);

                        var filename =  product.Model + Path.GetExtension(this.UploadImage.FileName);
                        this.UploadImage.SaveAs(this.Server.MapPath("~/Uploads/Images/") + filename);
                        product.PictureLink = "Uploads/Images/" + filename;

                        this.data.Products.Add(product);
                        this.data.SaveChanges();
                        Response.Redirect("/");
                    }
                }
            }
        }
    }
}