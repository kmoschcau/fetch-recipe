using FetchRecipe;
using FetchRecipe.Data;
using FetchRecipe.Serializers;

Recipe? recipe = RecipeParser.ParseRecipe(Console.In.ReadToEnd());

Console.Write(new MarkdownSerializer().Serialize(recipe));