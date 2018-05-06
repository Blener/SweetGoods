using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Enums;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class Category : SoftDeleteEntity<Category>
    {
        internal Category()
        {
        }

        public Category(
            int incrementId,
            Guid id,
            NameValueObject name,
            DescriptionValueObject description,
            int categoryType,
            bool softDeleted) : this(incrementId, id, name, description, (CategoryType)categoryType, softDeleted)
        {
        }

        public Category(
            int id,
            Guid aggregateId,
            NameValueObject name,
            DescriptionValueObject description,
            CategoryType categoryType,
            bool softDeleted) : this(name, description, categoryType)
        {
            IncrementId = id;
            Id = aggregateId;
            SoftDeleted = softDeleted;
        }

        public Category(
            NameValueObject name,
            DescriptionValueObject description,
            CategoryType categoryType)
        {
            Name = name;
            Description = description;
            CategoryType = (int)categoryType;
        }

        public NameValueObject Name { get; private set; }

        public DescriptionValueObject Description { get; private set; }

        public int CategoryType { get; private set; }

        public override Category GetRestored()
        {
            return new Category(IncrementId, Id, Name, Description, CategoryType, NotDeleted);
        }
    }
}