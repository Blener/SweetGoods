using GiftBagOfBases.Bus;
using GiftBagOfBases.Contexts;
using GiftBagOfBases.Events;
using GiftBagOfBases.Events.Interfaces;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Interfaces.Infra.Data;
using GiftBagOfBases.Notifications;
using GiftBagOfBases.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SweetGoods.Recipes.Application.Interfaces;
using SweetGoods.Recipes.Application.Services;
using SweetGoods.Recipes.Domain.Commands.Category;
using SweetGoods.Recipes.Domain.Commands.CookingMethod;
using SweetGoods.Recipes.Domain.Commands.Ingredient;
using SweetGoods.Recipes.Domain.Commands.Recipe;
using SweetGoods.Recipes.Domain.Events.Category;
using SweetGoods.Recipes.Domain.Events.CookingMethod;
using SweetGoods.Recipes.Domain.Events.Ingredient;
using SweetGoods.Recipes.Domain.Events.Recipe;
using SweetGoods.Recipes.Domain.Handlers.CommandHandlers;
using SweetGoods.Recipes.Domain.Handlers.EventHandlers;
using SweetGoods.Recipes.Domain.Interfaces.Commands;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Infra.Data.Context;
using SweetGoods.Recipes.Infra.Data.Repositories.Commands;
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
            services.AddScoped<IAppCategoryService, AppCategoryService>();
            services.AddScoped<IAppCookingMethodService, AppCookingMethodService>();
            services.AddScoped<IAppIngredientService, AppIngredientService>();
            services.AddScoped<IAppRecipeService, AppRecipeService>();
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

        private static void RegisterDomainCommands(IServiceCollection services)
        {
            //Category
            services.AddScoped<INotificationHandler<AddNewCategory>, CategoryCommandHandler>();
            services.AddScoped<INotificationHandler<DeleteCategory>, CategoryCommandHandler>();
            services.AddScoped<INotificationHandler<RestoreDeletedCategory>, CategoryCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateCategory>, CategoryCommandHandler>();

            //CookingMethod
            services.AddScoped<INotificationHandler<AddNewCookingMethod>, CookingMethodCommandHandler>();
            services.AddScoped<INotificationHandler<DeleteCookingMethod>, CookingMethodCommandHandler>();
            services.AddScoped<INotificationHandler<RestoreDeletedCookingMethod>, CookingMethodCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateCookingMethod>, CookingMethodCommandHandler>();
            services.AddScoped<INotificationHandler<AddIngredient>, CookingMethodCommandHandler>();
            services.AddScoped<INotificationHandler<AddStep>, CookingMethodCommandHandler>();

            //Ingredient
            services.AddScoped<INotificationHandler<AddNewIngredient>, IngredientCommandHandler>();
            services.AddScoped<INotificationHandler<DeleteIngredient>, IngredientCommandHandler>();
            services.AddScoped<INotificationHandler<RestoreDeletedIngredient>, IngredientCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateIngredient>, IngredientCommandHandler>();

            //Recipe
            services.AddScoped<INotificationHandler<AddNewRecipe>, RecipeCommandHandler>();
            services.AddScoped<INotificationHandler<DeleteRecipe>, RecipeCommandHandler>();
            services.AddScoped<INotificationHandler<RestoreDeletedRecipe>, RecipeCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateRecipe>, RecipeCommandHandler>();
            services.AddScoped<INotificationHandler<AddCategory>, RecipeCommandHandler>();
        }

        private static void RegisterDomainEvents(IServiceCollection services)
        {
            //Category
            services.AddScoped<INotificationHandler<NewCategoryAdded>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<CategoryDeleted>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<DeletedCategoryRestored>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<CategoryUpdated>, CategoryEventHandler>();

            //CookingMethod
            services.AddScoped<INotificationHandler<NewCookingMethodAdded>, CookingMethodEventHandler>();
            services.AddScoped<INotificationHandler<CookingMethodDeleted>, CookingMethodEventHandler>();
            services.AddScoped<INotificationHandler<DeletedCookingMethodRestored>, CookingMethodEventHandler>();
            services.AddScoped<INotificationHandler<CookingMethodUpdated>, CookingMethodEventHandler>();
            services.AddScoped<INotificationHandler<CookingMethodIngredientAdded>, CookingMethodEventHandler>();
            services.AddScoped<INotificationHandler<CookingStepAdded>, CookingMethodEventHandler>();

            //Ingredient
            services.AddScoped<INotificationHandler<NewIngredientAdded>, IngredientEventHandler>();
            services.AddScoped<INotificationHandler<IngredientDeleted>, IngredientEventHandler>();
            services.AddScoped<INotificationHandler<DeletedIngredientRestored>, IngredientEventHandler>();
            services.AddScoped<INotificationHandler<IngredientUpdated>, IngredientEventHandler>();

            //Recipe
            services.AddScoped<INotificationHandler<NewRecipeAdded>, RecipeEventHandler>();
            services.AddScoped<INotificationHandler<RecipeDeleted>, RecipeEventHandler>();
            services.AddScoped<INotificationHandler<DeletedRecipeRestored>, RecipeEventHandler>();
            services.AddScoped<INotificationHandler<RecipeUpdated>, RecipeEventHandler>();
            services.AddScoped<INotificationHandler<RecipeCategoryAdded>, RecipeEventHandler>();
        }

        private static void RegisterInfraServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();
            services.AddScoped<DbContextOptions<EventStoreSQLContext>>();
            services.AddScoped<SweetGoodsRecipesContext>();
            services.AddScoped<DbContextOptions<SweetGoodsRecipesContext>>();
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