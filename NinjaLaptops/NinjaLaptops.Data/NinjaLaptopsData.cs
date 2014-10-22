namespace NinjaLaptops.Data
{
    using NinjaLaptops.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class NinjaLaptopsData : INinjaLaptopsData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public NinjaLaptopsData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Brand> Brands
        {
            get
            {
                return this.GetRepository<Brand>();
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                return this.GetRepository<Order>();
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EfRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
