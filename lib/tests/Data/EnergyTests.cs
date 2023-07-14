namespace FetchRecipe.Data
{
    [TestFixture(TestName = "Energy.Parse()")]
    public class EnergyParseTests
    {
        [Test]
        public void WhenGivenNullItReturnsNull()
        {
            Energy? energy = Energy.Parse(null);

            Assert.That(energy, Is.Null);
        }

        [Test]
        public void WhenGivenAnInvalidStringItReturnsNull()
        {
            Energy? energy = Energy.Parse("foo bar");

            Assert.That(energy, Is.Null);
        }

        [Test]
        public void WhenGivenAnEnergyStringItParsesTheEnergyCorrectly()
        {
            Energy? energy = Energy.Parse("123 calories");

            Assert.That(energy, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(energy?.Number, Is.EqualTo(123));
                Assert.That(energy?.Unit, Is.EqualTo("calories"));
            });
        }
    }

    [TestFixture(TestName = "Energy.ToString()")]
    public class EnergyToStringTests
    {
        [Test]
        public void WhenCalledReturnsAFormattedString()
        {
            string result = new Energy(123, "calories").ToString();

            Assert.That(result, Is.EqualTo("123 calories"));
        }
    }
}