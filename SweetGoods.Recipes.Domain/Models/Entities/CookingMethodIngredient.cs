using GiftBagOfBases.Models;
using SweetGoods.Recipes.Domain.Enums;
using System;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class CookingMethodIngredient : Entity
    {
        public CookingMethodIngredient(
            Guid cookingMethodId,
            Guid ingredientId,
            Guid id,
            int measureType,
            decimal measure,
            string usage) : this(cookingMethodId, ingredientId, id, (MeasureType)measureType, measure, usage)
        {
        }

        public CookingMethodIngredient(
            Guid cookingMethodId,
            Guid ingredientId,
            Guid id,
            MeasureType measureType,
            decimal measure,
            string usage)
        {
            CookingMethodId = cookingMethodId;
            IngredientId = ingredientId;
            Id = id;
            MeasureType = measureType;
            Measure = measure;
            Usage = usage;
        }

        public CookingMethodIngredient(
            Guid cookingMethodId,
            Guid ingredientId,
            Guid id,
            MeasureType measureType,
            decimal measure,
            string usage,
            CookingMethod cookingMethod,
            Ingredient ingredient)
        {
            CookingMethodId = cookingMethodId;
            IngredientId = ingredientId;
            Id = id;
            MeasureType = measureType;
            Measure = measure;
            Usage = usage;
            CookingMethod = cookingMethod;
            Ingredient = ingredient;
        }

        internal CookingMethodIngredient()
        {
        }

        public Guid CookingMethodId { get; private set; }

        public Guid IngredientId { get; private set; }

        public MeasureType MeasureType { get; private set; }

        public decimal Measure { get; private set; }

        public string Usage { get; private set; }

        public virtual CookingMethod CookingMethod { get; private set; }

        public virtual Ingredient Ingredient { get; private set; }
    }
}