using System.Text.Json.Serialization;

namespace FetchRecipe.Data
{
    /// <summary>Nutritional information about the recipe.</summary>
    public class NutritionInformation
    {
        /// <summary>The number of calories.</summary>
        [JsonPropertyName("calories")]
        public Energy? Calories { get; set; }

        /// <summary>The serving size, in terms of the number of volume or mass.</summary>
        [JsonPropertyName("servingSize")]
        public string ServingSize { get; set; } = "1";
    }
}
