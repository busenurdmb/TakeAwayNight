using Microsoft.EntityFrameworkCore;
using TakeAwayNight.Comment.DAL.Entities;

namespace TakeAwayNight.Comment.DAL.Context
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options):base(options) 
        {

        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
