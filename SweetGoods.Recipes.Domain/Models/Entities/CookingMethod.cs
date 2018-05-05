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
            int id,
            Guid aggregateId,
            Guid recipeAggregateId,
            TimeSpan cookingTime,
            DescriptionValueObject description,
            bool softDeleted) : this(recipeAggregateId, cookingTime, description)
        {
            Id = id;
            AggregateId = aggregateId;
            SoftDeleted = softDeleted;
        }

        public CookingMethod(
            Guid recipeAggregateId,
            TimeSpan cookingTime,
            DescriptionValueObject description,
            Recipe recipe,
            ICollection<CookingMethodIngredient> ingredients,
            ICollection<CookingStep> steps) : this(recipeAggregateId, cookingTime, description)
        {
            Recipe = recipe;
            Ingredients = ingredients;
            Steps = steps;
        }

        public CookingMethod(
            Guid recipeAggregateId,
            TimeSpan cookingTime,
            DescriptionValueObject description)
        {
            RecipeAggregateId = recipeAggregateId;
            CookingTime = cookingTime;
            Description = description;
            Ingredients = new HashSet<CookingMethodIngredient>();
            Steps = new HashSet<CookingStep>();
        }

        internal CookingMethod()
        {
        }

        public Guid RecipeAggregateId { get; private set; }

        public TimeSpan CookingTime { get; private set; }

        public DescriptionValueObject Description { get; private set; }

        [ForeignKey(nameof(RecipeAggregateId))]
        public virtual Recipe Recipe { get; private set; }

        public virtual ICollection<CookingMethodIngredient> Ingredients { get; private set; }

        public virtual ICollection<CookingStep> Steps { get; private set; }

        public override CookingMethod GetRestored()
        {
            return new CookingMethod(Id, AggregateId, RecipeAggregateId, CookingTime, Description, NotDeleted);
        }
    }
}