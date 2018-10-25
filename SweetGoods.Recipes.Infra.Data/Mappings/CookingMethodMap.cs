using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetGoods.Recipes.Domain.Models.Entities;

namespace SweetGoods.Recipes.Infra.Data.Mappings
{
    public class CookingMethodMap : IEntityTypeConfiguration<CookingMethod>
    {
        public void Configure(EntityTypeBuilder<CookingMethod> builder)
        {
            builder.Property(x => x.IncrementId)
                .ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder
                .OwnsOne(x => x.Description)
                .Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

            builder.HasMany(x => x.Ingredients).WithOne(x => x.CookingMethod).HasForeignKey(x => x.CookingMethodId);

            builder.HasMany(x => x.Steps).WithOne().HasForeignKey(x => x.CookingMethodId);

            builder.HasOne(x => x.Recipe).WithMany(x => x.CookingMethods);

            builder.Property(x => x.CookingTime).HasColumnType("time(7)");
        }
    }
}