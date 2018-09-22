using GiftBagOfBases.ViewModel;
using SweetGoods.Recipes.Domain.Models.ValueObjects;

namespace SweetGoods.Recipes.Application.ViewModels
{
    public class IngredientViewModel : GiftViewModel
    {
        public NameValueObject Name { get; set; }

        public string Details { get; set; }
    }
}