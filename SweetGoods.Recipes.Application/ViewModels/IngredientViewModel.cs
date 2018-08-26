using SweetGoods.Recipes.Domain.Models.ValueObjects;

namespace SweetGoods.Recipes.Application.ViewModels
{
    public class IngredientViewModel : BaseViewModel
    {
        public NameValueObject Name { get; set; }

        public string Details { get; set; }
    }
}