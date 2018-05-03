using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Extensions;

namespace SweetGoods.Recipes.Infra.Data.Mappings
{
    public class CookingMethodMap : EntityTypeConfiguration<CookingMethod>
    {
        public override void Map(EntityTypeBuilder<CookingMethod> builder)
        {
            builder
                .OwnsOne(x => x.Description)
                .Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

            builder.HasMany(x => x.Ingredients).WithOne(x => x.CookingMethod);

            builder.HasMany(x => x.Steps).WithOne().HasForeignKey(x => x.CookingMethodId);

            builder.HasOne(x => x.Recipe).WithMany(x => x.CookingMethods);

            builder.Property(x => x.CookingTime).HasColumnType("time(7)");
        }
    }
}