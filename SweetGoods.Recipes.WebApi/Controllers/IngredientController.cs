using GiftBagOfBases.Controllers;
using GiftBagOfBases.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;

namespace SweetGoods.Recipes.WebApi.Controllers
{
    [Route("Ingredient")]
    public class IngredientController : GiftFullController<IngredientViewModel>
    {
        public IngredientController(
            INotificationHandler<DomainNotification> notifications,
            IAppIngredientService appIngredientService) : base(notifications, appIngredientService)
        {
        }
    }
}