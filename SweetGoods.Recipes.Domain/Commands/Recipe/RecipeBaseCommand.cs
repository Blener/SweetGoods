using SweetGoods.Recipes.Domain.Core.Commands;
using SweetGoods.Recipes.Domain.Models.ValueObjects;

namespace SweetGoods.Recipes.Domain.Commands.Recipe
{
    public abstract class RecipeBaseCommand : Command
    {
        public NameValueObject Name { get; protected set; }

        public DescriptionValueObject Description { get; protected set; }
    }
}