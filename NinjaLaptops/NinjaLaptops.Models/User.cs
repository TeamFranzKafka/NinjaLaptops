﻿namespace NinjaLaptops.Models
{
    using System.Threading.Tasks;
    using System.Security.Claims;
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Product> products;

        public User()
        {
            this.Products = new HashSet<Product>();
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }

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
