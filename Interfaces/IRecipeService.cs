namespace RecipeFinder.Interfaces
{
	public interface IRecipeService
	{
		Task<List<Recipe>> GetAllRecipes();
		Task<Recipe> GetRecipeById(ObjectId Id);
		Task AddRecipe(Recipe recipe);
		Task UpdateRecipe(ObjectId Id, Recipe recipe);
		Task DeleteRecipe(ObjectId Id);
		Task<List<Recipe>> Filter(string Name, List<string> ingredients, string category, double calories, int cooking_time);
	}
}
