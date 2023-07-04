using System.Text.Json;

using FetchRecipe.Data;

namespace FetchRecipe
{
    public static class RecipeParser
    {
        /// <summary>Parse a JSON+LD representation in <paramref name="jsonLd"/> of a <see cref="Recipe"/>.</summary>
        /// <param name="jsonLd">the JSON+LD representation of a <see cref="Recipe"/> to parse</param>
        /// <returns>the parsed <see cref="Recipe"/> or <see langword="null"/>, if it couldn't be parsed</returns>
        public static Recipe? ParseRecipe(string jsonLd)
        {
            return JsonSerializer.Deserialize<Recipe>(jsonLd);
        }
    }
}