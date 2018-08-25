namespace MagicOfSewing.Data
{
    using MagicOfSewing.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class MagicOfSewingDbContext : IdentityDbContext<User>
    {
        public MagicOfSewingDbContext(DbContextOptions<MagicOfSewingDbContext> options)
            : base(options) { }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<ContactMessage> ContactMessages { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Fabric> Fabrics { get; set; }

        public DbSet<Strategy> Strategies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            base.OnModelCreating(builder);
        }
    }
}
