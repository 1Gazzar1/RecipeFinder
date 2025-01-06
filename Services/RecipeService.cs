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

    }
}
