using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Commands.Recipe
{
    public class UpdateRecipe : RecipeBaseCommand
    {
        public UpdateRecipe(Guid aggregateId, NameValueObject name, DescriptionValueObject description)
        {
            AggregateId = aggregateId;
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}