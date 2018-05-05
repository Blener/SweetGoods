using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.Application.Interfaces.Commands;
using SweetGoods.Recipes.Application.Interfaces.Queries;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Core.Notifications;

namespace SweetGoods.Recipes.WebApi.Controllers
{
    public abstract class BaseMethodsController<TViewModel> : BaseApiController where TViewModel : ViewModel
    {
        protected readonly IAppBaseCommandService<TViewModel> commandService;
        protected readonly IAppBaseQueryService<TViewModel> queryService;

        protected BaseMethodsController(
            INotificationHandler<DomainNotification> notifications,
            IAppBaseCommandService<TViewModel> commandService,
            IAppBaseQueryService<TViewModel> queryService) : base(notifications)
        {
            this.commandService = commandService;
            this.queryService = queryService;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            return Response(queryService.GetAll());
        }

        [HttpGet("{id:required}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            return Response(await queryService.GetByAggregateId(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] TViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(viewModel);
            }

            commandService.Add(viewModel);
            return Response(viewModel);
        }

        [HttpPut]
        public IActionResult Update([FromBody]TViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(viewModel);
            }

            commandService.Update(viewModel);
            return Response(viewModel);
        }
    }
}