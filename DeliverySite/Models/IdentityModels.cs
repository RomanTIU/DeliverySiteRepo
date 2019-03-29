using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeliverySite.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public  ApplicationRole(string roleName): base(roleName) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<DeliveryMan> DeliveryMen { get; set; }

        public DbSet<Command> Commands { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Cart> Carts { get; set; }

        

       


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
    }
}