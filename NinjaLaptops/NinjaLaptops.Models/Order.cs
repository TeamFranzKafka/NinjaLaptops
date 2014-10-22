namespace NinjaLaptops.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        private ICollection<Product> products;

        public Order() {
            this.Products = new HashSet<Product>();
        }

        public int OrderId { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

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
