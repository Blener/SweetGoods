using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Extensions;

namespace SweetGoods.Recipes.Infra.Data.Mappings
{
    public class CookingMethodIngredientMap : EntityTypeConfiguration<CookingMethodIngredient>
    {
        public override void Map(EntityTypeBuilder<CookingMethodIngredient> builder)
        {
            builder.HasOne(x => x.CookingMethod).WithMany(x => x.Ingredients);

            builder.HasOne(x => x.Ingredient).WithMany().HasForeignKey(x => x.IngredientAggregateId);

            builder.Property(x => x.MeasureType).HasColumnType("int");

            builder.Property(x => x.Measure).HasColumnType("decimal(18,2)");

            builder.Property(x => x.Usage).HasColumnType("nvarchar(500)").IsRequired(false);
        }
    }
}