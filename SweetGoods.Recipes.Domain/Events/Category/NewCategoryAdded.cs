using SweetGoods.Recipes.Domain.Core.Events;
using SweetGoods.Recipes.Domain.Enums;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Events.Category
{
    public class NewCategoryAdded : Event
    {
        public NewCategoryAdded(
            Guid aggregateId,
            NameValueObject name,
            DescriptionValueObject description,
            CategoryType categoryType)
        {
            AggregateId = aggregateId;
            Name = name;
            Description = description;
            CategoryType = categoryType;
        }

        public NewCategoryAdded(
            Guid aggregateId,
            NameValueObject name,
            DescriptionValueObject description,
            int categoryType) : this(aggregateId, name, description, (CategoryType)categoryType)
        {
        }

        public NameValueObject Name { get; }

        public DescriptionValueObject Description { get; }

        public CategoryType CategoryType { get; }
    }
}