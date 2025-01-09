using MongoDB.Driver.Linq;

namespace RecipeFinder.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly AppDBContext _db;
        public RecipeService(AppDBContext db)
        {
            _db = db;
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            var recipes = await _db.Recipes.Find(_ => true).ToListAsync();
            return recipes;
        }
        public async Task<Recipe> GetRecipeById(ObjectId Id)
        {
            var recipe = await _db.Recipes
                            .Find(R => R.Id == Id).FirstOrDefaultAsync();
            return recipe;
        }
        public async Task AddRecipe(Recipe recipe)
        {
            await _db.Recipes.InsertOneAsync(recipe);
        }
        public async Task UpdateRecipe(ObjectId Id, Recipe recipe)
        {
            var old_recipe = await GetRecipeById(Id);
            var new_recipe = recipe; 
            new_recipe.Id = old_recipe.Id;

            await _db.Recipes.ReplaceOneAsync(r => r.Id == Id, new_recipe);
        }
        public async Task DeleteRecipe(ObjectId Id)
        {
            await _db.Recipes.DeleteOneAsync(r => r.Id == Id);
        }
        public async Task<List<Recipe>> Filter(string name, List<string> ingredients, string category, double calories, int cooking_time)
        {
            cooking_time = cooking_time == 0 ?  int.MaxValue : cooking_time;
            calories = calories == 0 ?  double.MaxValue : calories ;
            

			var builder = Builders<Recipe>.Filter;

            var filter =
                            builder.Regex(r => r.Name, new BsonRegularExpression(name, "i")) &
                            builder.Lte(r => r.Calories, calories) &
                            builder.Lte(r => r.Cookingtime, cooking_time) &
                            builder.Regex(r => r.Category, new BsonRegularExpression(category, "i"));
            if (ingredients.Count > 0)
            {
				filter = filter & (builder.ElemMatch(r => r.Ingredients, i => ingredients.Contains(i.Name)));
			}          
                                            
            return await _db.Recipes.Find(filter).ToListAsync();
        }
    }
}
