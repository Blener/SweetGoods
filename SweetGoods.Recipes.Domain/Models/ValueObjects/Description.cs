using GiftBagOfBases.Models;
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

        protected override IEnumerable<int> GetHashCodeCore()
        {
            yield return Description.GetHashCode();
        }

        public static implicit operator string(DescriptionValueObject descriptionValueObject) => descriptionValueObject.Description;

        public static implicit operator DescriptionValueObject(string description) => new DescriptionValueObject(description);
    }
}