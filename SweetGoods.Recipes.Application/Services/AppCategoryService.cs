using AutoMapper;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Services.Application;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Commands.Category;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using System;

namespace SweetGoods.Recipes.Application.Services
{
    public class AppCategoryService : AppFullService<CategoryViewModel, Category>, IAppCategoryService
    {
        public AppCategoryService(ICategoryQueryRepository categoryQueryRepository, IMediatorHandler bus, IMapper mapper) : base(categoryQueryRepository, bus, mapper)
        {
        }

        public override void Add(CategoryViewModel viewModel) => MapAndSendCommand<AddNewCategory>(viewModel);

        public override void Remove(Guid aggregateId) => MapAndSendCommand<DeleteCategory>(aggregateId);

        public override void Restore(Guid aggregateId) => MapAndSendCommand<DeleteCategory>(aggregateId);

        public override void Update(CategoryViewModel viewModel) => MapAndSendCommand<UpdateCategory>(viewModel);
    }
}