using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetGoods.Recipes.Domain.Models.Entities;

namespace SweetGoods.Recipes.Infra.Data.Mappings
{
    public class CookingMethodIngredientMap : IEntityTypeConfiguration<CookingMethodIngredient>
    {
        public void Configure(EntityTypeBuilder<CookingMethodIngredient> builder)
        {
            builder.Property(x => x.IncrementId)
                .ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.HasOne(x => x.CookingMethod).WithMany(x => x.Ingredients);

            builder.HasOne(x => x.Ingredient).WithMany().HasForeignKey(x => x.IngredientId);

            builder.Property(x => x.MeasureType).HasColumnType("int");

            builder.Property(x => x.Measure).HasColumnType("decimal(18,2)");

            builder.Property(x => x.Usage).HasColumnType("nvarchar(500)").IsRequired(false);
        }
    }
}