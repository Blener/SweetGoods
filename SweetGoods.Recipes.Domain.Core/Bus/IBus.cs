using SweetGoods.Recipes.Domain.Core.Commands;
using SweetGoods.Recipes.Domain.Core.Events;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;

        Task RaiseEvent<T>(T @event) where T : Event;
    }
}