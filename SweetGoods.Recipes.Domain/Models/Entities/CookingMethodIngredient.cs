using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Enums;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class CookingMethodIngredient : Entity
    {
        public CookingMethodIngredient(
            int cookingMethodId,
            int ingredientId,
            MeasureType measureType,
            decimal measure,
            string usage,
            CookingMethod cookingMethod,
            Ingredient ingredient)
        {
            CookingMethodId = cookingMethodId;
            IngredientId = ingredientId;
            MeasureType = measureType;
            Measure = measure;
            Usage = usage;
            CookingMethod = cookingMethod;
            Ingredient = ingredient;
        }

        internal CookingMethodIngredient()
        {
        }

        public int CookingMethodId { get; private set; }

        public int IngredientId { get; private set; }

        public MeasureType MeasureType { get; private set; }

        public decimal Measure { get; private set; }

        public string Usage { get; private set; }

        public virtual CookingMethod CookingMethod { get; private set; }

        public virtual Ingredient Ingredient { get; private set; }
    }
}