using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetGoods.Recipes.Domain.Models.Entities;

namespace SweetGoods.Recipes.Infra.Data.Mappings
{
    public class RecipeCategoryMap : IEntityTypeConfiguration<RecipeCategory>
    {
        public void Configure(EntityTypeBuilder<RecipeCategory> builder)
        {
            builder.Property(x => x.IncrementId)
                .ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Recipe).WithMany(x => x.RecipeCategories).HasForeignKey(x => x.RecipeId);
        }
    }
}