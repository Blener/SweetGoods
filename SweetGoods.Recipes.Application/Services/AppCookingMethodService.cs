using AutoMapper;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Services.Application;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Commands.CookingMethod;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using System;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Application.Services
{
    public class AppCookingMethodService : AppFullService<CookingMethodViewModel, CookingMethod>, IAppCookingMethodService
    {
        public AppCookingMethodService(ICookingMethodQueryRepository cookingMethodQueryRepository, IMediatorHandler bus, IMapper mapper) : base(cookingMethodQueryRepository, bus, mapper)
        {
        }

        public async override Task Add(CookingMethodViewModel viewModel) => await MapAndSendCommand<AddNewCookingMethod>(viewModel);

        public async Task AddIngredient(CookingMethodIngredientViewModel viewModel) => await MapAndSendCommand<AddIngredient, CookingMethodIngredientViewModel>(viewModel);

        public async Task AddStep(CookingStepViewModel viewModel) => await MapAndSendCommand<AddStep, CookingStepViewModel>(viewModel);

        public override async Task Remove(Guid aggregateId) => await MapAndSendCommand<DeleteCookingMethod>(aggregateId);

        public override async Task Restore(Guid aggregateId) => await MapAndSendCommand<RestoreDeletedCookingMethod>(aggregateId);

        public override async Task Update(CookingMethodViewModel viewModel) => await MapAndSendCommand<UpdateCookingMethod>(viewModel);
    }
}