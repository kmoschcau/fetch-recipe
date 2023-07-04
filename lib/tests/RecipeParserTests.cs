using FetchRecipe.Data;

namespace FetchRecipe
{
    [TestFixture(TestName = "RecipeParser.ParseRecipe()")]
    public class RecipeParserTests
    {
        [Test]
        [Ignore("For now")]
        public void WhenGivenAGuidedRecipeItParsesTheRecipeCorrectly()
        {
            Recipe? recipe = RecipeParser.ParseRecipe(File.ReadAllText("./GuidedRecipe.json"));

            Assert.That(recipe, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(recipe?.Name, Is.EqualTo("Party Coffee Cake"));
                Assert.That(recipe?.Description, Is.EqualTo("This coffee cake is awesome and perfect for parties."));
            });
        }
    }
}