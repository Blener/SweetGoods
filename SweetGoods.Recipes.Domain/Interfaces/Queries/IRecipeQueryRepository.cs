using SweetGoods.Recipes.Domain.Models.Entities;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Interfaces.Queries
{
    public interface IRecipeQueryRepository : IQueryRepository<Recipe>
    {
        Task<bool> NameExist(string name);
    }
}