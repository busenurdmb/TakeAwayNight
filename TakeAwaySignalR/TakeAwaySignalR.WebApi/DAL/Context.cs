using Microsoft.EntityFrameworkCore;

namespace TakeAwaySignalR.WebApi.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-493DFJA\\SQLEXPRESS;initial Catalog=TakeAwayNightDeliveryDb;integrated Security=true;TrustServerCertificate=True;");
        }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}
