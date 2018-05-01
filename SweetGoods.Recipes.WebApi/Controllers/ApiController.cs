using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SweetGoods.Recipes.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace SweetGoods.Recipes.WebApi.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;

        protected ApiController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected bool IsValidOperation()
        {
            return !_notifications.HasErrors();
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    messages = _notifications.GetConfirmations().Select(x => x.Value),
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                messages = _notifications.GetConfirmations().Select(x => x.Value),
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected void NotifyModelStateErrors()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(string.Empty, errorMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            _notifications.Handle(new DomainNotification(code, message, false));
        }
    }
}