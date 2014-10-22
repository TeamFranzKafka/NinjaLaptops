namespace NinjaLaptops.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using NinjaLaptops.Models;
    using NinjaLaptops.Data.Migrations;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Brand> Brands { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Order> Orders { get; set; }
    }
}
