using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Core.Notifications;
using MediatR;
using SweetGoods.Recipes.Application.Interfaces.Commands;
using SweetGoods.Recipes.Application.Interfaces.Queries;

namespace SweetGoods.Recipes.WebApi.Controllers
{
    [Route("CookingMethod")]
    public class CookingMethodController : BaseMethodsController<CookingMethodViewModel>
    {
        protected CookingMethodController(
            INotificationHandler<DomainNotification> notifications,
            IAppBaseCommandService<CookingMethodViewModel> commandService,
            IAppBaseQueryService<CookingMethodViewModel> queryService) : base(notifications, commandService, queryService)
        {
        }
    }
}