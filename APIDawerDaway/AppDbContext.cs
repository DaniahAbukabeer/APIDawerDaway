using APIDawerDaway.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDawerDaway
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>()
            //    .HasIndex(u => u.PhoneNumber)
            //    .IsUnique();


            modelBuilder.Entity<UserProduct>()
               .HasKey(b => new { b.UserId, b.ProductId });

            modelBuilder.Entity<FeedBack>()
                .HasKey(b => new { b.UserId, b.PharmacyId });

            modelBuilder.Entity<PharmaysProduct>()
               .HasKey(e => new { e.PharmacyId, e.ProductId });

            modelBuilder.Entity<PharmaysProduct>()
                .HasOne(e => e.Product)
                .WithMany(ex => ex.PharmaysProducts)
                .HasForeignKey(e => e.ProductId);

            modelBuilder.Entity<PharmaysProduct>()
                .HasOne(e => e.Pharmacy)
                .WithMany(ex => ex.PharmaysProducts)
                .HasForeignKey(e => e.PharmacyId);

            modelBuilder.Entity<Product>()
        .HasMany(p => p.PharmaysProducts)
        .WithOne(pp => pp.Product)
        .HasForeignKey(pp => pp.ProductId);


        }

        public DbSet<User> Users { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }  
        public DbSet<Product> Products { get; set; }
        public DbSet<Pharmacy> pharmacies { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }
        public DbSet<PharmaysProduct> PharmaysProducts { get; set; }

    }
}