using Newtonsoft.Json;
using System;

namespace SweetGoods.Recipes.Application.ViewModels
{
    public class RecipeCategoryViewModel : BaseViewModel
    {
        [JsonProperty("RecipeId")]
        public Guid RecipeAggregateId { get; set; }

        [JsonProperty("CategoryId")]
        public Guid CategoryAggregateId { get; set; }
    }
}