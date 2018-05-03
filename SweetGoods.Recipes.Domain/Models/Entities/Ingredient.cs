using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class Ingredient : SoftDeleteEntity
    {
        public Ingredient(int id, Guid aggregateId, NameValueObject name, string details, bool softDeleted) : this(name, details)
        {
            Id = id;
            AggregateId = aggregateId;
            SoftDeleted = softDeleted;
        }

        public Ingredient(NameValueObject name, string details)
        {
            Name = name;
            Details = details;
        }

        internal Ingredient()
        {
        }

        public NameValueObject Name { get; }

        public string Details { get; }
    }
}