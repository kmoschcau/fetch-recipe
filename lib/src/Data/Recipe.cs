using System.Text.Json.Serialization;

namespace FetchRecipe.Data
{
    /// <summary>A recipe.</summary>
    public class Recipe : HowTo
    {
        /// <summary>The time it takes to actually cook the dish.</summary>
        [JsonPropertyName("cookTime")]
        public TimeSpan? CookTime { get; set; }

        /// <summary>The method of cooking, such as Frying, Steaming, ...</summary>
        [JsonPropertyName("cookingMethod")]
        public string? CookingMethod { get; set; }

        /// <summary>Nutrition information about the recipe or menu item.</summary>
        [JsonPropertyName("nutrition")]
        public NutritionInformation Nutrition { get; set; } = new NutritionInformation();

        /// <summary>The category of the recipe—for example, appetizer, entree, etc.</summary>
        [JsonPropertyName("recipeCategory")]
        public string? RecipeCategory { get; set; }

        /// <summary>The cuisine of the recipe (for example, French or Ethiopian).</summary>
        [JsonPropertyName("recipeCuisine")]
        public string? RecipeCuisine { get; set; }

        /// <summary>A single ingredient used in the recipe, e.g. sugar, flour or garlic.</summary>
        [JsonPropertyName("recipeIngredient")]
        public List<string> RecipeIngredient { get; set; } = new List<string>();

        /// <summary>
        /// A step in making the recipe, in the form of a single item (document, video, etc.) or an ordered list with
        /// HowToStep and/or HowToSection items.
        /// </summary>
        [JsonPropertyName("recipeInstructions")]
        public List<object> RecipeInstructions { get; set; } = new List<object>();

        [JsonPropertyName("recipeYield")]
        public int? RecipeYield { get; set; }

        [JsonPropertyName("suitableForDiet")]
        public RestrictedDiet? SuitableForDiet { get; set; }
    }
}