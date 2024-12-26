using ArticleChat.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace ArticleChat.Models
{
    public sealed class ArticleChatDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ArticleChatDbContext(DbContextOptions<ArticleChatDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
