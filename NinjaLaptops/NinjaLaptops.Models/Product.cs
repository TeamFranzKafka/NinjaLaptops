using System.Collections.Generic;
namespace NinjaLaptops.Models
{
    public class Product
    {
        private ICollection<Order> orders;



        public Product()
        {
            this.Orders = new HashSet<Order>();
        }

        public int ProductId { get; set; }

        public string Model { get; set; }

        public string PictureLink { get; set; }

        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<Order> Orders
        {
            get
            {
                return orders;
            }

            set
            {
                orders = value;
            }
        }
    }
}
