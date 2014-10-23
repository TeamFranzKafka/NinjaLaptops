namespace NinjaLaptops.WebClient.Models
{
    using NinjaLaptops.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class ProductViewModel
    {
        public static Expression<Func<Product, ProductViewModel>> FromProduct
        {
            get
            {
                return p => new ProductViewModel
                {
                    Brand = p.Brand.BrandName,
                    Model = p.Model,
                    PictureLink = p.PictureLink,
                    Price = p.Price
                };
            }
        }


        public string Brand { get; set; }

        public string Model { get; set; }

        public string PictureLink { get; set; }

        public decimal Price { get; set; }

    }
}