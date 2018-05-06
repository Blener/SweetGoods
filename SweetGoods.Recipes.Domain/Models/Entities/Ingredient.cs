using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class Ingredient : SoftDeleteEntity<Ingredient>
    {
        public Ingredient(int incrementId, Guid id, NameValueObject name, string details, bool softDeleted) : this(name, details)
        {
            IncrementId = incrementId;
            Id = id;
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

        public NameValueObject Name { get; private set; }

        public string Details { get; private set; }

        public override Ingredient GetRestored()
        {
            return new Ingredient(IncrementId, Id, Name, Details, NotDeleted);
        }
    }
}