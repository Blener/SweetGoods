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

        [HttpPost("AddIngredient")]
        public IActionResult AddIngredient([FromBody]CookingMethodIngredientViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(viewModel);
            }

            CommandService<IAppCookingMethodCommandService>().AddIngredient(viewModel);

            return Response(viewModel);
        }

        [HttpPost("AddStep")]
        public IActionResult AddStep([FromBody]CookingStepViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(viewModel);
            }

            CommandService<IAppCookingMethodCommandService>().AddStep(viewModel);

            return Response(viewModel);
        }
    }
}