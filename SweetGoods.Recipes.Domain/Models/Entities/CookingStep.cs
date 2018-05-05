using SweetGoods.Recipes.Domain.Core.Models;
using System;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class CookingStep : Entity
    {
        public CookingStep(Guid aggregateId, Guid cookingMethodAggregateId, int stepNumber, string stepAction)
        {
            AggregateId = aggregateId;
            CookingMethodAggregateId = cookingMethodAggregateId;
            StepNumber = stepNumber;
            StepAction = stepAction;
        }

        internal CookingStep()
        {
        }

        public Guid CookingMethodAggregateId { get; private set; }

        public int StepNumber { get; private set; }

        public string StepAction { get; private set; }
    }
}