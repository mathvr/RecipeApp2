namespace RecipeApp.Data.DbInitializer
{
    public interface IRecipeDbInitializer
    {
        void InitializeIngredients();
        void InitializeCategories();
        void InitializeAll();
    }
}