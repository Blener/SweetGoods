using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SweetGoods.Recipes.Application.Interfaces.Commands;
using SweetGoods.Recipes.Application.Interfaces.Queries;
using SweetGoods.Recipes.Application.Services.Commands;
using SweetGoods.Recipes.Application.Services.Queries;
using SweetGoods.Recipes.Domain.Commands.Category;
using SweetGoods.Recipes.Domain.Commands.CookingMethod;
using SweetGoods.Recipes.Domain.Commands.Ingredient;
using SweetGoods.Recipes.Domain.Commands.Recipe;
using SweetGoods.Recipes.Domain.Core.Bus;
using SweetGoods.Recipes.Domain.Core.Events;
using SweetGoods.Recipes.Domain.Core.Notifications;
using SweetGoods.Recipes.Domain.Events.Category;
using SweetGoods.Recipes.Domain.Events.CookingMethod;
using SweetGoods.Recipes.Domain.Events.Ingredient;
using SweetGoods.Recipes.Domain.Events.Recipe;
using SweetGoods.Recipes.Domain.Handlers.CommandHandlers;
using SweetGoods.Recipes.Domain.Handlers.EventHandlers;
using SweetGoods.Recipes.Domain.Interfaces;
using SweetGoods.Recipes.Domain.Interfaces.Commands;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Infra.CrossCutting.Bus;
using SweetGoods.Recipes.Infra.Data.Context;
using SweetGoods.Recipes.Infra.Data.EventSourcing;
using SweetGoods.Recipes.Infra.Data.Repositories.Commands;
using SweetGoods.Recipes.Infra.Data.Repositories.EventSourcing;
using SweetGoods.Recipes.Infra.Data.Repositories.Queries;
using SweetGoods.Recipes.Infra.Data.UoW;

