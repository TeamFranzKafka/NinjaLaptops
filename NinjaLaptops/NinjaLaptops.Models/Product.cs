using System.Collections.Generic;
namespace NinjaLaptops.Models
{
    public class Product
    {
        private ICollection<User> users;

        public Product()
        {
            this.Users = new HashSet<User>();
        }

        public int ProductId { get; set; }

        public string Model { get; set; }

        public string PictureLink { get; set; }

        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<User> Users
        {
            get
            {
                return users;
            }

            set
            {
                users = value;
            }
        }
    }
}
