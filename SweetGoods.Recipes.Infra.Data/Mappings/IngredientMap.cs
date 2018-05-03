using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Extensions;

namespace SweetGoods.Recipes.Infra.Data.Mappings
{
    public class IngredientMap : EntityTypeConfiguration<Ingredient>
    {
        public override void Map(EntityTypeBuilder<Ingredient> builder)
        {
            builder
                .OwnsOne(x => x.Name)
                .Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(x => x.Details).HasColumnType("nvarchar(500)");
        }
    }
}