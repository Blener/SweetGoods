using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SweetGoods.Recipes.Domain.Core.Bus;
using SweetGoods.Recipes.Domain.Core.Events;
using SweetGoods.Recipes.Domain.Core.Notifications;
using SweetGoods.Recipes.Domain.Interfaces;
using SweetGoods.Recipes.Infra.CrossCutting.Bus;
using SweetGoods.Recipes.Infra.Data.Context;
using SweetGoods.Recipes.Infra.Data.EventSourcing;
using SweetGoods.Recipes.Infra.Data.Repositories.EventSourcing;
using SweetGoods.Recipes.Infra.Data.UoW;

namespace SweetGoods.Recipes.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootstraper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

        public static void RegisterInfraServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<SweetGoodsRecipesContext>();
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();
        }
    }
}