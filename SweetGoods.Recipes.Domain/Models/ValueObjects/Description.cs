using SweetGoods.Recipes.Domain.Core.Models;
using System.Collections.Generic;

namespace SweetGoods.Recipes.Domain.Models.ValueObjects
{
    public class DescriptionValueObject : ValueObject<DescriptionValueObject>
    {
        public DescriptionValueObject(string description)
        {
            Description = description;
        }

        internal DescriptionValueObject()
        {
        }

        public string Description { get; protected set; }

        protected override IEnumerable<object> GetHashCodeCore()
        {
            yield return Description;
        }
    }
}