using System.Text.Json.Serialization;

namespace FetchRecipe.Data
{
    /// <summary>Nutritional information about the recipe.</summary>
    public class NutritionInformation
    {
        /// <summary>The number of calories.</summary>
        [JsonPropertyName("calories")]
        public Energy? Calories { get; set; }

        /// <summary>The number of grams of carbohydrates.</summary>
        [JsonPropertyName("carbohydrateContent")]
        public Mass? CarbohydrateContent { get; set; }

        /// <summary>The number of milligrams of cholesterol.</summary>
        [JsonPropertyName("cholesterolContent")]
        public Mass? CholesterolContent { get; set; }

        /// <summary>The number of grams of fat.</summary>
        [JsonPropertyName("fatContent")]
        public Mass? FatContent { get; set; }

        /// <summary>The number of grams of fiber.</summary>
        [JsonPropertyName("fiberContent")]
        public Mass? FiberContent { get; set; }

        /// <summary>The number of grams of protein.</summary>
        [JsonPropertyName("proteinContent")]
        public Mass? ProteinContent { get; set; }

        /// <summary>The number of grams of saturated fat.</summary>
        [JsonPropertyName("saturatedFatContent")]
        public Mass? SaturatedFatContent { get; set; }

        /// <summary>The serving size, in terms of the number of volume or mass.</summary>
        [JsonPropertyName("servingSize")]
        public string ServingSize { get; set; } = "1";

        /// <summary>The number of milligrams of sodium.</summary>
        [JsonPropertyName("sodiumContent")]
        public Mass? SodiumContent { get; set; }

        /// <summary>The number of grams of sugar.</summary>
        [JsonPropertyName("sugarContent")]
        public Mass? SugarContent { get; set; }

        /// <summary>The number of grams of trans fat.</summary>
        [JsonPropertyName("transFatContent")]
        public Mass? TransFatContent { get; set; }

        /// <summary>The number of grams of unsaturated fat.</summary>
        [JsonPropertyName("unsaturatedFatContent")]
        public Mass? UnsaturatedFatContent { get; set; }
    }
}