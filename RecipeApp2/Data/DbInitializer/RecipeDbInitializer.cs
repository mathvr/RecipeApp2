using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using RecipeApp2.Data;
using RecipeApp2.Entities;

namespace RecipeApp.Data.DbInitializer
{
    public class RecipeDbInitializer : IRecipeDbInitializer
    {
        private  readonly RecipeContext context; 
        public RecipeDbInitializer(RecipeContext context)
        {
            this.context = context;
        }
        
        public void InitializeIngredients()
        {
            if (context.Ingredients.Any()) return; 
            
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\Data\FoodFiles\FOOD_DES.txt");
            string[] lines = System.IO.File.ReadAllLines(path);

            foreach (var line in lines)
            {
                string[] splitCleanValues = line.Remove(0, 1).Split("~^~");
                var ingredientAdded = new Ingredient()
                {
                    Id = int.Parse(splitCleanValues[0]),
                    Category = context.Categories.First(cat => cat.Id == int.Parse(splitCleanValues[1])),
                    Name = splitCleanValues[2]
                };
                context.Ingredients.Add(ingredientAdded);
            }
            context.SaveChanges();
        }

        public void InitializeCategories()
        {
            if (context.Categories.Any()) return;
            
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\Data\FoodFiles\FD_GROUP.txt");
            string[] lines = System.IO.File.ReadAllLines(path);

            foreach (var line in lines)
            {
                string[] splitCleanValues = line.Remove(0, 1).Split("~^~");
                var CategoryAdded = new Category()
                {
                    Id = int.Parse(splitCleanValues[0]),
                    Name = splitCleanValues[1].Remove((splitCleanValues[1].Length-1),1),
                    Ingredients = context.Ingredients.Where(cat => cat.Id.Equals(int.Parse(splitCleanValues[0])))
                };
                Console.WriteLine(CategoryAdded.Name);
                context.Categories.Add(CategoryAdded);
            }
            context.SaveChanges();
        }

        public void InitializeAll()
        {
            InitializeCategories();
            InitializeIngredients();
            
            Console.WriteLine("Database Initialized");
        }
    }
}