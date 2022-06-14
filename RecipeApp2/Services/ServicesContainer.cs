using System.Reflection.Metadata.Ecma335;
using RecipeApp.Data.DbInitializer;
using RecipeApp2.Data;
using RecipeApp2.Entities;

namespace RecipeApp2.Services
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddStartupServices(this IServiceCollection services)
        {
            services.AddScoped<IRecipeDbInitializer, RecipeDbInitializer>();
            services.AddScoped<RecipeContext>();

            var context = services.BuildServiceProvider().GetService<RecipeContext>();
            var initializer = new RecipeDbInitializer(context);
            initializer.InitializeAll();
            context.Dispose();

            return services;
        }
    }
}
