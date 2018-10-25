using AutoMapper;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Services.Application;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Commands.Category;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using System;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Application.Services
{
    public class AppCategoryService : AppFullService<CategoryViewModel, Category>, IAppCategoryService
    {
        public AppCategoryService(ICategoryQueryRepository categoryQueryRepository, IMediatorHandler bus, IMapper mapper) : base(categoryQueryRepository, bus, mapper)
        {
        }

        public override async Task Add(CategoryViewModel viewModel) => await MapAndSendCommand<AddNewCategory>(viewModel);

        public override Task Remove(Guid aggregateId) => MapAndSendCommand<DeleteCategory>(aggregateId);

        public override Task Restore(Guid aggregateId) => MapAndSendCommand<DeleteCategory>(aggregateId);

        public override Task Update(CategoryViewModel viewModel) => MapAndSendCommand<UpdateCategory>(viewModel);
    }
}