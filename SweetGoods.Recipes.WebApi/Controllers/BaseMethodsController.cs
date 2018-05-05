using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SweetGoods.Recipes.Application.Interfaces.Commands;
using SweetGoods.Recipes.Application.Interfaces.Queries;
using SweetGoods.Recipes.Application.Services.Commands;
using SweetGoods.Recipes.Application.Services.Queries;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Core.Notifications;

namespace SweetGoods.Recipes.WebApi.Controllers
{
    public abstract class BaseMethodsController<TViewModel> : BaseApiController where TViewModel : ViewModel
    {
        protected readonly IAppBaseCommandService<TViewModel> baseCommandService;
        protected readonly IAppBaseQueryService<TViewModel> baseQueryService;

        protected TService CommandService<TService>() where TService : IAppBaseCommandService<TViewModel> => (TService)baseCommandService;

        protected BaseMethodsController(
            INotificationHandler<DomainNotification> notifications,
            IAppBaseCommandService<TViewModel> baseCommandService,
            IAppBaseQueryService<TViewModel> baseQueryService) : base(notifications)
        {
            this.baseCommandService = baseCommandService;
            this.baseQueryService = baseQueryService;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            return Response(baseQueryService.GetAll());
        }

        [HttpGet("{id:required}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            return Response(await baseQueryService.GetByAggregateId(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] TViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(viewModel);
            }

            baseCommandService.Add(viewModel);
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

            baseCommandService.Update(viewModel);
            return Response(viewModel);
        }
    }
}