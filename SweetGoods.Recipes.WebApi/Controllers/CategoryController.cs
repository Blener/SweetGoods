using GiftBagOfBases.Controllers;
using GiftBagOfBases.Interfaces.Application;
using GiftBagOfBases.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.Application.ViewModels;

namespace SweetGoods.Recipes.WebApi.Controllers
{
    [Route("Category/")]
    public class CategoryController : GiftFullController<CategoryViewModel>
    {
        public CategoryController(
            INotificationHandler<DomainNotification> notifications,
            IAppFullService<CategoryViewModel> appFullService) : base(notifications, appFullService)
        {
        }
    }
}