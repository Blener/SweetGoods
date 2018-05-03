namespace SweetGoods.Recipes.Domain.Core.Models
{
    public abstract class SoftDeleteEntity : Entity
    {
        public bool SoftDeleted { get; set; }

        public void RestoreDeleted()
        {
            SoftDeleted = false;
        }
    }
}