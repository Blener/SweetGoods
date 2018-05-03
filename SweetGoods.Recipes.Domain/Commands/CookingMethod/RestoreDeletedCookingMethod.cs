using System;

namespace SweetGoods.Recipes.Domain.Commands.CookingMethod
{
    public class RestoreDeletedCookingMethod : CookingMethodBaseCommand
    {
        public RestoreDeletedCookingMethod(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}