using Newtonsoft.Json;
using System;

namespace SweetGoods.Recipes.Application.ViewModels
{
    public class CookingStepsViewModel : ViewModel
    {
        [JsonProperty("CookingMethodId")]
        public Guid CookingMethodAggregateId { get; set; }

        public int StepNumber { get; set; }

        public string StepAction { get; set; }
    }
}