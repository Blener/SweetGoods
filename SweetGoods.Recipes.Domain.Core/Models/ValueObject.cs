using System.Collections.Generic;
using System.Linq;

namespace SweetGoods.Recipes.Domain.Core.Models
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;
            return !ReferenceEquals(valueObject, null);
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore()
                     .Select(x => x?.GetHashCode() ?? 0)
                     .Aggregate((x, y) => x ^ y);
        }

        protected abstract IEnumerable<object> GetHashCodeCore();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}