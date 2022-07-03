using System.Reflection.Metadata.Ecma335;
using RecipeApp.Data.DbInitializer;
using RecipeApp2.Data;
using RecipeApp2.Entities;
using RecipeApp2.Services.CateogoryServices;
using RecipeApp2.Services.IngredientServices;
using RecipeApp2.Services.RecipeServices;

namespace RecipeApp2.Services
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddStartupServices(this IServiceCollection services)
        {
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRecipeDbInitializer, RecipeDbInitializer>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<RecipeContext>();

            var context = services.BuildServiceProvider().GetService<RecipeContext>();
            var initializer = new RecipeDbInitializer(context);
            initializer.InitializeAll();

            return services;
        }
    }
}
