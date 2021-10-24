using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicationProcess.July2021.Data.DataContext
{
    public class ApplicationProcessDbContext : DbContext
    {
        public ApplicationProcessDbContext(DbContextOptions<ApplicationProcessDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }

        public DbSet<UserAsset> UserAssets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<Asset>().ToTable("Asset");

            modelBuilder.Entity<UserAsset>().ToTable("UserAsset");
            
            modelBuilder.Entity<UserAsset>()
                .HasOne(ua => ua.Asset)
                .WithMany(a => a.UserAssets)
                .HasForeignKey(ua => ua.AssetId);

            modelBuilder.Entity<UserAsset>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAssets)
                .HasForeignKey(ua => ua.UserId);
        }
    }
}
