using FetchRecipe.Data;

namespace FetchRecipe
{
    [TestFixture(TestName = "RecipeParser.ParseRecipe()")]
    public class RecipeParserTests
    {
        [Test]
        public void WhenGivenAGuidedRecipeItParsesTheRecipeCorrectly()
        {
            Recipe? recipe = RecipeParser.ParseRecipe(File.ReadAllText("./GuidedRecipe.json"));

            Assert.That(recipe, Is.Not.Null, "Recipe");
            if (recipe is null)
            {
                return;
            }

            Assert.Multiple(() =>
            {
                Assert.That(recipe.CookTime, Is.Not.Null, "CookTime");
                Assert.That(recipe.CookTime?.Minutes, Is.EqualTo(30), "CookTime.Minutes");

                Assert.That(recipe.Nutrition, Is.Not.Null, "Nutrition");
                Assert.That(recipe.Nutrition.Calories, Is.Not.Null, "Nutrition.Calories");
                Assert.That(recipe.Nutrition.Calories?.Number, Is.EqualTo(270), "Nutrition.Calories.Number");
                Assert.That(recipe.Nutrition.Calories?.Unit, Is.EqualTo("calories"), "Nutrition.Calories.Unit");

                Assert.That(recipe.RecipeCategory, Is.EqualTo("Dessert"), "RecipeCategory");

                Assert.That(recipe.RecipeCuisine, Is.EqualTo("American"), "RecipeCuisine");

                Assert.That(recipe.RecipeIngredient, Is.Not.Null, "RecipeIngredient");
                Assert.That(recipe.RecipeIngredient.Count, Is.EqualTo(7), "RecipeIngredient.Count");

                Assert.That(recipe.RecipeInstructions, Is.Not.Null, "RecipeInstructions");
                Assert.That(recipe.RecipeInstructions.Count, Is.EqualTo(6), "RecipeInstructions");

                Assert.That(recipe.RecipeYield, Is.EqualTo(10), "RecipeYield");

                Assert.That(recipe.PrepTime, Is.Not.Null, "PrepTime");
                Assert.That(recipe.PrepTime?.Minutes, Is.EqualTo(20), "PrepTime.Minutes");

                Assert.That(recipe.TotalTime, Is.Not.Null, "TotalTime");
                Assert.That(recipe.TotalTime?.Minutes, Is.EqualTo(50), "TotalTime.Minutes");

                Assert.That(recipe.AggregateRating, Is.Not.Null, "AggregateRating");
                Assert.That(recipe.AggregateRating?.RatingCount, Is.EqualTo(18), "AggregateRating.RatingCount");
                Assert.That(recipe.AggregateRating?.ReviewCount, Is.Null, "AggregateRating.RatingCount");
                Assert.That(recipe.AggregateRating?.RatingValue, Is.EqualTo(5.0), "AggregateRating.RatingValue");

                Assert.That(recipe.Author, Is.Not.Null, "Author");
                Assert.That(recipe.Author?.Name, Is.EqualTo("Mary Stone"));

                Assert.That(recipe.DatePublished, Is.EqualTo(new DateTime(2018, 3, 10)), "DatePublished");

                Assert.That(recipe.Keywords, Is.EqualTo("cake for a party, coffee"), "Keywords");

                Assert.That(recipe.Name, Is.EqualTo("Party Coffee Cake"), "Name");
                Assert.That(
                    recipe.Description,
                    Is.EqualTo("This coffee cake is awesome and perfect for parties."),
                    "Description"
                );
            });
        }
    }
}
