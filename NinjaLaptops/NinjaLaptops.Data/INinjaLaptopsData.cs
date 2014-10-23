namespace NinjaLaptops.Data
{
    using NinjaLaptops.Models;

    public interface INinjaLaptopsData
    {
        IRepository<User> Users { get; }

        IRepository<Brand> Brands { get; }

        IRepository<Product> Products { get; }

        int SaveChanges();
    }
}
