using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.Application.ViewModels;
using MediatR;
using SweetGoods.Recipes.Domain.Core.Notifications;
using SweetGoods.Recipes.Application.Interfaces.Commands;
using SweetGoods.Recipes.Application.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Core.Commands;

namespace SweetGoods.Recipes.WebApi.Controllers
{
    [Route("Recipe")]
    public class RecipeController : BaseMethodsController<RecipeViewModel>
    {
        private IAppRecipeCommandService recipeCommandService => commandService as IAppRecipeCommandService;

        protected RecipeController(
            INotificationHandler<DomainNotification> notifications,
            IAppBaseCommandService<RecipeViewModel> commandService,
            IAppBaseQueryService<RecipeViewModel> queryService) : base(notifications, commandService, queryService)
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

            recipeCommandService.AddCategory(viewModel);

            return Response(viewModel);
        }
    }
}