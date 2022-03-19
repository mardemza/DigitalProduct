using DigitalProduct.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalProduct.EntityFramework.Config;

public class ShoppingProductConfig : IEntityTypeConfiguration<ShoppingProduct>
{
    public void Configure(EntityTypeBuilder<ShoppingProduct> builder)
    {
        builder.ToTable("ShoppingProducts");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Product)
               .WithMany(x => x.ProductShoppings)
               .HasForeignKey(x => x.ProductId);

        builder.HasOne(x => x.Shopping)
               .WithMany(x => x.ProductShoppings)
               .HasForeignKey(x => x.ShoppingId);
    }
}
