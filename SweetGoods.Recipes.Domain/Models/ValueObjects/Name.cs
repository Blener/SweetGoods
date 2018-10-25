using GiftBagOfBases.Models;
using Newtonsoft.Json;
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
            yield return Name.GetHashCode();
        }

        public static implicit operator string(NameValueObject nameValueObject) => nameValueObject.Name;

        public static implicit operator NameValueObject(string name) => new NameValueObject(name);
    }
}