using Microsoft.EntityFrameworkCore;
using SweetGoods.Recipes.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace SweetGoods.Recipes.Infra.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration) where TEntity : Entity
        {
            var builder = modelBuilder.Entity<TEntity>();
            builder.Property(x => x.Id)
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);
            builder.HasKey(x => x.AggregateId);

            configuration.Map(builder);
        }
    }
}