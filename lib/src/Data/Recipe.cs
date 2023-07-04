using System.Text.Json.Serialization;

namespace FetchRecipe.Data
{
    /// <summary>A recipe.</summary>
    public class Recipe
    {
        /// <summary>The name of the dish.</summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>A short summary describing the dish.</summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        // [JsonPropertyName("prepTime")]
        // public TimeSpan? PrepTime { get; set; }
        //
        // /// <summary>The time it takes to actually cook the dish.</summary>
        // [JsonPropertyName("cookTime")]
        // public TimeSpan? CookTime { get; set; }
        //
        // [JsonPropertyName("totalTime")]
        // public TimeSpan? TotalTime { get; set; }

        [JsonPropertyName("recipeYield")]
        public int? RecipeYield { get; set; }

        [JsonPropertyName("nutrition")]
        public NutritionInformation Nutrition { get; set; } = new NutritionInformation();
    }
}
