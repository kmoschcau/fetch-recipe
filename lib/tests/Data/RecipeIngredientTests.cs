namespace FetchRecipe.Data
{
    [TestFixture(TestName = "RecipeIngredient.Parse()")]
    public class RecipeIngredientTests
    {
        [Test]
        public void WhenGivenNullItReturnsNull()
        {
            RecipeIngredient? ingredient = RecipeIngredient.Parse(null);

            Assert.That(ingredient, Is.Null);
        }

        [Test]
        public void WhenGivenAnInvalidStringItReturnsNull()
        {
            RecipeIngredient? ingredient = RecipeIngredient.Parse("foo bar");

            Assert.That(ingredient, Is.Null);
        }

        [Test]
        public void WhenGivenAnIntegerAmountStringItParsesTheIngredientCorrectly()
        {
            RecipeIngredient? ingredient = RecipeIngredient.Parse("123 cups of rice");

            Assert.That(ingredient, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(ingredient?.Amount, Is.EqualTo("123"));
                Assert.That(ingredient?.Unit, Is.EqualTo("cups"));
                Assert.That(ingredient?.Description, Is.EqualTo("rice"));
            });
        }

        [Test]
        public void WhenGivenAFractionalAmountStringItParsesTheIngredientCorrectly()
        {
            RecipeIngredient? ingredient = RecipeIngredient.Parse("3/4 cup white sugar");

            Assert.That(ingredient, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(ingredient?.Amount, Is.EqualTo("3/4"));
                Assert.That(ingredient?.Unit, Is.EqualTo("cup"));
                Assert.That(ingredient?.Description, Is.EqualTo("white sugar"));
            });
        }
    }
}