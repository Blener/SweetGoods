using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.Application.ViewModels;
using MediatR;
using SweetGoods.Recipes.Domain.Core.Notifications;
using SweetGoods.Recipes.Application.Interfaces.Commands;
using SweetGoods.Recipes.Application.Interfaces.Queries;

namespace SweetGoods.Recipes.WebApi.Controllers
{
    [Route("Recipe")]
    public class RecipeController : BaseMethodsController<RecipeViewModel>
    {
        protected RecipeController(
            INotificationHandler<DomainNotification> notifications,
            IAppBaseCommandService<RecipeViewModel> commandService,
            IAppBaseQueryService<RecipeViewModel> queryService) : base(notifications, commandService, queryService)
        {
        }
    }
}