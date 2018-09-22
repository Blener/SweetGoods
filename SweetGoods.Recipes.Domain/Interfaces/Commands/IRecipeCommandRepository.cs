using GiftBagOfBases.Interfaces.Infra.Data;
using SweetGoods.Recipes.Domain.Models.Entities;

namespace SweetGoods.Recipes.Domain.Interfaces.Commands
{
    public interface IRecipeCommandRepository : ICommandOnlyRepository<Recipe>
    {
    }
}