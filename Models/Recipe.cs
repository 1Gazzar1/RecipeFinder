namespace RecipeFinder.Models
{
	public class Recipe
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
		[BsonElement("_id")]
		public ObjectId Id { get; set; }
		[BsonElement("Name")]
		public string? Name { get; set; }
		[BsonElement("Calories")]
		public string? Calories { get; set; }
		[BsonElement("Servings")]
		public int Servings { get; set; }
		[BsonElement("Cookingtime")]
		public int Cookingtime { get; set; }
		[BsonElement("Ingredients")]
		public List<Ingredient?>? Ingredients { get; set; }
    }
}
