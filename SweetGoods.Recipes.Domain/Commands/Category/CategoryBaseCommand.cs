using GiftBagOfBases.Commands;
using SweetGoods.Recipes.Domain.Enums;
using SweetGoods.Recipes.Domain.Models.ValueObjects;

namespace SweetGoods.Recipes.Domain.Commands.Category
{
    public abstract class CategoryBaseCommand : Command
    {
        public NameValueObject Name { get; protected set; }

        public DescriptionValueObject Description { get; protected set; }

        public CategoryType CategoryType { get; protected set; }
    }
}