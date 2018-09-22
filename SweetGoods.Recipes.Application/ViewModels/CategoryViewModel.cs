using GiftBagOfBases.ViewModel;
using SweetGoods.Recipes.Domain.Enums;
using SweetGoods.Recipes.Domain.Models.ValueObjects;

namespace SweetGoods.Recipes.Application.ViewModels
{
    public class CategoryViewModel : GiftViewModel
    {
        public NameValueObject Name { get; set; }

        public DescriptionValueObject Description { get; set; }

        public CategoryType CategoryType { get; set; }
    }
}