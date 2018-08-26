using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System.Collections.Generic;

namespace SweetGoods.Recipes.Application.ViewModels
{
    public class RecipeViewModel : BaseViewModel
    {
        public NameValueObject Name { get; set; }

        public DescriptionValueObject Description { get; set; }

        public ICollection<RecipeCategoryViewModel> Categories { get; set; }

        public ICollection<CookingMethodViewModel> CookingMethods { get; set; }
    }
}