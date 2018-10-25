using AutoMapper;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Services.Application;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Commands.Ingredient;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using System;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Application.Services
{
    public class AppIngredientService : AppFullService<IngredientViewModel, Ingredient>, IAppIngredientService
    {
        public AppIngredientService(IIngredientQueryRepository ingredientQueryRepository, IMediatorHandler bus, IMapper mapper) : base(ingredientQueryRepository, bus, mapper)
        {
        }

        public override async Task Add(IngredientViewModel viewModel) => await MapAndSendCommand<AddNewIngredient>(viewModel);

        public override async Task Remove(Guid aggregateId) => await MapAndSendCommand<DeleteIngredient>(aggregateId);

        public override async Task Restore(Guid aggregateId) => await MapAndSendCommand<RestoreDeletedIngredient>(aggregateId);

        public override async Task Update(IngredientViewModel viewModel) => await MapAndSendCommand<UpdateIngredient>(viewModel);
    }
}