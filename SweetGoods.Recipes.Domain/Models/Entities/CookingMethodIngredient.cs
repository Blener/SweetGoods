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

        public int CookingMethodId { get; }

        public int IngredientId { get; }

        public MeasureType MeasureType { get; }

        public decimal Measure { get; }

        public string Usage { get; }

        public virtual CookingMethod CookingMethod { get; }

        public virtual Ingredient Ingredient { get; }
    }
}