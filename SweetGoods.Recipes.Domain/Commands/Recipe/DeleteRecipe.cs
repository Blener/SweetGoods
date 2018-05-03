using System;

namespace SweetGoods.Recipes.Domain.Commands.Recipe
{
    public class DeleteRecipe : RecipeBaseCommand
    {
        public DeleteRecipe(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}