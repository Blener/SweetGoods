using SweetGoods.Recipes.Domain.Models.Entities;

namespace SweetGoods.Recipes.Domain.Interfaces.Commands
{
    public interface ICategoryCommandRepository : ICommandRepository<Category>
    {
    }
}