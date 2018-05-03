using SweetGoods.Recipes.Domain.Core.Models;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class CookingSteps : Entity
    {
        public CookingSteps(int cookingMethodId, int stepNumber, string stepAction)
        {
            CookingMethodId = cookingMethodId;
            StepNumber = stepNumber;
            StepAction = stepAction;
        }

        internal CookingSteps()
        {
        }

        public int CookingMethodId { get; }

        public int StepNumber { get; }

        public string StepAction { get; }
    }
}