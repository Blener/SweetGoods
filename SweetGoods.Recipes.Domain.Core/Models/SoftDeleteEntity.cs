namespace SweetGoods.Recipes.Domain.Core.Models
{
    public abstract class SoftDeleteEntity<T> : Entity where T : Entity
    {
        public bool SoftDeleted { get; set; }

        protected bool Deleted => true;

        protected bool NotDeleted => false;

        public abstract T GetRestored();
    }
}