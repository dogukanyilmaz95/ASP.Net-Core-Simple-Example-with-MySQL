using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
namespace StockControl.Models
{
    public class StockContext : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;password=123456;persistsecurityinfo=True;database=stockcontrol;SslMode=none");
              //  optionsBuilder.UseSqlServer(@"Data Source=DOGUKANYILMAZ\SQLEXPRESS;Initial Catalog=StokTakip;Integrated Security=True;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.email).HasColumnName("Email");
                entity.Property(e => e.name).HasColumnName("Name");
                entity.Property(e => e.surname).HasColumnName("Surname");
                entity.Property(e => e.password).HasColumnName("Password");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.name).HasColumnName("Name");
                entity.Property(e => e.code).HasColumnName("Code");
                entity.Property(e => e.quanitiy).HasColumnName("Quantity");
                entity.Property(e => e.userId).HasColumnName("UserId");
                entity.Property(e => e.price).HasColumnName("Price");
            });
        }
    }
}
