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

        //public DbSet<IdentityUser> IdentityUsers { get; set; }
    }
}
