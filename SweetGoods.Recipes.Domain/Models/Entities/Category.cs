using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Enums;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class Category : SoftDeleteEntity
    {
        internal Category()
        {
        }

        public Category(
            int id,
            Guid aggregateId,
            NameValueObject name,
            DescriptionValueObject description,
            CategoryType categoryType,
            bool softDeleted) : this(name, description, categoryType)
        {
            Id = id;
            AggregateId = aggregateId;
            SoftDeleted = softDeleted;
        }

        public Category(
            NameValueObject name,
            DescriptionValueObject description,
            CategoryType categoryType)
        {
            Name = name;
            Description = description;
            CategoryType = categoryType;
        }

        public NameValueObject Name { get; }

        public DescriptionValueObject Description { get; }

        public CategoryType CategoryType { get; }
    }
}