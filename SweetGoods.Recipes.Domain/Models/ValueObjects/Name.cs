using GiftBagOfBases.Models;
using System.Collections.Generic;

namespace SweetGoods.Recipes.Domain.Models.ValueObjects
{
    public class NameValueObject : ValueObject<NameValueObject>
    {
        protected NameValueObject(string name)
        {
            Name = name;
        }

        internal NameValueObject()
        {
        }

        public string Name { get; protected set; }

        protected override IEnumerable<int> GetHashCodeCore()
        {
            foreach (char c in Name)
            {
                yield return c * 23;
            }
        }
    }
}