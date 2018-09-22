using AutoMapper;
using GiftBagOfBases.Interfaces.Application;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Services.Application;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Commands.Ingredient;
using System;

namespace SweetGoods.Recipes.Application.Services
{
    public class AppIngredientService : AppFullService<IngredientViewModel>, IAppIngredientService
    {
        public AppIngredientService(IMediatorHandler bus, IMapper mapper, IAppQueryOnlyService<IngredientViewModel> appQueryOnlyService) : base(bus, mapper, appQueryOnlyService)
        {
        }

        public override void Add(IngredientViewModel viewModel) => MapAndSendCommand<AddNewIngredient>(viewModel);

        public override void Remove(Guid aggregateId) => MapAndSendCommand<DeleteIngredient>(aggregateId);

        public override void Restore(Guid aggregateId) => MapAndSendCommand<RestoreDeletedIngredient>(aggregateId);

        public override void Update(IngredientViewModel viewModel) => MapAndSendCommand<UpdateIngredient>(viewModel);
    }
}