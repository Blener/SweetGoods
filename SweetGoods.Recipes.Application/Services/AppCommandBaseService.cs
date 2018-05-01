using AutoMapper;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Core.Bus;
using SweetGoods.Recipes.Domain.Core.Commands;
using SweetGoods.Recipes.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetGoods.Recipes.Application.Services
{
    public abstract class AppCommandBaseService<TViewModel> : IAppCommandBaseService<TViewModel> where TViewModel : ViewModel
    {
        private readonly IMediatorHandler bus;
        private readonly IMapper mapper;

        public AppCommandBaseService(IMediatorHandler bus, IMapper mapper)
        {
            this.bus = bus;
            this.mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        protected void MapAndSendCommand<TCommand>(TViewModel viewModel) where TCommand : Command => bus.SendCommand(mapper.Map<TCommand>(viewModel));

        protected void MapAndSendCommand<TCommand>(Guid aggregateId) where TCommand : Command => bus.SendCommand(mapper.Map<TCommand>(aggregateId));
    }
}