using SweetGoods.Recipes.Domain.Core.Commands;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Commands.CookingMethod
{
    public abstract class CookingMethodBaseCommand : Command
    {
        public Guid RecipeAggregateId { get; protected set; }

        public TimeSpan CookingTime { get; protected set; }

        public DescriptionValueObject Description { get; protected set; }
    }
}