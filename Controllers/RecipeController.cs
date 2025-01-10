namespace RecipeFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRecipe()
        {
            var recipes = await _recipeService.GetAllRecipes();
            if (recipes == null || recipes.Count == 0) 
            {
                return NotFound("No recipes Found");
            }
            return Ok(recipes);
        }
		[HttpGet("{Id}")]
		public async Task<IActionResult> GetAllRecipe(string Id)
		{
            var objectId = ObjectId.Parse(Id);
			var recipe = await _recipeService.GetRecipeById(objectId);
			if (recipe == null )
			{
				return NotFound("No recipe Found");
			}
			return Ok(recipe);
		}
		[HttpPost]
		public async Task<IActionResult> AddRecipe(Recipe recipe)
		{
			if (recipe == null)
			{
				return BadRequest("Invalid Format");
			}
			await _recipeService.AddRecipe(recipe);
			return Created();
		}
		[HttpPut]
		public async Task<IActionResult> UpdateRecipe(string Id , Recipe recipe)
		{	
			if (recipe == null)
			{
				return BadRequest("Invalid Format");
			}
			var objectId = ObjectId.Parse(Id);
			await _recipeService.UpdateRecipe(objectId,recipe);
			return NoContent();
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteRecipe(string Id)
		{	
	
			var objectId = ObjectId.Parse(Id);
			await _recipeService.DeleteRecipe(objectId);
			return NoContent();
		}
		[HttpPost("Filter&Sort")]
		public async Task<IActionResult> FilterRecipes(RecipeDTO recipeDetails)
		{
			var recipes = await _recipeService.Filter(recipeDetails.Name,
										recipeDetails.Ingredients,
										recipeDetails.Category,
										recipeDetails.Calories,
										recipeDetails.Cookingtime,
										recipeDetails.SortBy,
										recipeDetails.Asc);
			return Ok(recipes);
		}
	}
}
