using GiftBagOfBases.Controllers;
using GiftBagOfBases.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;

namespace SweetGoods.Recipes.WebApi.Controllers
{
    [Route("CookingMethod")]
    public class CookingMethodController : GiftFullController<CookingMethodViewModel>
    {
        private IAppCookingMethodService AppCookingMethodService => appFullService as IAppCookingMethodService;

        public CookingMethodController(
            INotificationHandler<DomainNotification> notifications,
            IAppCookingMethodService appCookingMethodService) : base(notifications, appCookingMethodService)
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

            AppCookingMethodService.AddIngredient(viewModel);

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

            AppCookingMethodService.AddStep(viewModel);

            return Response(viewModel);
        }
    }
}