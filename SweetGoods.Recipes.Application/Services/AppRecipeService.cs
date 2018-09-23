using AutoMapper;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Services.Application;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Commands.Recipe;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using System;

namespace SweetGoods.Recipes.Application.Services
{
    public class AppRecipeService : AppFullService<RecipeViewModel, Recipe>, IAppRecipeService
    {
        public AppRecipeService(IRecipeQueryRepository recipeQueryRepository, IMediatorHandler bus, IMapper mapper) : base(recipeQueryRepository, bus, mapper)
        {
        }

        public override void Add(RecipeViewModel viewModel) => MapAndSendCommand<AddNewRecipe>(viewModel);

        public void AddCategory(RecipeCategoryViewModel viewModel) => MapAndSendCommand<AddCategory, RecipeCategoryViewModel>(viewModel);

        public override void Remove(Guid aggregateId) => MapAndSendCommand<DeleteRecipe>(aggregateId);

        public override void Restore(Guid aggregateId) => MapAndSendCommand<RestoreDeletedRecipe>(aggregateId);

        public override void Update(RecipeViewModel viewModel) => MapAndSendCommand<UpdateRecipe>(viewModel);
    }
}