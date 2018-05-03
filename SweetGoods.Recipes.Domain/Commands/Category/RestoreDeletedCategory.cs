using System;

namespace SweetGoods.Recipes.Domain.Commands.Category
{
    public class RestoreDeletedCategory : CategoryBaseCommand
    {
        protected RestoreDeletedCategory(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}