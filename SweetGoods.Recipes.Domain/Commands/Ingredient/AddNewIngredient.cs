using SweetGoods.Recipes.Domain.Models.ValueObjects;

namespace SweetGoods.Recipes.Domain.Commands.Ingredient
{
    public class AddNewIngredient : IngredientBaseCommand
    {
        public AddNewIngredient(NameValueObject name, string details)
        {
            Name = name;
            Details = details;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}