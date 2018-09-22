using GiftBagOfBases.Interfaces.Infra.Data;
using SweetGoods.Recipes.Domain.Models.Entities;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Interfaces.Queries
{
    public interface IRecipeQueryRepository : IQueryOnlyRepository<Recipe>
    {
        Task<bool> NameExist(string name);
    }
}