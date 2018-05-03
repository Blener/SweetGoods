using SweetGoods.Recipes.Domain.Core.Models;
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

        protected override IEnumerable<object> GetHashCodeCore()
        {
            yield return Name;
        }
    }
}