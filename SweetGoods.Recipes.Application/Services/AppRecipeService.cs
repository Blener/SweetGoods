using AutoMapper;
using GiftBagOfBases.Interfaces.Application;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Services.Application;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Commands.Recipe;
using System;

namespace SweetGoods.Recipes.Application.Services
{
    public class AppRecipeService : AppFullService<RecipeViewModel>, IAppRecipeService
    {
        public AppRecipeService(IMediatorHandler bus, IMapper mapper, IAppQueryOnlyService<RecipeViewModel> appQueryOnlyService) : base(bus, mapper, appQueryOnlyService)
        {
        }

        public override void Add(RecipeViewModel viewModel) => MapAndSendCommand<AddNewRecipe>(viewModel);

        public void AddCategory(RecipeCategoryViewModel viewModel) => MapAndSendCommand<AddCategory, RecipeCategoryViewModel>(viewModel);

        public override void Remove(Guid aggregateId) => MapAndSendCommand<DeleteRecipe>(aggregateId);

        public override void Restore(Guid aggregateId) => MapAndSendCommand<RestoreDeletedRecipe>(aggregateId);

        public override void Update(RecipeViewModel viewModel) => MapAndSendCommand<UpdateRecipe>(viewModel);
    }
}