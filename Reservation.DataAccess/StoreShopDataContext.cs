using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StoreShop.DataAccess
{
    public class StoreShopDataContext : DbContext
    {
        public IConfiguration _configuration { get; set; }
        public StoreShopDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if (!optionsBuilder.IsConfigured)
            //{
            //string connectionString = !string.IsNullOrEmpty( _connectionString) ?   _connectionString : Configuration.GetConnectionString("ProdConnection");
            //connectionString = @"Data Source=LEGAL10\SQLEXPRESS,49731;Initial Catalog=Legalxgen_Dev;MultipleActiveResultSets=True;Persist Security Info=True;User ID=sa;Password=aspdb";//"data source=LEGAL10\SQLEXPRESS;initial catalog=Legalxgen_Dev;persist security info=True;user id=sa;password=aspdb;";

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            optionsBuilder
                     .UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60))
                     .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            //}
        }

        public DbSet<User> Users { get; set; }
    }
}
