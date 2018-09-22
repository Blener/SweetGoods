using GiftBagOfBases.Interfaces.Infra.Data;
using SweetGoods.Recipes.Domain.Models.Entities;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Interfaces.Queries
{
    public interface ICategoryQueryRepository : IQueryOnlyRepository<Category>
    {
        Task<bool> NameExist(string name);
    }
}