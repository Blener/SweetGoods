using SweetGoods.Recipes.Domain.Core.Models;
using System;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class CookingStep : Entity
    {
        public CookingStep(Guid id, Guid cookingMethodId, int stepNumber, string stepAction)
        {
            Id = id;
            CookingMethodId = cookingMethodId;
            StepNumber = stepNumber;
            StepAction = stepAction;
        }

        internal CookingStep()
        {
        }

        public Guid CookingMethodId { get; private set; }

        public int StepNumber { get; private set; }

        public string StepAction { get; private set; }
    }
}