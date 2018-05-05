using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.Application.ViewModels;
using MediatR;
using SweetGoods.Recipes.Domain.Core.Notifications;
using SweetGoods.Recipes.Application.Interfaces.Commands;
using SweetGoods.Recipes.Application.Interfaces.Queries;

namespace SweetGoods.Recipes.WebApi.Controllers
{
    [Route("Category/")]
    public class CategoryController : BaseMethodsController<CategoryViewModel>
    {
        protected CategoryController(
            INotificationHandler<DomainNotification> notifications,
            IAppBaseCommandService<CategoryViewModel> commandService,
            IAppBaseQueryService<CategoryViewModel> queryService) : base(notifications, commandService, queryService)
        {
        }
    }
}