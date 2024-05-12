using BlogAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPP.Data
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options) { }
        public DbSet<UserBlog> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
