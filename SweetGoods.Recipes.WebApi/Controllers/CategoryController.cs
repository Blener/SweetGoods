using GiftBagOfBases.Controllers;
using GiftBagOfBases.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.ViewModels;

namespace SweetGoods.Recipes.WebApi.Controllers
{
    [Route("Category/")]
    public class CategoryController : GiftFullController<CategoryViewModel>
    {
        public CategoryController(
            INotificationHandler<DomainNotification> notifications,
            IAppCategoryService appFullService) : base(notifications, appFullService)
        {
        }
    }
}