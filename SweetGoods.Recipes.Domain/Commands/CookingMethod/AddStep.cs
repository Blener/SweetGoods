using System;
using System.Collections.Generic;
using System.Text;

namespace SweetGoods.Recipes.Domain.Commands.CookingMethod
{
    public class AddStep : CookingMethodBaseCommand
    {
        public AddStep(Guid aggregateId, Guid cookingMethodAggregateId, int stepNumber, string stepAction)
        {
            AggregateId = aggregateId;
            CookingMethodAggregateId = cookingMethodAggregateId;
            StepNumber = stepNumber;
            StepAction = stepAction;
        }

        public Guid CookingMethodAggregateId { get; private set; }

        public int StepNumber { get; private set; }

        public string StepAction { get; private set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}