using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Commands.CookingMethod
{
    public class AddNewCookingMethod : CookingMethodBaseCommand
    {
        public AddNewCookingMethod(Guid recipeAggregateId, TimeSpan cookingTime, DescriptionValueObject description)
        {
            RecipeAggregateId = recipeAggregateId;
            CookingTime = cookingTime;
            Description = description;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}