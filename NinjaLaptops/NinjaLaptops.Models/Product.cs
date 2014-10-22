namespace NinjaLaptops.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public int OrderId { get; set; }

        public virtual Order Oreder { get; set; }
    }
}
