using GiftBagOfBases.Models;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;
using System.Collections.Generic;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class CookingMethod : SoftDeleteEntity<CookingMethod>
    {
        public CookingMethod(
            int incrementId,
            Guid id,
            Guid recipeId,
            TimeSpan cookingTime,
            DescriptionValueObject description,
            bool softDeleted) : this(recipeId, cookingTime, description)
        {
            IncrementId = incrementId;
            Id = id;
            SoftDeleted = softDeleted;
        }

        public CookingMethod(
            Guid recipeId,
            TimeSpan cookingTime,
            DescriptionValueObject description)
        {
            RecipeId = recipeId;
            CookingTime = cookingTime;
            Description = description;
            Ingredients = new HashSet<CookingMethodIngredient>();
            Steps = new HashSet<CookingStep>();
        }

        internal CookingMethod()
        {
        }

        public Guid RecipeId { get; private set; }

        public TimeSpan CookingTime { get; private set; }

        public DescriptionValueObject Description { get; private set; }

        public virtual Recipe Recipe { get; private set; }

        public virtual ICollection<CookingMethodIngredient> Ingredients { get; private set; }

        public virtual ICollection<CookingStep> Steps { get; private set; }
    }
}