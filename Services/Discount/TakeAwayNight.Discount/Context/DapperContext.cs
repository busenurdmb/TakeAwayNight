using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using TakeAwayNight.Discount.Entities;

namespace TakeAwayNight.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-493DFJA\\SQLEXPRESS;initial Catalog=TakeAwayNightDiscountDb;integrated Security=true;TrustServerCertificate=True;");
        //}
        public DbSet<DiscountCoupon> DiscountCoupons{ get; set; }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        //
    }
}
