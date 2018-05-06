using Microsoft.EntityFrameworkCore;
using SweetGoods.Recipes.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SweetGoods.Recipes.Infra.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration) where TEntity : Entity
        {
            var builder = modelBuilder.Entity<TEntity>();
            builder.Property(x => x.IncrementId)
                .ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            configuration.Map(builder);
        }
    }
}