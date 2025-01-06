namespace RecipeFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly AppDBContext _db;
        public RecipeController(AppDBContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetAllRecipe()
        {


            var recipes = _db.Recipes.Find(_ => true).ToList();
            return Ok(recipes);
        }

    }
}
