using GiftBagOfBases.Interfaces.Infra.Data;
using SweetGoods.Recipes.Domain.Models.Entities;

namespace SweetGoods.Recipes.Domain.Interfaces.Queries
{
    public interface ICookingMethodQueryRepository : IQueryOnlyRepository<CookingMethod>
    {
    }
}