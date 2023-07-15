namespace FetchRecipe.Data
{
    [TestFixture(TestName = "Mass.Parse()")]
    public class MassParseTests
    {
        [Test]
        public void WhenGivenNullItReturnsNull()
        {
            Mass? energy = Mass.Parse(null);

            Assert.That(energy, Is.Null);
        }

        [Test]
        public void WhenGivenAnInvalidStringItReturnsNull()
        {
            Mass? energy = Mass.Parse("foo bar");

            Assert.That(energy, Is.Null);
        }

        [Test]
        public void WhenGivenAMassStringItParsesTheMassCorrectly()
        {
            Mass? energy = Mass.Parse("7 kg");

            Assert.That(energy, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(energy?.Number, Is.EqualTo(7));
                Assert.That(energy?.Unit, Is.EqualTo("kg"));
            });
        }
    }

    [TestFixture(TestName = "Mass.ToString()")]
    public class MassToStringTests
    {
        [Test]
        public void WhenCalledReturnsAFormattedString()
        {
            string result = new Mass(7, "kg").ToString();

            Assert.That(result, Is.EqualTo("7 kg"));
        }
    }
}