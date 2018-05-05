using SweetGoods.Recipes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetGoods.Recipes.Domain.Commands.CookingMethod
{
    public class AddIngredient : CookingMethodBaseCommand
    {
        public AddIngredient(Guid aggregateId, Guid cookingMethodAggregateId, Guid ingredientAggregateId, MeasureType measureType, decimal measure, string usage)
        {
            AggregateId = aggregateId;
            CookingMethodAggregateId = cookingMethodAggregateId;
            IngredientAggregateId = ingredientAggregateId;
            MeasureType = measureType;
            Measure = measure;
            Usage = usage;
        }

        public Guid CookingMethodAggregateId { get; private set; }

        public Guid IngredientAggregateId { get; private set; }

        public MeasureType MeasureType { get; private set; }

        public decimal Measure { get; private set; }

        public string Usage { get; private set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}