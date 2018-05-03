using SweetGoods.Recipes.Domain.Core.Commands;
using SweetGoods.Recipes.Domain.Models.ValueObjects;

namespace SweetGoods.Recipes.Domain.Commands.Ingredient
{
    public abstract class IngredientBaseCommand : Command
    {
        public NameValueObject Name { get; protected set; }

        public string Details { get; protected set; }
    }
}