using SweetGoods.Recipes.Domain.Models.ValueObjects;

namespace SweetGoods.Recipes.Domain.Commands.Recipe
{
    public class AddNewRecipe : RecipeBaseCommand
    {
        public AddNewRecipe(NameValueObject name, DescriptionValueObject description)
        {
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}