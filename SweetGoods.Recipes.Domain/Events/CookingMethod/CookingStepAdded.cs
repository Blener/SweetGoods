using GiftBagOfBases.Events;
using System;

namespace SweetGoods.Recipes.Domain.Events.CookingMethod
{
    public class CookingStepAdded : Event
    {
        public CookingStepAdded(Guid aggregateId, Guid cookingMethodAggregateId, int stepNumber, string stepAction)
        {
            AggregateId = aggregateId;
            CookingMethodAggregateId = cookingMethodAggregateId;
            StepNumber = stepNumber;
            StepAction = stepAction;
        }

        public Guid CookingMethodAggregateId { get; }

        public int StepNumber { get; }

        public string StepAction { get; }
    }
}