using AutoMapper;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Services.Application;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Commands.CookingMethod;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using System;

namespace SweetGoods.Recipes.Application.Services
{
    public class AppCookingMethodService : AppFullService<CookingMethodViewModel, CookingMethod>, IAppCookingMethodService
    {
        public AppCookingMethodService(ICookingMethodQueryRepository cookingMethodQueryRepository, IMediatorHandler bus, IMapper mapper) : base(cookingMethodQueryRepository, bus, mapper)
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