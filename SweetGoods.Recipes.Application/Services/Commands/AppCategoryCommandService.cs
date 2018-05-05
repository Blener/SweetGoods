using SweetGoods.Recipes.Application.Interfaces.Commands;
using SweetGoods.Recipes.Application.ViewModels;
using System;
using SweetGoods.Recipes.Domain.Core.Bus;
using AutoMapper;
using SweetGoods.Recipes.Domain.Commands.Category;

namespace SweetGoods.Recipes.Application.Services.Commands
{
    public class AppCategoryCommandService : AppCommandBaseService<CategoryViewModel>, IAppCategoryCommandService
    {
        public AppCategoryCommandService(IMediatorHandler bus, IMapper mapper) : base(bus, mapper)
        {
        }

        public override void Add(CategoryViewModel viewModel) => MapAndSendCommand<AddNewCategory>(viewModel);

        public override void Remove(Guid aggregateId) => MapAndSendCommand<DeleteCategory>(aggregateId);

        public override void Restore(Guid aggregateId) => MapAndSendCommand<DeleteCategory>(aggregateId);

        public override void Update(CategoryViewModel viewModel) => MapAndSendCommand<UpdateCategory>(viewModel);
    }
}