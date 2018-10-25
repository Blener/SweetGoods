using AutoMapper;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Services.Application;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Commands.Recipe;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using System;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Application.Services
{
    public class AppRecipeService : AppFullService<RecipeViewModel, Recipe>, IAppRecipeService
    {
        public AppRecipeService(IRecipeQueryRepository recipeQueryRepository, IMediatorHandler bus, IMapper mapper) : base(recipeQueryRepository, bus, mapper)
        {
        }

        public override async Task Add(RecipeViewModel viewModel) => await MapAndSendCommand<AddNewRecipe>(viewModel);

        public async Task AddCategory(RecipeCategoryViewModel viewModel) => await MapAndSendCommand<AddCategory, RecipeCategoryViewModel>(viewModel);

        public override async Task Remove(Guid aggregateId) => await MapAndSendCommand<DeleteRecipe>(aggregateId);

        public override async Task Restore(Guid aggregateId) => await MapAndSendCommand<RestoreDeletedRecipe>(aggregateId);

        public override async Task Update(RecipeViewModel viewModel) => await MapAndSendCommand<UpdateRecipe>(viewModel);
    }
}