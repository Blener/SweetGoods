using GiftBagOfBases.ViewModel;
using Newtonsoft.Json;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;
using System.Collections.Generic;

namespace SweetGoods.Recipes.Application.ViewModels
{
    public class CookingMethodViewModel : GiftViewModel
    {
        [JsonProperty("RecipeId")]
        public Guid RecipeAggregateId { get; set; }

        public TimeSpan CookingTime { get; set; }

        public DescriptionValueObject Description { get; set; }

        public ICollection<CookingMethodIngredientViewModel> Ingredients { get; set; }

        public ICollection<CookingStepViewModel> Steps { get; set; }
    }
}