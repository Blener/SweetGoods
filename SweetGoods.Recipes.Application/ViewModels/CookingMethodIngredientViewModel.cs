using Newtonsoft.Json;
using SweetGoods.Recipes.Domain.Enums;
using System;

namespace SweetGoods.Recipes.Application.ViewModels
{
    public class CookingMethodIngredientViewModel : ViewModel
    {
        [JsonProperty("CookingMethodId")]
        public Guid CookingMethodAggregateId { get; set; }

        [JsonProperty("IngredientId")]
        public Guid IngredientAggregateId { get; set; }

        public MeasureType MeasureType { get; set; }

        public decimal Measure { get; set; }

        public string Usage { get; set; }
    }
}