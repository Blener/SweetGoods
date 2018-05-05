using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Core.Notifications;
using MediatR;
using SweetGoods.Recipes.Application.Interfaces.Commands;
using SweetGoods.Recipes.Application.Interfaces.Queries;

namespace SweetGoods.Recipes.WebApi.Controllers
{
    [Route("Ingredient")]
    public class IngredientController : BaseMethodsController<IngredientViewModel>
    {
        protected IngredientController(
            INotificationHandler<DomainNotification> notifications,
            IAppBaseCommandService<IngredientViewModel> commandService,
            IAppBaseQueryService<IngredientViewModel> queryService) : base(notifications, commandService, queryService)
        {
        }
    }
}