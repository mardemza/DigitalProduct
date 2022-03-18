using DigitalProduct.Core.Domain;
using DigitalProduct.EntityFramework.Config;
using Microsoft.EntityFrameworkCore;

namespace DigitalProduct.EntityFramework;

public class DigitalProductDbContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=App_Data/DigitalProduct.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProductConfig());
        modelBuilder.ApplyConfiguration(new NotificationConfig());
        modelBuilder.ApplyConfiguration(new ShoppingConfig());
    }
}
