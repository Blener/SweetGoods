using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace SweetGoods.Recipes.Application.ViewModels
{
    public abstract class ViewModel
    {
        [Required]
        [JsonProperty("id")]
        public Guid AggregateId { get; set; }
    }
}