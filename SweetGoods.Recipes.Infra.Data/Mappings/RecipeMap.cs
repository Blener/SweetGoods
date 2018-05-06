using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Extensions;

namespace SweetGoods.Recipes.Infra.Data.Mappings
{
    public class RecipeMap : EntityTypeConfiguration<Recipe>
    {
        public override void Map(EntityTypeBuilder<Recipe> builder)
        {
            builder
                .OwnsOne(x => x.Name)
                .Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder
                .OwnsOne(x => x.Description)
                .Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

            builder.HasMany(x => x.RecipeCategories).WithOne(x => x.Recipe).HasForeignKey(x => x.RecipeId);

            builder.HasMany(x => x.CookingMethods).WithOne(x => x.Recipe).HasForeignKey(x => x.RecipeId);
        }
    }
}