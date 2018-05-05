using SweetGoods.Recipes.Domain.Core.Events;
using SweetGoods.Recipes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetGoods.Recipes.Domain.Events.CookingMethod
{
    public class CookingMethodIngredientAdded : Event
    {
        public CookingMethodIngredientAdded(Guid aggregateId, Guid ingredientAggregateId, MeasureType measureType, decimal measure, string usage)
        {
            AggregateId = aggregateId;
            IngredientAggregateId = ingredientAggregateId;
            MeasureType = measureType;
            Measure = measure;
            Usage = usage;
        }

        public Guid IngredientAggregateId { get; }

        public MeasureType MeasureType { get; }

        public decimal Measure { get; }

        public string Usage { get; }
    }
}