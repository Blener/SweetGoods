using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Commands.CookingMethod
{
    public class UpdateCookingMethod : CookingMethodBaseCommand
    {
        public UpdateCookingMethod(Guid aggregateId, TimeSpan cookingTime, DescriptionValueObject description)
        {
            AggregateId = aggregateId;
            CookingTime = cookingTime;
            Description = description;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}