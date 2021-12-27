using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StoreShop.DataAccess
{
    public class StoreShopDataContext :  IdentityDbContext //DbContext//
    {
        public IConfiguration _configuration { get; set; }
        public StoreShopDataContext(IConfiguration configuration, DbContextOptions<StoreShopDataContext> dbContextOptions)
        :base(dbContextOptions)
        {
            
            _configuration = configuration;  //actually this was getting used in OnConfiguration method
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            
        //    string connectionString = _configuration.GetConnectionString("DefaultConnection");

        //    optionsBuilder
        //             .UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60))
        //             .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CustomerProductType> CustomerProductTypes { get; set; }

        public DbSet<MasProductType> MasProductTypes { get; set; }

        public DbSet<MasProductCategory> MasProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

        //public DbSet<IdentityUser> IdentityUsers { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<SMS> SMS { get; set; }   
    }
}
