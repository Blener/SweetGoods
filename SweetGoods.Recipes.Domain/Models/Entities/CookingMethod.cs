using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;
using System.Collections.Generic;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class CookingMethod : SoftDeleteEntity
    {
        public CookingMethod(
            int id,
            Guid aggregateId,
            int recipeId,
            TimeSpan cookingTime,
            DescriptionValueObject description,
            bool softDeleted) : this(recipeId, cookingTime, description)
        {
            Id = id;
            AggregateId = aggregateId;
            SoftDeleted = softDeleted;
        }

        public CookingMethod(
            int recipeId,
            TimeSpan cookingTime,
            DescriptionValueObject description,
            Recipe recipe,
            ICollection<CookingMethodIngredient> ingredients,
            ICollection<CookingSteps> steps) : this(recipeId, cookingTime, description)
        {
            Recipe = recipe;
            Ingredients = ingredients;
            Steps = steps;
        }

        public CookingMethod(
            int recipeId,
            TimeSpan cookingTime,
            DescriptionValueObject description)
        {
            RecipeId = recipeId;
            CookingTime = cookingTime;
            Description = description;
            Ingredients = new HashSet<CookingMethodIngredient>();
            Steps = new HashSet<CookingSteps>();
        }

        internal CookingMethod()
        {
        }

        public int RecipeId { get; }

        public TimeSpan CookingTime { get; }

        public DescriptionValueObject Description { get; }

        public virtual Recipe Recipe { get; }

        public virtual ICollection<CookingMethodIngredient> Ingredients { get; }

        public virtual ICollection<CookingSteps> Steps { get; }
    }
}