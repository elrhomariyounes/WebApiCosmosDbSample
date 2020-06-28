using Microsoft.EntityFrameworkCore;
using WebApiCosmosDbSample.Data.Entities;

namespace WebApiCosmosDbSample.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<News> News { get; set; }
    }
}
