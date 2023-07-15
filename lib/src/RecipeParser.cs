using System.Text.Json;
using System.Text.Json.Serialization;
using FetchRecipe.Data;

namespace FetchRecipe
{
    public static class RecipeParser
    {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            Converters = { new Iso8601DurationJsonConverter() }
        };

        /// <summary>Parse a JSON+LD representation in <paramref name="jsonLd"/> of a <see cref="Recipe"/>.</summary>
        /// <param name="jsonLd">the JSON+LD representation of a <see cref="Recipe"/> to parse</param>
        /// <returns>the parsed <see cref="Recipe"/> or <see langword="null"/>, if it couldn't be parsed</returns>
        public static Recipe? ParseRecipe(string jsonLd)
        {
            return JsonSerializer.Deserialize<Recipe>(jsonLd, options);
        }
    }
}
