using DigitalProduct.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalProduct.EntityFramework.Config;

public class ShoppingConfig : IEntityTypeConfiguration<Shopping>
{
    public void Configure(EntityTypeBuilder<Shopping> builder)
    {
        builder.ToTable("Shoppings");
        builder.HasKey(x => x.Id);
    }
}
