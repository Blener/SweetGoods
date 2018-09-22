using AutoMapper;
using GiftBagOfBases.Interfaces.Application;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Services.Application;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Commands.CookingMethod;
using System;

namespace SweetGoods.Recipes.Application.Services
{
    public class AppCookingMethodService : AppFullService<CookingMethodViewModel>, IAppCookingMethodService
    {
        public AppCookingMethodService(IMediatorHandler bus, IMapper mapper, IAppFullService<CookingMethodViewModel> appQueryOnlyService) : base(bus, mapper, appQueryOnlyService)
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