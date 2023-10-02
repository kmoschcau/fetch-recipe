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
                AssertIngredient(recipe.RecipeIngredient, 0, "2", "cups", "flour");
                AssertIngredient(recipe.RecipeIngredient, 1, "3/4", "cup", "white sugar");
                AssertIngredient(recipe.RecipeIngredient, 2, "2", "teaspoons", "baking powder");
                AssertIngredient(recipe.RecipeIngredient, 3, "1/2", "teaspoon", "salt");
                AssertIngredient(recipe.RecipeIngredient, 4, "1/2", "cup", "butter");
                AssertIngredient(recipe.RecipeIngredient, 5, "2", "eggs", "");
                AssertIngredient(recipe.RecipeIngredient, 6, "3/4", "cup", "milk");

                Assert.That(recipe.RecipeInstructions, Is.Not.Null, "RecipeInstructions");
                AssertRecipeInstruction(
                    recipe.RecipeInstructions,
                    0,
                    "Preheat",
                    "Preheat the oven to 350 degrees F. Grease and flour a 9x9 inch pan."
                );
                AssertRecipeInstruction(
                    recipe.RecipeInstructions,
                    1,
                    "Mix dry ingredients",
                    "In a large bowl, combine flour, sugar, baking powder, and salt."
                );
                AssertRecipeInstruction(
                    recipe.RecipeInstructions,
                    2,
                    "Add wet ingredients",
                    "Mix in the butter, eggs, and milk."
                );
                AssertRecipeInstruction(
                    recipe.RecipeInstructions,
                    3,
                    "Spread into pan",
                    "Spread into the prepared pan."
                );
                AssertRecipeInstruction(
                    recipe.RecipeInstructions,
                    4,
                    "Bake",
                    "Bake for 30 to 35 minutes, or until firm."
                );
                AssertRecipeInstruction(recipe.RecipeInstructions, 5, "Enjoy", "Allow to cool and enjoy.");

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

        private static void AssertIngredient(
            List<RecipeIngredient> ingredients,
            int index,
            string amount,
            string? unit,
            string description
        )
        {
            Assert.That(ingredients, Has.Count.GreaterThanOrEqualTo(index + 1));
            RecipeIngredient? ingredient = ingredients[index];
            Assert.That(ingredient, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(ingredient?.Amount, Is.EqualTo(amount), $"RecipeIngredient.{index}.Amount");
                Assert.That(ingredient?.Unit, Is.EqualTo(unit), $"RecipeIngredient.{index}.Unit");
                Assert.That(ingredient?.Description, Is.EqualTo(description), $"RecipeIngredient.{index}.Description");
            });
        }

        private static void AssertRecipeInstruction(List<HowToStep> instructions, int index, string name, string text)
        {
            Assert.That(instructions, Has.Count.GreaterThanOrEqualTo(index + 1));
            HowToStep? step = instructions[index];
            Assert.That(step, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(step?.Name, Is.EqualTo(name), $"RecipeInstructions.{index}.Name");
                Assert.That(step?.Text, Is.EqualTo(text), $"RecipeInstructions.{index}.Text");
            });
        }
    }
}