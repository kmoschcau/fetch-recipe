namespace FetchRecipe.Data
{
    [TestFixture(TestName = "Iso8601DurationJsonConverter.Parse()")]
    public class Iso8601DurationJsonConverterParseTests
    {
        [Test]
        public void WhenGivenNullItReturnsNull()
        {
            TimeSpan? timeSpan = Iso8601DurationJsonConverter.Parse(null);

            Assert.That(timeSpan, Is.Null);
        }

        [Test]
        public void WhenGivenAnInvalidStringItReturnsNull()
        {
            TimeSpan? timeSpan = Iso8601DurationJsonConverter.Parse("foo bar");

            Assert.That(timeSpan, Is.Null);
        }

        [Test]
        public void WhenGivenADaysDurationStringItParsesCorrectly()
        {
            TimeSpan? timeSpan = Iso8601DurationJsonConverter.Parse("P7DT");

            Assert.That(timeSpan, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(timeSpan?.Days, Is.EqualTo(7));
                Assert.That(timeSpan?.Hours, Is.EqualTo(0));
                Assert.That(timeSpan?.Minutes, Is.EqualTo(0));
                Assert.That(timeSpan?.Seconds, Is.EqualTo(0));
            });
        }

        [Test]
        public void WhenGivenAnHoursDurationStringItParsesCorrectly()
        {
            TimeSpan? timeSpan = Iso8601DurationJsonConverter.Parse("PT22H");

            Assert.That(timeSpan, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(timeSpan?.Days, Is.EqualTo(0));
                Assert.That(timeSpan?.Hours, Is.EqualTo(22));
                Assert.That(timeSpan?.Minutes, Is.EqualTo(0));
                Assert.That(timeSpan?.Seconds, Is.EqualTo(0));
            });
        }

        [Test]
        public void WhenGivenAMinutesDurationStringItParsesCorrectly()
        {
            TimeSpan? timeSpan = Iso8601DurationJsonConverter.Parse("PT32M");

            Assert.That(timeSpan, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(timeSpan?.Days, Is.EqualTo(0));
                Assert.That(timeSpan?.Hours, Is.EqualTo(0));
                Assert.That(timeSpan?.Minutes, Is.EqualTo(32));
                Assert.That(timeSpan?.Seconds, Is.EqualTo(0));
            });
        }

        [Test]
        public void WhenGivenASecondsDurationStringItParsesCorrectly()
        {
            TimeSpan? timeSpan = Iso8601DurationJsonConverter.Parse("PT27S");

            Assert.That(timeSpan, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(timeSpan?.Days, Is.EqualTo(0));
                Assert.That(timeSpan?.Hours, Is.EqualTo(0));
                Assert.That(timeSpan?.Minutes, Is.EqualTo(0));
                Assert.That(timeSpan?.Seconds, Is.EqualTo(27));
            });
        }

        [Test]
        public void WhenGivenADurationStringItParsesCorrectly()
        {
            TimeSpan? timeSpan = Iso8601DurationJsonConverter.Parse("P1DT2H3M4S");

            Assert.That(timeSpan, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(timeSpan?.Days, Is.EqualTo(1));
                Assert.That(timeSpan?.Hours, Is.EqualTo(2));
                Assert.That(timeSpan?.Minutes, Is.EqualTo(3));
                Assert.That(timeSpan?.Seconds, Is.EqualTo(4));
            });
        }
    }

    [TestFixture(TestName = "Iso8601DurationJsonConverter.Format()")]
    public class Iso8601DurationJsonConverterFormatTests
    {
        [Test]
        public void WhenGivenNullItReturnsNull()
        {
            TimeSpan? timeSpan = null;

            Assert.That(timeSpan, Is.Null);
        }

        [Test]
        public void WhenGivenADaysTimeSpanItFormatsCorrectly()
        {
            string? text = Iso8601DurationJsonConverter.Format(new TimeSpan(56, 0, 0, 0));

            Assert.That(text, Is.Not.Null);
            Assert.That(text, Is.EqualTo("P56DT"));
        }

        [Test]
        public void WhenGivenAnHoursTimeSpanItFormatsCorrectly()
        {
            string? text = Iso8601DurationJsonConverter.Format(new TimeSpan(0, 15, 0, 0));

            Assert.That(text, Is.Not.Null);
            Assert.That(text, Is.EqualTo("PT15H"));
        }

        [Test]
        public void WhenGivenAMinutesTimeSpanItFormatsCorrectly()
        {
            string? text = Iso8601DurationJsonConverter.Format(new TimeSpan(0, 0, 13, 0));

            Assert.That(text, Is.Not.Null);
            Assert.That(text, Is.EqualTo("PT13M"));
        }

        [Test]
        public void WhenGivenASecondsTimeSpanItFormatsCorrectly()
        {
            string? text = Iso8601DurationJsonConverter.Format(new TimeSpan(0, 0, 0, 34));

            Assert.That(text, Is.Not.Null);
            Assert.That(text, Is.EqualTo("PT34S"));
        }
    }
}
