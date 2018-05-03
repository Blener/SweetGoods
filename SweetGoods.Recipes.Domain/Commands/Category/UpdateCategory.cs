using SweetGoods.Recipes.Domain.Enums;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Commands.Category
{
    public class UpdateCategory : CategoryBaseCommand
    {
        protected UpdateCategory(Guid aggregateId, NameValueObject name, DescriptionValueObject description, CategoryType categoryType)
        {
            AggregateId = aggregateId;
            Name = name;
            Description = description;
            CategoryType = categoryType;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}