using SweetGoods.Recipes.Domain.Models.Entities;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Interfaces.Queries
{
    public interface IIngredientQueryRepository : IQueryRepository<Ingredient>
    {
        Task<bool> NameExist(string name);
    }
}