namespace RecipeFinder.Models
{
	public class Recipe
	{
		public int object_id { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Calories { get; set; }
        public int Servings { get; set; }
        public int Cookingtime { get; set; }
        public List<Ingredient?>? Ingredients { get; set; }
    }
}
