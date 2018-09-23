using AutoMapper;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Services.Application;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Commands.Ingredient;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using System;

namespace SweetGoods.Recipes.Application.Services
{
    public class AppIngredientService : AppFullService<IngredientViewModel, Ingredient>, IAppIngredientService
    {
        public AppIngredientService(IIngredientQueryRepository ingredientQueryRepository, IMediatorHandler bus, IMapper mapper) : base(ingredientQueryRepository, bus, mapper)
        {
        }

        public override void Add(IngredientViewModel viewModel) => MapAndSendCommand<AddNewIngredient>(viewModel);

        public override void Remove(Guid aggregateId) => MapAndSendCommand<DeleteIngredient>(aggregateId);

        public override void Restore(Guid aggregateId) => MapAndSendCommand<RestoreDeletedIngredient>(aggregateId);

        public override void Update(IngredientViewModel viewModel) => MapAndSendCommand<UpdateIngredient>(viewModel);
    }
}