using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetGoods.Recipes.Domain.Models.Entities;

namespace SweetGoods.Recipes.Infra.Data.Mappings
{
    public class CookingStepsMap : IEntityTypeConfiguration<CookingStep>
    {
        public void Configure(EntityTypeBuilder<CookingStep> builder)
        {
            builder.Property(x => x.IncrementId)
                .ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.StepAction).HasColumnType("nvarchar(500)");
        }
    }
}