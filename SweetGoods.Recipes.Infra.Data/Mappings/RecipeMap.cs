using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetGoods.Recipes.Domain.Models.Entities;

namespace SweetGoods.Recipes.Infra.Data.Mappings
{
    public class RecipeMap : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(x => x.IncrementId)
                .ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

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