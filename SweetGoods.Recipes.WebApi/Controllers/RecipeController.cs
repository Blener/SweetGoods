using GiftBagOfBases.Controllers;
using GiftBagOfBases.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;

namespace SweetGoods.Recipes.WebApi.Controllers
{
    [Route("Recipe")]
    public class RecipeController : GiftFullController<RecipeViewModel>
    {
        private IAppRecipeService appRecipeService => appFullService as IAppRecipeService;

        public RecipeController(
            INotificationHandler<DomainNotification> notifications,
            IAppRecipeService appRecipeService) : base(notifications, appRecipeService)
        {
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(RecipeCategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(viewModel);
            }

            appRecipeService.AddCategory(viewModel);

            return Response(viewModel);
        }
    }
}