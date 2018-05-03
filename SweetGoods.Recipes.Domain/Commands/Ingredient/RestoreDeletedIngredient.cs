using System;

namespace SweetGoods.Recipes.Domain.Commands.Ingredient
{
    public class RestoreDeletedIngredient : IngredientBaseCommand
    {
        public RestoreDeletedIngredient(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}