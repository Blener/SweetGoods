using SweetGoods.Recipes.Application.Interfaces.Commands;
using SweetGoods.Recipes.Application.ViewModels;
using System;
using SweetGoods.Recipes.Domain.Core.Bus;
using AutoMapper;
using SweetGoods.Recipes.Domain.Commands.CookingMethod;

namespace SweetGoods.Recipes.Application.Services.Commands
{
    public class AppCookingMethodCommandService : AppCommandBaseService<CookingMethodViewModel>, IAppCookingMethodCommandService
    {
        public AppCookingMethodCommandService(IMediatorHandler bus, IMapper mapper) : base(bus, mapper)
        {
        }

        public override void Add(CookingMethodViewModel viewModel) => MapAndSendCommand<AddNewCookingMethod>(viewModel);

        public void AddIngredient(CookingMethodIngredientViewModel viewModel) => MapAndSendCommand<AddIngredient, CookingMethodIngredientViewModel>(viewModel);

        public void AddStep(CookingStepViewModel viewModel) => MapAndSendCommand<AddStep, CookingStepViewModel>(viewModel);

        public override void Remove(Guid aggregateId) => MapAndSendCommand<DeleteCookingMethod>(aggregateId);

        public override void Restore(Guid aggregateId) => MapAndSendCommand<RestoreDeletedCookingMethod>(aggregateId);

        public override void Update(CookingMethodViewModel viewModel) => MapAndSendCommand<UpdateCookingMethod>(viewModel);
    }
}