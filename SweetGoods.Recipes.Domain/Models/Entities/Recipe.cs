using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;
using System.Collections.Generic;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class Recipe : SoftDeleteEntity<Recipe>
    {
        internal Recipe()
        {
        }

        public Recipe(int id, Guid aggregateId, NameValueObject name, DescriptionValueObject description, bool softDeleted) : this(name, description)
        {
            Id = id;
            AggregateId = aggregateId;
            SoftDeleted = softDeleted;
        }

        public Recipe(
            NameValueObject name,
            DescriptionValueObject description,
            ICollection<RecipeCategory> recipeCategories,
            ICollection<CookingMethod> cookingMethods) : this(name, description)
        {
            RecipeCategories = recipeCategories;
            CookingMethods = cookingMethods;
        }

        public Recipe(NameValueObject name, DescriptionValueObject description)
        {
            Name = name;
            Description = description;
            RecipeCategories = new HashSet<RecipeCategory>();
            CookingMethods = new HashSet<CookingMethod>();
        }

        public NameValueObject Name { get; private set; }

        public DescriptionValueObject Description { get; private set; }

        public virtual ICollection<RecipeCategory> RecipeCategories { get; private set; }

        public virtual ICollection<CookingMethod> CookingMethods { get; private set; }

        public override Recipe GetRestored()
        {
            return new Recipe(Id, AggregateId, Name, Description, NotDeleted);
        }
    }
}