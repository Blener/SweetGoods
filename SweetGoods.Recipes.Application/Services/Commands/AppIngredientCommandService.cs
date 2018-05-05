using SweetGoods.Recipes.Application.Interfaces.Commands;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Commands.Ingredient;
using System;
using SweetGoods.Recipes.Domain.Core.Bus;
using AutoMapper;

namespace SweetGoods.Recipes.Application.Services.Commands
{
    public class AppIngredientCommandService : AppCommandBaseService<IngredientViewModel>, IAppIngredientCommandService
    {
        public AppIngredientCommandService(IMediatorHandler bus, IMapper mapper) : base(bus, mapper)
        {
        }

        public override void Add(IngredientViewModel viewModel) => MapAndSendCommand<AddNewIngredient>(viewModel);

        public override void Remove(Guid aggregateId) => MapAndSendCommand<DeleteIngredient>(aggregateId);

        public override void Restore(Guid aggregateId) => MapAndSendCommand<RestoreDeletedIngredient>(aggregateId);

        public override void Update(IngredientViewModel viewModel) => MapAndSendCommand<UpdateIngredient>(viewModel);
    }
}