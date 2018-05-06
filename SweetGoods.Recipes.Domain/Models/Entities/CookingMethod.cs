using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
            DescriptionValueObject description,
            Recipe recipe,
            ICollection<CookingMethodIngredient> ingredients,
            ICollection<CookingStep> steps) : this(recipeId, cookingTime, description)
        {
            Recipe = recipe;
            Ingredients = ingredients;
            Steps = steps;
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

        public override CookingMethod GetRestored()
        {
            return new CookingMethod(IncrementId, Id, RecipeId, CookingTime, Description, NotDeleted);
        }
    }
}