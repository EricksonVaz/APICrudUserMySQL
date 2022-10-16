using APICrudUserMySQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace APICrudUserMySQL.Helpers
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionstring = _configuration.GetConnectionString("WebApiDatabase");
            options.UseMySql(connectionstring,ServerVersion.AutoDetect(connectionstring));
        }

        public DbSet<User> Users { get; set; }
    }
}
