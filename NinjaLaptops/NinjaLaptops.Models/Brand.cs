namespace NinjaLaptops.Models
{
    using System.Collections.Generic;

    public class Brand
    {
        private ICollection<Product> products;

        public Brand()
        {
            this.Products = new HashSet<Product>();
        }

        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
            }
        }
    }
}
