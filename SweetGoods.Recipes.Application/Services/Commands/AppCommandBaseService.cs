using AutoMapper;
using SweetGoods.Recipes.Application.Interfaces.Commands;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Core.Bus;
using SweetGoods.Recipes.Domain.Core.Commands;
using System;

namespace SweetGoods.Recipes.Application.Services.Commands
{
    public abstract class AppCommandBaseService<TViewModel> : IAppBaseCommandService<TViewModel> where TViewModel : ViewModel
    {
        private readonly IMediatorHandler bus;
        private readonly IMapper mapper;

        public AppCommandBaseService(IMediatorHandler bus, IMapper mapper)
        {
            this.bus = bus;
            this.mapper = mapper;
        }

        public abstract void Add(TViewModel viewModel);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public abstract void Remove(Guid aggregateId);

        public abstract void Restore(Guid aggregateId);

        public abstract void Update(TViewModel viewModel);

        protected void MapAndSendCommand<TCommand>(TViewModel viewModel) where TCommand : Command => bus.SendCommand(mapper.Map<TCommand>(viewModel));

        protected void MapAndSendCommand<TCommand>(Guid aggregateId) where TCommand : Command => bus.SendCommand(mapper.Map<TCommand>(aggregateId));

        protected void MapAndSendCommand<TCommand, TMethodViewModel>(TMethodViewModel viewModel)
            where TCommand : Command where TMethodViewModel : ViewModel
            => bus.SendCommand(mapper.Map<TCommand>(viewModel));
    }
}