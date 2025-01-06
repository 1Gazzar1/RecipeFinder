using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Models;

namespace RecipeFinder.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RecipeController : ControllerBase
	{
		private static List<Recipe> recipes = new List<Recipe>();
		public RecipeController()
        {
			
		}
		[HttpGet]
		public IActionResult getallrecipe()
		{	
			return Ok(recipes);
		}
		[HttpPost]
		public IActionResult addrecipe(Recipe recipe)
		{
			recipes.Add(recipe);
			return Ok("good job");
		}
    }
}
