using SweetGoods.Recipes.Domain.Core.Events;
using System;

namespace SweetGoods.Recipes.Domain.Events.Category
{
    public class CategoryDeleted : Event
    {
        public CategoryDeleted(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}