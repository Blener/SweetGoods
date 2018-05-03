using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Extensions;

namespace SweetGoods.Recipes.Infra.Data.Mappings
{
    public class RecipeCategoryMap : EntityTypeConfiguration<RecipeCategory>
    {
        public override void Map(EntityTypeBuilder<RecipeCategory> builder)
        {
            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Recipe).WithMany(x => x.RecipeCategories);
        }
    }
}