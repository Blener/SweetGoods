using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Extensions;

namespace SweetGoods.Recipes.Infra.Data.Mappings
{
    public class CookingStepsMap : EntityTypeConfiguration<CookingStep>
    {
        public override void Map(EntityTypeBuilder<CookingStep> builder)
        {
            builder.Property(x => x.StepAction).HasColumnType("nvarchar(500)");
        }
    }
}