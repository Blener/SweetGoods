using System;

namespace SweetGoods.Recipes.Domain.Commands.CookingMethod
{
    public class DeleteCookingMethod : CookingMethodBaseCommand
    {
        public DeleteCookingMethod(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}