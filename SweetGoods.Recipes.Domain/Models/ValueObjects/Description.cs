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
            foreach (char c in Description)
            {
                yield return c * 87;
            }
        }
    }
}