namespace SweetGoods.Recipes.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootstraper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            RegisterApplicationServices(services);
            RegisterDomainCommands(services);
            RegisterDomainServices(services);
            RegisterDomainEvents(services);
            RegisterInfraServices(services);
            RegisterInfraRepositories(services);
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            //Commands
            services.AddScoped<IAppCategoryCommandService, AppCategoryCommandService>();
            services.AddScoped<IAppCookingMethodCommandService, AppCookingMethodCommandService>();
            services.AddScoped<IAppIngredientCommandService, AppIngredientCommandService>();
            services.AddScoped<IAppRecipeCommandService, AppRecipeCommandService>();

            //Queries
            services.AddScoped<IAppCategoryQueryService, AppCategoryQueryService>();
            services.AddScoped<IAppCookingMethodQueryService, AppCookingMethodQueryService>();
            services.AddScoped<IAppIngredientQueryService, AppIngredientQueryService>();
            services.AddScoped<IAppRecipeQueryService, AppRecipeQueryService>();
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

        private static void RegisterDomainCommands(IServiceCollection services)
        {
            //Category
            services.AddScoped<IAsyncNotificationHandler<AddNewCategory>, CategoryCommandHandler>();
            services.AddScoped<IAsyncNotificationHandler<DeleteCategory>, CategoryCommandHandler>();
            services.AddScoped<IAsyncNotificationHandler<RestoreDeletedCategory>, CategoryCommandHandler>();
            services.AddScoped<IAsyncNotificationHandler<UpdateCategory>, CategoryCommandHandler>();

            //CookingMethod
            services.AddScoped<IAsyncNotificationHandler<AddNewCookingMethod>, CookingMethodCommandHandler>();
            services.AddScoped<IAsyncNotificationHandler<DeleteCookingMethod>, CookingMethodCommandHandler>();
            services.AddScoped<IAsyncNotificationHandler<RestoreDeletedCookingMethod>, CookingMethodCommandHandler>();
            services.AddScoped<IAsyncNotificationHandler<UpdateCookingMethod>, CookingMethodCommandHandler>();

            //Ingredient
            services.AddScoped<IAsyncNotificationHandler<AddNewIngredient>, IngredientCommandHandler>();
            services.AddScoped<IAsyncNotificationHandler<DeleteIngredient>, IngredientCommandHandler>();
            services.AddScoped<IAsyncNotificationHandler<RestoreDeletedIngredient>, IngredientCommandHandler>();
            services.AddScoped<IAsyncNotificationHandler<UpdateIngredient>, IngredientCommandHandler>();

            //Recipe
            services.AddScoped<IAsyncNotificationHandler<AddNewRecipe>, RecipeCommandHandler>();
            services.AddScoped<IAsyncNotificationHandler<DeleteRecipe>, RecipeCommandHandler>();
            services.AddScoped<IAsyncNotificationHandler<RestoreDeletedRecipe>, RecipeCommandHandler>();
            services.AddScoped<IAsyncNotificationHandler<UpdateRecipe>, RecipeCommandHandler>();
            services.AddScoped<IAsyncNotificationHandler<AddCategory>, RecipeCommandHandler>();
        }

        private static void RegisterDomainEvents(IServiceCollection services)
        {
            //Category
            services.AddScoped<IAsyncNotificationHandler<NewCategoryAdded>, CategoryEventHandler>();
            services.AddScoped<IAsyncNotificationHandler<CategoryDeleted>, CategoryEventHandler>();
            services.AddScoped<IAsyncNotificationHandler<DeletedCategoryRestored>, CategoryEventHandler>();
            services.AddScoped<IAsyncNotificationHandler<CategoryUpdated>, CategoryEventHandler>();

            //CookingMethod
            services.AddScoped<IAsyncNotificationHandler<NewCookingMethodAdded>, CookingMethodEventHandler>();
            services.AddScoped<IAsyncNotificationHandler<CookingMethodDeleted>, CookingMethodEventHandler>();
            services.AddScoped<IAsyncNotificationHandler<DeletedCookingMethodRestored>, CookingMethodEventHandler>();
            services.AddScoped<IAsyncNotificationHandler<CookingMethodUpdated>, CookingMethodEventHandler>();

            //Ingredient
            services.AddScoped<IAsyncNotificationHandler<NewIngredientAdded>, IngredientEventHandler>();
            services.AddScoped<IAsyncNotificationHandler<IngredientDeleted>, IngredientEventHandler>();
            services.AddScoped<IAsyncNotificationHandler<DeletedIngredientRestored>, IngredientEventHandler>();
            services.AddScoped<IAsyncNotificationHandler<IngredientUpdated>, IngredientEventHandler>();

            //Recipe
            services.AddScoped<IAsyncNotificationHandler<NewRecipeAdded>, RecipeEventHandler>();
            services.AddScoped<IAsyncNotificationHandler<RecipeDeleted>, RecipeEventHandler>();
            services.AddScoped<IAsyncNotificationHandler<DeletedRecipeRestored>, RecipeEventHandler>();
            services.AddScoped<IAsyncNotificationHandler<RecipeUpdated>, RecipeEventHandler>();
            services.AddScoped<IAsyncNotificationHandler<RecipeCategoryAdded>, RecipeEventHandler>();
        }

        private static void RegisterInfraServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();
            services.AddScoped<SweetGoodsRecipesContext>();
        }

        private static void RegisterInfraRepositories(IServiceCollection services)
        {
            //Event Sourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();

            //Commands
            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddScoped<ICookingMethodCommandRepository, CookingMethodCommandRepository>();
            services.AddScoped<ICookingMethodIngredientCommandRepository, CookingMethodIngredientCommandRepository>();
            services.AddScoped<ICookingStepsCommandRepository, CookingStepsCommandRepository>();
            services.AddScoped<IIngredientCommandRepository, IngredientCommandRepository>();
            services.AddScoped<IRecipeCategoryCommandRepository, RecipeCategoryCommandRepository>();
            services.AddScoped<IRecipeCommandRepository, RecipeCommandRepository>();

            //Queries
            services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
            services.AddScoped<ICookingMethodQueryRepository, CookingMethodQueryRepository>();
            services.AddScoped<IIngredientQueryRepository, IngredientQueryRepository>();
            services.AddScoped<IRecipeQueryRepository, RecipeQueryRepository>();
        }
    }
}