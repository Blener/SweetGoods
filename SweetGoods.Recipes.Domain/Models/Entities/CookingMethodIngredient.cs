using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Enums;
using System;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class CookingMethodIngredient : Entity
    {
        public CookingMethodIngredient(
            Guid cookingMethodAggregateId,
            Guid ingredientAggregateId,
            Guid aggregateId,
            int measureType,
            decimal measure,
            string usage) : this(cookingMethodAggregateId, ingredientAggregateId, aggregateId, (MeasureType)measureType, measure, usage)
        {
        }

        public CookingMethodIngredient(
            Guid cookingMethodAggregateId,
            Guid ingredientAggregateId,
            Guid aggregateId,
            MeasureType measureType,
            decimal measure,
            string usage)
        {
            CookingMethodAggregateId = cookingMethodAggregateId;
            IngredientAggregateId = ingredientAggregateId;
            AggregateId = aggregateId;
            MeasureType = measureType;
            Measure = measure;
            Usage = usage;
        }

        public CookingMethodIngredient(
            Guid cookingMethodAggregateId,
            Guid ingredientAggregateId,
            Guid aggregateId,
            MeasureType measureType,
            decimal measure,
            string usage,
            CookingMethod cookingMethod,
            Ingredient ingredient)
        {
            CookingMethodAggregateId = cookingMethodAggregateId;
            IngredientAggregateId = ingredientAggregateId;
            AggregateId = aggregateId;
            MeasureType = measureType;
            Measure = measure;
            Usage = usage;
            CookingMethod = cookingMethod;
            Ingredient = ingredient;
        }

        internal CookingMethodIngredient()
        {
        }

        public Guid CookingMethodAggregateId { get; private set; }

        public Guid IngredientAggregateId { get; private set; }

        public MeasureType MeasureType { get; private set; }

        public decimal Measure { get; private set; }

        public string Usage { get; private set; }

        public virtual CookingMethod CookingMethod { get; private set; }

        public virtual Ingredient Ingredient { get; private set; }
    }
}