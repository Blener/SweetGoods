using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Extensions;

namespace SweetGoods.Recipes.Infra.Data.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public override void Map(EntityTypeBuilder<Category> builder)
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
        }
    }
}