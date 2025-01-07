﻿namespace RecipeFinder.Models
{
	public class Recipe
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
		[BsonElement("_id")]
		public ObjectId Id { get; set; }

		[BsonElement("Name")]
		public string? Name { get; set; }

		[BsonElement("Instructions")]
		public string? Instructions { get; set; }

		[BsonElement("Calories")]
		public double Calories { get; set; }

		[BsonElement("Servings")]
		public int Servings { get; set; }

		[BsonElement("Cookingtime")]
		public int Cookingtime { get; set; }

		[BsonElement("Category")]
		public string? Category { get; set; }

		[BsonElement("YoutubeUrl")]
		public string? YoutubeUrl { get; set; }

		[BsonElement("Ingredients")]
		public List<Ingredient?>? Ingredients { get; set; }
    }
}
