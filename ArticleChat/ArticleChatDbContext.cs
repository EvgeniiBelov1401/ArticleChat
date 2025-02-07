using ArticleChat.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace ArticleChat
{
    public sealed class ArticleChatDbContext(DbContextOptions<ArticleChatDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
