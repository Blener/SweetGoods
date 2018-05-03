using SweetGoods.Recipes.Domain.Enums;
using SweetGoods.Recipes.Domain.Models.ValueObjects;

namespace SweetGoods.Recipes.Domain.Commands.Category
{
    public class AddNewCategory : CategoryBaseCommand
    {
        protected AddNewCategory(NameValueObject name, DescriptionValueObject description, CategoryType categoryType)
        {
            Name = name;
            Description = description;
            CategoryType = categoryType;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}