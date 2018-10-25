using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetGoods.Recipes.Domain.Models.Entities;

namespace SweetGoods.Recipes.Infra.Data.Mappings
{
    public class IngredientMap : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
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

            builder.Property(x => x.Details).HasColumnType("nvarchar(500)");
        }
    }
}